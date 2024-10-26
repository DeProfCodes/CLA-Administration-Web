using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Helpers.Reporting;
using CLA_Administration_Web.Services.Reporting;
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
        private readonly IReportingService _reportService;

        private ReportingHelper reportingHelper;

        public ReportsController(IReportingService reportService)
        {
            _reportService = reportService;

            reportingHelper = new ReportingHelper(reportService);
        }

        #region Module Report

        [HttpGet]
        public async Task<JsonResult> ReportModulesListing(ReportsNamesType reportType, DateTime startDate, DateTime endDate)
        {
            var listingVm = await reportingHelper.GetModuleReportListing(reportType, startDate, endDate);

            return Json(listingVm.ModuleTitles);
        }

        #endregion

        #region Survey Reports

        [HttpGet]
        public async Task<IActionResult> SurveyReport()
        {
            return PartialView(AppPagesLinks.Reports.SurveyPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> SurveyReportForExport([FromQuery] ModuleReportDataFilterViewModel parameters)
        {
            var surveyReportVm = await reportingHelper.LoadSurveyReportsTabs(parameters);

            if (parameters.ShowRawDataOnly)
            {
                return PartialView(AppPagesLinks.Reports.ModuleRawDataPageLink, surveyReportVm.AllData);
            }
            return PartialView(AppPagesLinks.Reports.SurveyExportPageLink, surveyReportVm);
        }

        [HttpGet]
        public async Task<IActionResult> SurveyReportOnly([FromQuery] ModuleReportDataFilterViewModel parameters)
        {
            var surveyReportVm = await reportingHelper.LoadSurveyReportsTabs(parameters);

            if (parameters.ShowRawDataOnly)
            {
                return PartialView(AppPagesLinks.Reports.ModuleRawDataPageLink, surveyReportVm.AllData);
            }
            return PartialView(AppPagesLinks.Reports.SurveyReportOnlyPageLink, surveyReportVm);
        }

        #endregion

        #region Popup Reports

        [HttpGet]
        public async Task<IActionResult> PopupReport()
        {
            return PartialView(AppPagesLinks.Reports.PopupPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> PopupReportForExport([FromQuery] ModuleReportDataFilterViewModel parameters)
        {
            var popupReportVm = await reportingHelper.LoadPopupReportsTabs(parameters);

            if (parameters.ShowRawDataOnly)
            {
                return PartialView(AppPagesLinks.Reports.ModuleRawDataPageLink, popupReportVm.AllData);
            }

            return PartialView(AppPagesLinks.Reports.PopupExportPageLink, popupReportVm);
        }

        [HttpGet]
        public async Task<IActionResult> PopupReportOnly([FromQuery] ModuleReportDataFilterViewModel parameters)
        {
            var popupReportVm = await reportingHelper.LoadPopupReportsTabs(parameters);

            if (parameters.ShowRawDataOnly)
            {
                return PartialView(AppPagesLinks.Reports.ModuleRawDataPageLink, popupReportVm.AllData);
            }

            return PartialView(AppPagesLinks.Reports.PopupReportOnlyPageLink, popupReportVm);
        }

        #endregion

        #region Ticker Reports 

        [HttpGet]
        public async Task<IActionResult> TickerReport()
        {
            return PartialView(AppPagesLinks.Reports.TickerPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> TickerReportForExport([FromQuery] ModuleReportDataFilterViewModel parameters)
        {
            var tickerReportVm = await reportingHelper.LoadTickerReportsTabs(parameters);

            if (parameters.ShowRawDataOnly)
            {
                return PartialView(AppPagesLinks.Reports.ModuleRawDataPageLink, tickerReportVm.AllData);
            }

            return PartialView(AppPagesLinks.Reports.TickerExportPageLink, tickerReportVm);
        }

        [HttpGet]
        public async Task<IActionResult> TickerReportOnly([FromQuery] ModuleReportDataFilterViewModel parameters)
        {
            var tickerReportVm = await reportingHelper.LoadTickerReportsData(parameters);

            if (parameters.ShowRawDataOnly)
            {
                return PartialView(AppPagesLinks.Reports.ModuleRawDataPageLink, tickerReportVm.TickerReportAllData);
            }

            return PartialView(AppPagesLinks.Reports.TickerReportOnlyPageLink, tickerReportVm);
        }

        #endregion

        #region Policy Reports

        [HttpGet]
        public async Task<IActionResult> PolicyReport()
        {
            return PartialView(AppPagesLinks.Reports.PolicyPageLink);
        }


        [HttpGet]
        public async Task<IActionResult> PolicyReportForExport([FromQuery] ModuleReportDataFilterViewModel parameters)
        {
            var policyReportVm = await reportingHelper.LoadPolicyReportsTabs(parameters);

            if (parameters.ShowRawDataOnly)
            {
                return PartialView(AppPagesLinks.Reports.ModuleRawDataPageLink, policyReportVm.AllData);
            }

            return PartialView(AppPagesLinks.Reports.PolicyExportPageLink, policyReportVm);
        }

        [HttpGet]
        public async Task<IActionResult> PolicyReportOnly([FromQuery] ModuleReportDataFilterViewModel parameters)
        {
            var policyReportVm = await reportingHelper.LoadPolicyReportsTabs(parameters);

            if (parameters.ShowRawDataOnly)
            {
                return PartialView(AppPagesLinks.Reports.ModuleRawDataPageLink, policyReportVm.AllData);
            }

            return PartialView(AppPagesLinks.Reports.PolicyReportOnlyPageLink, policyReportVm);
        }

        #endregion

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

        public IActionResult ExportFileToExcel(ReportsNamesType reportType)
        {
            var filename = "";
            using (var workbook = new XLWorkbook())
            {
                if (reportType == ReportsNamesType.Popup)
                {
                    ExportHelper.ExportPopupReport(workbook);
                    filename = "rptPopup.xlsx";
                }
                else if (reportType == ReportsNamesType.Survey)
                {
                    ExportHelper.ExportSurveyReport(workbook);
                    filename = "rptSurvey.xlsx";
                }
                else if (reportType == ReportsNamesType.Ticker)
                {
                    ExportHelper.ExportTickerReport(workbook);
                    filename = "rptTicker.xlsx";
                }
                else if (reportType == ReportsNamesType.Policy)
                {
                    ExportHelper.ExportPolicyReport(workbook);
                    filename = "rptPolicy.xlsx";
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);

                    var excelBytes = stream.ToArray();

                    return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
                }
            }
        }
        
    }
}
 