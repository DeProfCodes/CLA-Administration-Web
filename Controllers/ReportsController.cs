using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Helpers.Reporting;
using CLA_Administration_Web.ViewModels.Reports;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Reporting.NETCore;
using Newtonsoft.Json;
using System.Text;

namespace CLA_Administration_Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        private LocalReport LocalReport;

        public ReportsController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> SurveyReport()
        {
            return PartialView(AppPagesLinks.Reports.SurveyPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> SurveyReportForExport(int surveyId)
        {
            var surveyReportVm = ReportingHelper.LoadSurveyReportsTabs();

            return PartialView(AppPagesLinks.Reports.SurveyExportPageLink, surveyReportVm);
        }

        public ActionResult ExportLocalReport()
        {
            LocalReport localReport = new LocalReport();

            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/Reporting/Report/rptReporting_STM_ALL_Export_Only.rdlc");
            localReport.ReportPath = reportPath;

            var reportData = ReportingHelper.GetPopupReport(_hostingEnvironment); 

            string mimeType, encoding, fileNameExtension;
            Warning[] warnings;
            string[] streams;

            byte[] renderedBytes = localReport.Render("EXCEL", null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

            return File(renderedBytes, mimeType, "PopupReport.xlsx");
        }

        public IActionResult ShowLocalReport()
        {
            var data = ReportsMockData.GetReportingMockData().PopupReporting;

            var localReport = new LocalReport();
            using (FileStream fs = new FileStream(data.All.ReportRDLCPath, FileMode.Open, FileAccess.Read))
            {
                localReport.LoadReportDefinition(fs);
            }

            localReport.DataSources.Add(new ReportDataSource(data.Summary.RDLCName, data.Summary.DataSet.Tables[0]));
            localReport.DataSources.Add(new ReportDataSource(data.QuestionsSummary.RDLCName, data.QuestionsSummary.DataSet.Tables[0]));
            localReport.DataSources.Add(new ReportDataSource(data.Outstanding.RDLCName, data.Outstanding.DataSet.Tables[0]));
            localReport.DataSources.Add(new ReportDataSource(data.OutstandingSummary.RDLCName, data.OutstandingSummary.DataSet.Tables[0])); 
            localReport.DataSources.Add(new ReportDataSource(data.ResponseBreakdownData.RDLCName, data.ResponseBreakdownData.DataSet.Tables[0]));
            localReport.DataSources.Add(new ReportDataSource(data.Status.RDLCName, data.Status.DataSet.Tables[0]));

            

            string mimeType, encoding, fileNameExtension;
            Warning[] warnings;
            string[] streams;

            byte[] renderedBytes = localReport.Render(
                    "HTML5",
                    null, out mimeType, out encoding, out fileNameExtension,
                    out streams, out warnings);

            return Content(Encoding.UTF8.GetString(renderedBytes), "text/html");
        }

        [HttpGet]
        public async Task<IActionResult> PopupReport()
        {
            return PartialView(AppPagesLinks.Reports.PopupPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> PopupReportForExport(int popupId)
        {
            var popupReportVm = ReportingHelper.LoadPopupReportsTabs();

            return PartialView(AppPagesLinks.Reports.PopupExportPageLink, popupReportVm);
        }

        [HttpGet]
        public async Task<IActionResult> TickerReport()
        {
            return PartialView(AppPagesLinks.Reports.TickerPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> TickerReportForExport(int tickerId)
        {
            var tickerReportVm = ReportingHelper.LoadTickerReportsTabs();

            return PartialView(AppPagesLinks.Reports.TickerExportPageLink, tickerReportVm);
        }

        [HttpGet]
        public async Task<IActionResult> PolicyReport()
        {
            return PartialView(AppPagesLinks.Reports.PolicyPageLink);
        }


        [HttpGet]
        public async Task<IActionResult> PolicyReportForExport(int policyId)
        {
            var policyReportVm = ReportingHelper.LoadPolicyReportsTabs();

            return PartialView(AppPagesLinks.Reports.PolicyExportPageLink, policyReportVm);
        }


        [HttpGet]
        public async Task<IActionResult> ActiveUsersReport()
        {
            return PartialView(AppPagesLinks.Reports.ActiveUsersPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> ActiveMachinesReport()
        {
            return PartialView(AppPagesLinks.Reports.ActiveMachinesPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> CampaignDispatchReport()
        {
            return PartialView(AppPagesLinks.Reports.CampaignDispatchPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> TroubleshootReport()
        {
            return PartialView(AppPagesLinks.Reports.TroubleshootPageLink);
        }

        public IActionResult ExportFile()
        {
            using (var workbook = new XLWorkbook())
            {
                var data = ReportsMockData.GetReportingMockData().PopupReporting;
                var data2 = ReportsMockData.GetReportingMockData().SurveyReporting;

                var reportsBaseAddress = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resources", "reports");

                var summaryTab = ExportHelper.RenderReport(data.Summary);
                var responseSummary = ExportHelper.GetReportExcelBytes(new List<ReportRDLC> { data.QuestionsSummary, data.OutstandingSummary, data.Status }, data.QuestionsSummary.ReportRDLCPath);
                var responseClick = ExportHelper.GetReportExcelBytes(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_Click_DT");
                var responseDismiss = ExportHelper.GetReportExcelBytes(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_Dismiss_DT");
                var responseAutoHide = ExportHelper.GetReportExcelBytes(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_AutoHide_DT");
                var responseSnooze = ExportHelper.GetReportExcelBytes(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_Snooze_DT");
                var responseShow = ExportHelper.GetReportExcelBytes(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_Show_DT");
                var outstanding = ExportHelper.GetReportExcelBytes(new List<ReportRDLC> { data.Outstanding, data.ResponseBreakdownData, data.Status }, data.Outstanding.ReportRDLCPath, "NULL");

                var survey = ExportHelper.GetReportExcelBytes(new List<ReportRDLC> { data2.Summary, data2.Details, data2.SummaryDetails }, data2.Summary.ReportRDLCPath);

                ExportHelper.AddSheetToExcel(workbook, survey, "Survey");

                ExportHelper.AddSheetToExcel(workbook, summaryTab, "Popup Summary");
                ExportHelper.AddSheetToExcel(workbook, responseSummary, "Popup Response Summary");
                ExportHelper.AddSheetToExcel(workbook, responseClick, "Response - Click");
                ExportHelper.AddSheetToExcel(workbook, responseDismiss, "Response - Dismiss");
                ExportHelper.AddSheetToExcel(workbook, responseAutoHide, "Response - Autohide");
                ExportHelper.AddSheetToExcel(workbook, responseSnooze, "Response - Snooze");
                ExportHelper.AddSheetToExcel(workbook, responseShow, "Response - Show");
                ExportHelper.AddSheetToExcel(workbook, outstanding, "Popup Outstanding");

                using (var stream = new MemoryStream())
                {
                    // Save the workbook to the stream
                    workbook.SaveAs(stream);

                    // Convert the stream to a byte array
                    var excelBytes = stream.ToArray();

                    // Return the Excel file for download
                    return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CombinedReports.xlsx");
                }
            }
        }
        
    }
}
 