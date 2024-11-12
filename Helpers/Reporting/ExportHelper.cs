using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.ViewModels.Reports;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using System.Text;

namespace CLA_Administration_Web.Helpers.Reporting
{
    public class ExportHelper
    {
        public static byte[] GetReportExcelBytes(List<ReportRDLC> reportsRDLCs, string reportRDLCPath, string parameterValue = "", string parameterName = "pFilterColumn")
        {
            return ReportingHelper.GetReportBytes("EXCELOPENXML", reportsRDLCs, reportRDLCPath, parameterValue, parameterName);
        }

        public static void AddSheetToExcel(XLWorkbook workbook, byte[] reportBytes, string sheetName)
        {
            using (var tempWorkbookStream = new MemoryStream(reportBytes))
            {
                using (var tempWorkbook = new XLWorkbook(tempWorkbookStream))
                {
                    foreach (var worksheet in tempWorkbook.Worksheets)
                    {
                        worksheet.CopyTo(workbook, sheetName);
                    }
                }
            }
        }

        public static void ExportPopupReport(XLWorkbook workbook, string reportPageName, PopupReports data)
        {
            var summaryTab = GetReportExcelBytes(new List<ReportRDLC> { data.Summary }, data.Summary.ReportRDLCPath);
            var responseSummary = GetReportExcelBytes(new List<ReportRDLC> { data.QuestionsSummary, data.OutstandingSummary, data.Status }, data.QuestionsSummary.ReportRDLCPath);
            var responseClick = GetReportExcelBytes(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_Click_DT");
            var responseDismiss = GetReportExcelBytes(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_Dismiss_DT");
            var responseAutoHide = GetReportExcelBytes(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_AutoHide_DT");
            var responseSnooze = GetReportExcelBytes(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_Snooze_DT");
            var responseShow = GetReportExcelBytes(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_Show_DT");
            var outstanding = GetReportExcelBytes(new List<ReportRDLC> { data.Outstanding, data.ResponseBreakdownData, data.Status }, data.Outstanding.ReportRDLCPath, "NULL");

            reportPageName = reportPageName.ToLower();

            if (reportPageName == "all")
            {
                AddSheetToExcel(workbook, summaryTab, "Popup Summary");
                AddSheetToExcel(workbook, responseSummary, "Popup Response Summary");
                AddSheetToExcel(workbook, responseClick, "Response - Click");
                AddSheetToExcel(workbook, responseDismiss, "Response - Dismiss");
                AddSheetToExcel(workbook, responseAutoHide, "Response - Autohide");
                AddSheetToExcel(workbook, responseSnooze, "Response - Snooze");
                AddSheetToExcel(workbook, responseShow, "Response - Show");
                AddSheetToExcel(workbook, outstanding, "Popup Outstanding");
            }
            else
            {
                if (reportPageName == "summary") AddSheetToExcel(workbook, summaryTab, "Popup Summary");
                if (reportPageName == "response_summary") AddSheetToExcel(workbook, responseSummary, "Popup Response Summary");
                if (reportPageName == "click") AddSheetToExcel(workbook, responseClick, "Response - Click");
                if (reportPageName == "dismiss") AddSheetToExcel(workbook, responseDismiss, "Response - Dismiss");
                if (reportPageName == "autohide") AddSheetToExcel(workbook, responseAutoHide, "Response - Autohide");
                if (reportPageName == "show") AddSheetToExcel(workbook, responseShow, "Response - Show");
                if (reportPageName == "noshow") AddSheetToExcel(workbook, outstanding, "Popup Outstanding");
            }
        }

        public static void ExportSurveyReport(XLWorkbook workbook, string reportPageName, SurveyReports data)
        {
            var reportData = new 
            {
                Summary = GetReportExcelBytes(new List<ReportRDLC> { data.Summary, data.Details, data.SummaryDetails }, data.Summary.ReportRDLCPath),
                Outstanding = GetReportExcelBytes(new List<ReportRDLC> { data.Details, data.Summary, data.SummaryDetails, data.Status }, data.Outstanding.ReportRDLCPath),
                OptInNoResponse = GetReportExcelBytes(new List<ReportRDLC> { data.OptInNoResponse, data.Summary, data.QuestionsSummaryOptIn, data.Details, data.SummaryDetails, data.Status }, data.OptInNoResponse.ReportRDLCPath),
                OptOut = GetReportExcelBytes(new List<ReportRDLC> { data.Summary, data.Details, data.Status }, data.OptOut.ReportRDLCPath),
            };

            if (reportPageName == "all")
            {
                AddSheetToExcel(workbook, reportData.Summary, "Survey Summary");
                AddSheetToExcel(workbook, reportData.Outstanding, "Survey Outstanding");
                AddSheetToExcel(workbook, reportData.OptInNoResponse, "Survey Opt In - No Response");
                AddSheetToExcel(workbook, reportData.OptOut, "Survey Opt Out");
            }
            else
            {
                if (reportPageName == "summary") AddSheetToExcel(workbook, reportData.Summary, "Survey Summary");
                if (reportPageName == "outstanding") AddSheetToExcel(workbook, reportData.Outstanding, "Survey Outstanding");
                if (reportPageName == "optInNoResponse") AddSheetToExcel(workbook, reportData.OptInNoResponse, "Survey Opt In - No Response");
                if (reportPageName == "optOut") AddSheetToExcel(workbook, reportData.OptOut, "Survey Opt Out");
            }
        }

        public static void ExportTickerReport(XLWorkbook workbook, string reportPageName, TickerReports data)
        {
            var reportData = new 
            {
                Summary = GetReportExcelBytes(new List<ReportRDLC> { data.Summary }, data.Summary.ReportRDLCPath),
                Completed = GetReportExcelBytes(new List<ReportRDLC> { data.Completed, data.Outstanding, data.Status }, data.Completed.ReportRDLCPath),
                Outstanding = GetReportExcelBytes(new List<ReportRDLC> { data.Outstanding, data.Status }, data.Outstanding.ReportRDLCPath)
            };

            if (reportPageName == "all")
            {
                AddSheetToExcel(workbook, reportData.Summary, "Ticker Summary");
                AddSheetToExcel(workbook, reportData.Completed, "Ticker Summary (2)");
                AddSheetToExcel(workbook, reportData.Outstanding, "Ticker Outstanding");
            }
            else
            {
                if (reportPageName == "summary") AddSheetToExcel(workbook, reportData.Summary, "Ticker Summary");
                if (reportPageName == "completed") AddSheetToExcel(workbook, reportData.Completed, "Ticker Summary (2)");
                if (reportPageName == "outstanding") AddSheetToExcel(workbook, reportData.Outstanding, "Ticker Outstanding");
            }
        }

        public static void ExportPolicyReport(XLWorkbook workbook)
        {
            var data = LocalDataStorage.StagingData.PolicyReports;

            var reportData = new 
            {
                Summary = GetReportExcelBytes(new List<ReportRDLC> { data.Summary, data.SummaryDetails, data.Outstanding, data.ResponseDetails }, data.Summary.ReportRDLCPath),
                Outstanding = GetReportExcelBytes(new List<ReportRDLC> { data.Summary, data.SummaryDetails, data.Outstanding, data.ResponseDetails, data.Status }, data.Outstanding.ReportRDLCPath),
                ResponseSummary = GetReportExcelBytes(new List<ReportRDLC> { data.Summary, data.SummaryDetails, data.Outstanding, data.ResponseDetails }, data.ResponseDetails.ReportRDLCPath),
            };

            AddSheetToExcel(workbook, reportData.ResponseSummary, "Policy Response Summary");
        }

        public static void ExportActiveUsersReport(XLWorkbook workbook, string reportPageName, ReportRDLC data, ReportRDLC status)
        {
            var reportData = new
            {
                ActiveResult = GetReportExcelBytes(new List<ReportRDLC> { data, status }, data.ReportRDLCPath)
            };

            AddSheetToExcel(workbook, reportData.ActiveResult, $"Active {reportPageName}");
        }


    }
}
