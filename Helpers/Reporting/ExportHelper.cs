using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Models.APIResponses.Reports.Troubleshoot;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.ViewModels.Reports;
using CLA_Administration_Web.ViewModels.Reports.CampaignDispatch;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using System.Text;

namespace CLA_Administration_Web.Helpers.Reporting
{
    public class ExportHelper
    {
        public static byte[] GetReportExcelBytes(List<ReportRDLC> reportsRDLCs, string reportRDLCPath, Dictionary<string,string> parameters)
        {
            return ReportingHelper.GetReportBytes("EXCELOPENXML", reportsRDLCs, reportRDLCPath, parameters);
        }

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
            var rawDataOnly = GetReportExcelBytes(new List<ReportRDLC> { data.AllDataOnly }, data.AllDataOnly.ReportRDLCPath);

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
                if (reportPageName == "response_breakdown-click") AddSheetToExcel(workbook, responseClick, "Response - Click");
                if (reportPageName == "response_breakdown-dismiss") AddSheetToExcel(workbook, responseDismiss, "Response - Dismiss");
                if (reportPageName == "response_breakdown-autohide") AddSheetToExcel(workbook, responseAutoHide, "Response - Autohide");
                if (reportPageName == "response_breakdown-show") AddSheetToExcel(workbook, responseShow, "Response - Show");
                if (reportPageName == "response_breakdown-snooze") AddSheetToExcel(workbook, responseSnooze, "Response - Snooze");
                if (reportPageName == "noshow") AddSheetToExcel(workbook, outstanding, "Popup Outstanding");
                if (reportPageName == "raw_data_only") AddSheetToExcel(workbook, rawDataOnly, "Popup Raw");
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

        public static void ExportCampaignDispatchReport(XLWorkbook workbook, CampainDispatchReports data, CampaignDispatchFiltersViewModel dispatchParams)
        {
            var reportParams = new Dictionary<string, string>
            {
                { "Display_Screensaver", (dispatchParams.ScreensaverReport ? "1" : "0") },
                { "Display_Desktop", (dispatchParams.DesktopReport ? "1" : "0") },
                { "Display_Popup", (dispatchParams.PopupReport ? "1" : "0") },
                { "Display_Survey", (dispatchParams.SurveyReport ? "1" : "0") },
                { "Display_Ticker", (dispatchParams.TickerReport ? "1" : "0") },
                { "Display_Lockscreen", (dispatchParams.LockscreenReport ? "1" : "0") },
            };

            var reportData = new
            {
                All = GetReportExcelBytes(new List<ReportRDLC> { data.Popup, data.Desktop, data.Screensaver, data.Lockscreen, data.Ticker, data.Survey, data.Params }, data.ReportPath, reportParams)
            };

            AddSheetToExcel(workbook, reportData.All, "rptDispatch_Listing");
        }

        public static void ExportTroubleshootReport(XLWorkbook workbook, TroubleshootReportViewModel troubleshootData)
        {
            string csvRaw = GenerateCSV(troubleshootData);

            var worksheet = workbook.Worksheets.Add("Troubleshoot Report");
            var rows = csvRaw.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var columns = rows[rowIndex].Split(',');

                for (int colIndex = 0; colIndex < columns.Length; colIndex++)
                {
                    worksheet.Cell(rowIndex + 1, colIndex + 1).Value = columns[colIndex].Trim();
                }
            }
        }

        public static string GenerateCSV(TroubleshootReportViewModel troubleshootData)
        {
            StringBuilder csvContent = new StringBuilder();

            if (troubleshootData.LastSyncDetails != null)
            {
                csvContent.AppendLine("Exported as per,User" + troubleshootData.LastSyncDetails.UserID);
                csvContent.AppendLine("Environment,Connected to Staging"); // Adjusted to example text
                csvContent.AppendLine($"Last Sync To Database,{troubleshootData.LastSyncDetails.LastUpdateDT?.ToString("yyyy/MM/dd HH:mm:ss")}");
                csvContent.AppendLine($"Last Popup Shown,({troubleshootData.LastSyncDetails.LastSTMID}) {troubleshootData.LastSyncDetails.PopupTitle}");
                csvContent.AppendLine($"Last Popup ID,{troubleshootData.LastSyncDetails.LastSTMDT?.ToString("yyyy/MM/dd HH:mm:ss")}");
                csvContent.AppendLine($"Last Survey Shown,({troubleshootData.LastSyncDetails.LastSurveyID}) {troubleshootData.LastSyncDetails.SurveyTitle}");
                csvContent.AppendLine($"Last Survey ID,{troubleshootData.LastSyncDetails.LastSurveyDT?.ToString("yyyy/MM/dd HH:mm:ss")}");
                csvContent.AppendLine("Is CLA Installed?,No");
                csvContent.AppendLine($"SYNC Version,{troubleshootData.LastSyncDetails.MSDIMSYNCVersion?.ToString("yyyy/MM/dd")}");
                csvContent.AppendLine($"MSDIM Version,{troubleshootData.LastSyncDetails.MSDIMVersion?.ToString("yyyy/MM/dd")}");
                csvContent.AppendLine($"SVC Version,{troubleshootData.LastSyncDetails.MSDIMSVCVersion?.ToString("yyyy/MM/dd")}");
                csvContent.AppendLine();
            }
            
            if (troubleshootData.UserGroups != null)
            {
                csvContent.AppendLine("Active Current Popups,");
                csvContent.Append("Groups that user belongs to,");
                csvContent.AppendLine(string.Join("\t", troubleshootData.UserGroups.ConvertAll(g => g.GroupID)));
                csvContent.AppendLine();
            }
            if (troubleshootData.Settings != null)
            {
                csvContent.AppendLine("Effective Settings,");
                csvContent.AppendLine($"Network,{troubleshootData.Settings.Network}");
                csvContent.AppendLine($"Screensaver Timeout (Seconds),{troubleshootData.Settings.ScreensaverTimeout}");
                csvContent.AppendLine($"Popup Timeout (Seconds),{troubleshootData.Settings.PopUpTimeout}");
                csvContent.AppendLine($"Desktop Timeout (Seconds),{troubleshootData.Settings.DesktopTimeout}");
                csvContent.AppendLine($"Ticker Timeout (Seconds),{troubleshootData.Settings.TickerTimeout}");
                csvContent.AppendLine($"Sync Timeout (Seconds),{troubleshootData.Settings.SyncTimeout}");
                csvContent.AppendLine($"Sync TimeSlot (From),{troubleshootData.Settings.SyncTimeslotFrom}");
                csvContent.AppendLine($"Sync TimeSlot (To),{troubleshootData.Settings.SyncTimeslotTo}");
                csvContent.AppendLine($"Allow Ticker To Launch Automatically?,{(troubleshootData.Settings.AllowTickerToLaunchAutomatically == 1 ? "Yes" : "No")}");
                csvContent.AppendLine($"Update Future Content?,{(troubleshootData.Settings.UpdateFutureContent == 1 ? "Yes" : "No")}");
                csvContent.AppendLine($"Password Protect Screensaver?,{(troubleshootData.Settings.ScreenSaverIsSecure == 1 ? "Yes" : "No")}");
                csvContent.AppendLine($"Allow User To Change Screensaver?,{(troubleshootData.Settings.NoDispScrSavPage == 0 ? "No" : "Yes")}");
                csvContent.AppendLine($"Allow User To Override Desktop?,{(troubleshootData.Settings.DesktopIsSecure == 1 ? "Yes" : "No")}");
                csvContent.AppendLine($"Enable Error Logging?,{(troubleshootData.Settings.ErrorLogging == 1 ? "Yes" : "No")}");
                csvContent.AppendLine($"Maintain Aspect Ratio?,{(troubleshootData.Settings.MaintainAspectRatio == 1 ? "Yes" : "No")}");
                csvContent.AppendLine($"Enable Impression Logging?,{(troubleshootData.Settings.ImpressionLogging == 1 ? "Yes" : "No")}");
                csvContent.AppendLine($"Use Audio?,{(troubleshootData.Settings.UseAudio == "-1" ? "No" : "Yes")}");
                csvContent.AppendLine($"Use Machine ID?,{(troubleshootData.Settings.UseMachineID == 1 ? "Yes" : "No")}");
                csvContent.AppendLine();
            }
            if (troubleshootData.Targeting != null)
            {
                csvContent.AppendLine("Effective Targeting,");
                csvContent.AppendLine($"Targeted for Screensaver,{(troubleshootData.Targeting.FirstOrDefault(x => x.Destination == "SCREENSAVERS" && x.CNT > 0) != null ? "Yes" : "No")}");
                csvContent.AppendLine($"Targeted for Desktop,{(troubleshootData.Targeting.FirstOrDefault(x => x.Destination == "DESKTOPS" && x.CNT > 0) != null ? "Yes" : "No")}");
                csvContent.AppendLine($"Targeted for Survey,{(troubleshootData.Targeting.FirstOrDefault(x => x.Destination == "SURVEYS" && x.CNT > 0) != null ? "Yes" : "No")}");
                csvContent.AppendLine($"Targeted for Popup,{(troubleshootData.Targeting.FirstOrDefault(x => x.Destination == "POPUPS" && x.CNT > 0) != null ? "Yes" : "No")}");
                csvContent.AppendLine($"Targeted for Ticker,{(troubleshootData.Targeting.FirstOrDefault(x => x.Destination == "TICKERS" && x.CNT > 0) != null ? "Yes" : "No")}");
                csvContent.AppendLine($"Targeted for Lockscreen,{(troubleshootData.Targeting.FirstOrDefault(x => x.Destination == "LOCKED DESKTOPS" && x.CNT > 0) != null ? "Yes" : "No")}");
            }
            return csvContent.ToString();
        }
    }
}
