using CLA_Administration_Web.Helpers.API;
using CLA_Administration_Web.Helpers.Enums.Reports;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Models.APIResponses.Reports.ActiveUserMachine;
using CLA_Administration_Web.Models.APIResponses.Reports.CampaignDispatch;
using CLA_Administration_Web.Models.APIResponses.Reports.Policy;
using CLA_Administration_Web.Models.APIResponses.Reports.Popup;
using CLA_Administration_Web.Models.APIResponses.Reports.Survey;
using CLA_Administration_Web.Models.APIResponses.Reports.Ticker;
using CLA_Administration_Web.Models.APIResponses.Reports.Troubleshoot;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.Services.Reporting;
using CLA_Administration_Web.ViewModels.API.Reports;
using CLA_Administration_Web.ViewModels.API.ResponseModels.Popup;
using CLA_Administration_Web.ViewModels.Reports;
using CLA_Administration_Web.ViewModels.Reports.CampaignDispatch;
using CLA_Administration_Web.ViewModels.Reports.Policy;
using CLA_Administration_Web.ViewModels.Reports.Survey;
using CLACommonFunctionsLibrary_NET.Helpers;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Reporting.NETCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.Json;

namespace CLA_Administration_Web.Helpers.Reporting
{
    public class ReportingHelper
    {
        private readonly IReportingService _reportService;
        public ReportingHelper(IReportingService reportService)
        {
            _reportService = reportService;
        }
        

        public static string MergeJsonArrays(string jsonArray1, string jsonArray2, string jsonArray3)
        {
            JArray array1 = !string.IsNullOrEmpty(jsonArray1) ? JArray.Parse(jsonArray1) : new JArray();
            JArray array2 = !string.IsNullOrEmpty(jsonArray2) ? JArray.Parse(jsonArray2) : new JArray();
            JArray array3 = !string.IsNullOrEmpty(jsonArray3) ? JArray.Parse(jsonArray3) : new JArray();


            array1.Merge(array2, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Concat
            });

            array1.Merge(array3, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Concat
            });

            return array1.ToString(Newtonsoft.Json.Formatting.None);
        }

        public static DataSet ConstructFilteredDataSet(bool active, bool inActive, bool notInstalled, string activeJsonData, string inActiveJsonData, string notInstalledJsonData)
        {
            var activeJson = active ? activeJsonData : "";
            var inActiveJson = inActive ? inActiveJsonData : "";
            var notInstalledJson = notInstalled ? notInstalledJsonData : "";

            var mergedJson = MergeJsonArrays(activeJson, inActiveJson, notInstalledJson);

            mergedJson = "{ \"ResultTable\" :" + mergedJson + "}";

            var dataSet = new DataSet();//JsonSerializer.Deserialize<DataSet>(mergedJson);

            return dataSet;
        }


        public static DataSet ConvertJsonToDataSet(string json)
        {
            try
            {
                var unescapedJson = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(json);

                json = "{\"ResultTable\":" + unescapedJson + "}";
                
                var dataSet = Newtonsoft.Json.JsonConvert.DeserializeObject<DataSet>(json);

                return dataSet;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static byte[] GetReportBytes(string format, List<ReportRDLC> reportsRDLCs, string reportRDLCPath, string parameterValue, string parameterName)
        {
            try
            {
                var localReport = new LocalReport();

                using (FileStream fs = new FileStream(reportRDLCPath, FileMode.Open, FileAccess.Read))
                {
                    localReport.LoadReportDefinition(fs);
                }

                foreach (var report in reportsRDLCs)
                {
                    localReport.DataSources.Add(new ReportDataSource(report.RDLCName, report.DataSet.Tables[0]));
                }

                if (!string.IsNullOrEmpty(parameterValue))
                {
                    ReportParameter[] reportParameters =
                    [
                        new ReportParameter(parameterName, parameterValue)
                    ];
                    localReport.SetParameters(reportParameters);
                }

                byte[] renderedBytes = localReport.Render(format, null, out _, out _, out _, out _, out _);

                return renderedBytes;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public static byte[] GetReportBytes(string format, List<ReportRDLC> reportsRDLCs, string reportRDLCPath, Dictionary<string,string> parameters)
        {
            try
            {
                var localReport = new LocalReport();

                using (FileStream fs = new FileStream(reportRDLCPath, FileMode.Open, FileAccess.Read))
                {
                    localReport.LoadReportDefinition(fs);
                }

                foreach (var report in reportsRDLCs)
                {
                    localReport.DataSources.Add(new ReportDataSource(report.RDLCName, report.DataSet.Tables[0]));
                }

                if (parameters != null)
                {
                    ReportParameter[] reportParameters = parameters.Select(param => new ReportParameter(param.Key, param.Value?.ToString())).ToArray();
                    localReport.SetParameters(reportParameters);
                }

                byte[] renderedBytes = localReport.Render(format, null, out _, out _, out _, out _, out _);

                return renderedBytes;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public static string GetReportHTMLString(List<ReportRDLC> reportsRDLCs, string reportRDLCPath, string parameterValue = "", string parameterName = "pFilterColumn")
        {
            var bytes = GetReportBytes("HTML5", reportsRDLCs, reportRDLCPath, parameterValue, parameterName);

            var htmlOutput = Encoding.UTF8.GetString(bytes);

            return htmlOutput;
        }

        static string ExtractTextFromHtml(string html)
        {
            if (string.IsNullOrEmpty(html)) return string.Empty;

            StringBuilder result = new StringBuilder();
            bool insideTag = false;

            foreach (char c in html)
            {
                if (c == '<')
                {
                    insideTag = true;
                }
                else if (c == '>')
                {
                    insideTag = false;
                }
                else
                {
                    if (!insideTag)
                    {
                        result.Append(c);
                    }
                }
            }
            result.Replace("&nbsp;", " ").Replace("&amp;", "&");
            
            return result.ToString().Trim();
        }

        public async Task<ModuleReportListingViewModel> GetModuleReportListing(ReportsNamesType reportType, DateTime effectiveFrom, DateTime effectiveTo)
        {
            try
            {
                var result = new ModuleReportListingViewModel();

                List<ModuleReportListingAPIResponse> data = new();
                var jsonAPIResponse = "";

                var effectiveFromString = effectiveFrom.ToString("yyyy/MM/dd");
                var effectiveToString = effectiveTo.ToString("yyyy/MM/dd");

                jsonAPIResponse = await _reportService.GetModuleListForReporting(reportType, effectiveFromString, effectiveToString);

                data = JsonSerializer.Deserialize<List<ModuleReportListingAPIResponse>>(jsonAPIResponse);

                var moduleTitles = new List<ModuleListingModel>();

                foreach (var moduleReportItem in data)
                {
                    ModuleListingModel moduleTitle = null;

                    if (reportType == ReportsNamesType.Popup || reportType == ReportsNamesType.Policy)
                    {
                        var titleColumn = reportType == ReportsNamesType.Popup ? moduleReportItem.PopupHeader : moduleReportItem.PolicyTitle;

                        moduleTitle = new ModuleListingModel
                        {
                            ModuleId = moduleReportItem.PopupId,
                            Title = $"({moduleReportItem.PopupId}) {ExtractTextFromHtml(titleColumn)}"
                        };
                    }
                    else if (reportType == ReportsNamesType.Survey)
                    {
                        moduleTitle = new ModuleListingModel
                        {
                            ModuleId = moduleReportItem.SurveyID,
                            Title = $"({moduleReportItem.SurveyID}) {ExtractTextFromHtml(moduleReportItem.SurveyTitle)}"
                        };
                    }
                    else if (reportType == ReportsNamesType.Ticker)
                    {
                        moduleTitle = new ModuleListingModel
                        {
                            ModuleId = moduleReportItem.TickerId,
                            Title = moduleReportItem.TickerText
                        };
                    }
                    moduleTitles.Add(moduleTitle);
                }

                result.ModuleTitles = moduleTitles;

                return result;
            }
            catch
            {
                return new();
            }
        }

        private DataSet CreateStatusDataSet(int active, int dormant, int inactive)
        {
            var json =  "{ \"ResultTable\":[{\"IsActive\" :"+active+", \"IsDormant\" :"+dormant+",\"IsInactive\" :"+inactive+" }] }";

            var dataSet = Newtonsoft.Json.JsonConvert.DeserializeObject<DataSet>(json);

            return dataSet;
        }

        public ReportRDLC GetStatusReport(ModuleReportDataFilterViewModel parameters)
        {
            return new ReportRDLC
            {
                RDLCName = "dsStatus",
                DataSet = CreateStatusDataSet(parameters.Active, parameters.NotInstalled, parameters.InActive)
            };
        }

        public async Task<PopupReports> GetPopupReportsForExport(ModuleReportDataFilterViewModel filters)
        {
            var apiParams = new ModuleSummaryParamsViewModel
            {
                ModuleId = filters.ModuleId,
                Active = filters.Active,
                Dormant = filters.NotInstalled,
                InActive = filters.InActive,
                Environment = "",
                ShowActive = false,
                ShowComplete = true,
                ShowOutstanding = true,
                UseMachineId = false,
                ConnectToLive = false,
            };

            var summaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Popup, "STM_Summary");
            var questionSummaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Popup, "STM_Question_Summary");
            var responseDetailsJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Popup, "STM_Response_Detail");
            var outstandingSummaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Popup, "STM_Outstanding_Summary");
            var outstandingJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Popup, "STM_Outstanding");
            var allDataJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Popup, "STM_All_DataOnly");
                            //await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Popup, "STM_All_DataOnly");
            var reportsBaseAddress = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resources", "reports");

            var result = new PopupReports
            {
                Summary = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\popup\\rptSTM_Summary.rdlc",
                    RDLCName = "dsSummary_STM",
                    DataSet = ConvertJsonToDataSet(summaryJson)
                },
                QuestionsSummary = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\popup\\rptSTM_Question_Summary.rdlc",
                    RDLCName = "dsSTM_Question_Summary",
                    DataSet = ConvertJsonToDataSet(questionSummaryJson)
                },
                ResponseBreakdownData = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\popup\\rptSTM_Responses_Breakdown.rdlc",
                    RDLCName = "dsSTM_Response_Optimize_Detail",
                    DataSet = ConvertJsonToDataSet(responseDetailsJson)
                },
                OutstandingSummary = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\popup\\rptSTM_Outstanding_Summary.rdlc",
                    RDLCName = "dsSTM_Outstanding_Summary",
                    DataSet = ConvertJsonToDataSet(outstandingSummaryJson)
                },
                Outstanding = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\popup\\rptSTM_Outstanding.rdlc",
                    RDLCName = "dsSTM_Outstanding",
                    DataSet = ConvertJsonToDataSet(outstandingJson)
                },
                AllDataOnly = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\popup\\rptReporting_STM_All_Export_Only.rdlc",
                    RDLCName = "dsSTM_All_Data_Only",
                    DataSet = ConvertJsonToDataSet(allDataJson)
                },
                Status = new ReportRDLC
                {
                    RDLCName = "dsStatus",
                    DataSet = CreateStatusDataSet(filters.Active, filters.NotInstalled, filters.InActive)
                }
            };

            return result;
        }

        public async Task<PopupReportsRaw> LoadPopupReportsTabs(ModuleReportDataFilterViewModel filters)
        {
            PopupReportsRaw result = null;

            try
            {
                var data = await GetPopupReportsForExport(filters);

                LocalDataStorage.StagingData.PopupReports = data;

                if (!filters.ShowRawDataOnly)
                {
                    result = new PopupReportsRaw()
                    {
                        Summary = GetReportHTMLString(new List<ReportRDLC> { data.Summary, data.Status }, data.Summary.ReportRDLCPath) ?? "",
                        QuestionsSummary = GetReportHTMLString(new List<ReportRDLC> { data.QuestionsSummary, data.OutstandingSummary, data.Status }, data.QuestionsSummary.ReportRDLCPath) ?? "",
                        ResponseBreakdownClick = GetReportHTMLString(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_Click_DT") ?? "",
                        ResponseBreakdownDismiss = GetReportHTMLString(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_Dismiss_DT") ?? "",
                        ResponseBreakdownAutoHide = GetReportHTMLString(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_AutoHide_DT") ?? "",
                        ResponseBreakdownSnooze = GetReportHTMLString(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_Snooze_DT") ?? "",
                        ResponseBreakdownShow = GetReportHTMLString(new List<ReportRDLC> { data.ResponseBreakdownData, data.Status }, data.ResponseBreakdownData.ReportRDLCPath, "Bubble_Show_DT") ?? "",
                        Outstanding = GetReportHTMLString(new List<ReportRDLC> { data.Outstanding, data.ResponseBreakdownData, data.Status }, data.Outstanding.ReportRDLCPath, "NULL") ?? "",
                    };
                }
                else
                {
                    result = new PopupReportsRaw()
                    {
                        AllData = GetReportHTMLString(new List<ReportRDLC> { data.AllDataOnly }, data.AllDataOnly.ReportRDLCPath)
                    };
                }
            }
            catch(Exception ex)
            {
                
            }
            return result;
        }

        public async Task<TickerReports> GetTickerReports(ModuleReportDataFilterViewModel filters)
        {
            var apiParams = new ModuleSummaryParamsViewModel
            {
                ModuleId = filters.ModuleId,
                Active = filters.Active,
                Dormant = filters.NotInstalled,
                InActive = filters.InActive,
                Environment = "",
                ShowActive = false,
                ShowComplete = true,
                ShowOutstanding = true,
                UseMachineId = false,
                ConnectToLive = false,
            };

            var summaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Ticker, "Ticker_Summary");
            var completedJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Ticker, "Ticker_Completed");
            var outstandingJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Ticker, "Ticker_Outstanding");
            var allDataJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Ticker, "Ticker_All_DataOnly");

            var reportsBaseAddress = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resources", "reports");

            var result = new TickerReports
            {
                Summary = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\ticker\\rptTicker_Summary.rdlc",
                    RDLCName = "dsTicker_Summary",
                    DataSet = ConvertJsonToDataSet(summaryJson)
                },
                Outstanding = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\ticker\\rptTicker_Outstanding.rdlc",
                    RDLCName = "dsTicker_Outstanding",
                    DataSet = ConvertJsonToDataSet(outstandingJson)
                },
                Completed = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\ticker\\rptTicker_Completed.rdlc",
                    RDLCName = "dsTicker_Completed",
                    DataSet = ConvertJsonToDataSet(completedJson)
                },
                AllData = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\ticker\\rptReporting_Ticker_All_Export_Only.rdlc",
                    RDLCName = "dsTicker_All_Data_Only",
                    DataSet = ConvertJsonToDataSet(allDataJson)
                },
                Status = new ReportRDLC
                {
                    RDLCName = "dsStatus",
                    DataSet = CreateStatusDataSet(filters.Active, filters.NotInstalled, filters.InActive)
                }
            };

            return result;
        }

        public async Task<ReportRDLC> GetActiveUsersReport(ModuleReportDataFilterViewModel filters, ReportsNamesType reportsName)
        {
            var apiParams = new ModuleSummaryParamsViewModel
            {
                Active = filters.Active,
                Dormant = filters.NotInstalled,
                InActive = filters.InActive,
                ConnectToLive = false,
            };

            var activeUsersMachinesJson = await _reportService.GetActiveUsersMachinesReport(apiParams, reportsName);
            
            var reportsBaseAddress = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resources", "reports");

            var reportRDLCName = reportsName == ReportsNamesType.ActiveUsers ? "rptActiveUsers.rdlc" : "rptActiveMachines.rdlc";
            var SetName = reportsName == ReportsNamesType.ActiveUsers ? "dsActiveUsers" : "dsActiveMachines";

            var result = new ReportRDLC
            {
                ReportRDLCPath = $"{reportsBaseAddress}\\{reportRDLCName}",
                RDLCName = SetName,
                DataSet = ConvertJsonToDataSet(activeUsersMachinesJson)
            };

            return result;
        }

        public async Task<TickerReportsRaw> LoadTickerReportsTabs(ModuleReportDataFilterViewModel filters)
        {
            TickerReportsRaw result = null;
            try
            {
                var data = await GetTickerReports(filters);

                LocalDataStorage.StagingData.TickerReports = data;

                if (!filters.ShowRawDataOnly)
                {
                    result = new TickerReportsRaw()
                    {
                        Summary = GetReportHTMLString(new List<ReportRDLC> { data.Summary }, data.Summary.ReportRDLCPath),
                        Completed = GetReportHTMLString(new List<ReportRDLC> { data.Completed, data.Outstanding, data.Status }, data.Completed.ReportRDLCPath),
                        Outstanding = GetReportHTMLString(new List<ReportRDLC> { data.Outstanding, data.Status }, data.Outstanding.ReportRDLCPath)
                    };
                }
                else
                {
                    result = new TickerReportsRaw()
                    {
                        AllData = GetReportHTMLString(new List<ReportRDLC> { data.AllData }, data.AllData.ReportRDLCPath),
                    };
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<TickerReportsViewModel> LoadTickerReportsData(ModuleReportDataFilterViewModel filters)
        {
            try
            {
                var result = new TickerReportsViewModel() { TickerId = filters.ModuleId };

                var apiParams = new ModuleSummaryParamsViewModel
                {
                    ModuleId = filters.ModuleId,
                    Active = filters.Active,
                    Dormant = filters.NotInstalled,
                    InActive = filters.InActive,
                    Environment = "",
                    ShowActive = false,
                    ShowComplete = true,
                    ShowOutstanding = true,
                    UseMachineId = false,
                    ConnectToLive = false,
                };

                var summaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Ticker, "Ticker_Summary");
                var completedJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Ticker, "Ticker_Completed");
                var outstandingJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Ticker, "Ticker_Outstanding");
                var allDataJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Ticker, "Ticker_All_DataOnly");

                result.TickerReportSummary = APIResponseParserHelper.ParseJsonToObject<TickerReportSummary>(summaryJson, true);
                result.TickerReportComplete = APIResponseParserHelper.ParseJsonToObject<List<TickerReportComplete>>(summaryJson);
                result.TickerReportOutstanding = APIResponseParserHelper.ParseJsonToObject<List<TickerReportOutstanding>>(outstandingJson);
                result.TickerReportAllData = APIResponseParserHelper.ParseJsonToObject<List<TickerReportAllData>>(allDataJson);

                return result;
            }
            catch(Exception ex)
            {
                
            }
            
            var emptyModel = new TickerReportsViewModel()
            {
                TickerReportAllData = new(),
                TickerReportOutstanding = new(),
                TickerReportComplete = new(),
                TickerReportSummary = new()
            };

            return emptyModel;
        }

        public async Task<PopupReportsViewModel> LoadPopupReportsData(ModuleReportDataFilterViewModel filters)
        {
            try
            {
                var result = new PopupReportsViewModel() { PopupId = filters.ModuleId };

                var apiParams = new ModuleSummaryParamsViewModel
                {
                    ModuleId = filters.ModuleId,
                    Active = filters.Active,
                    Dormant = filters.NotInstalled,
                    InActive = filters.InActive,
                    Environment = "",
                    ShowActive = false,
                    ShowComplete = true,
                    ShowOutstanding = true,
                    UseMachineId = false,
                    ConnectToLive = false,
                };

                var summaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Popup, "STM_Summary");
                var questionSummaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Popup, "STM_Question_Summary");
                var responseDetailsJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Popup, "STM_Response_Detail");
                var outstandingSummaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Popup, "STM_Outstanding_Summary");
                var outstandingJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Popup, "STM_Outstanding");
                var allDataJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Popup, "STM_All_DataOnly");

                result.PopupReportSummary = APIResponseParserHelper.ParseJsonToObject<PopupReportSummary>(summaryJson, true);
                result.PopupReportQuestionSummary = APIResponseParserHelper.ParseJsonToObject<PopupReportQuestionSummary>(questionSummaryJson, true);

                var qSummary = result?.PopupReportQuestionSummary ?? new();
                var possibleShowCount = qSummary.PercentageShow - qSummary.ClickCount - qSummary.DismissCount - qSummary.AutohideCount - qSummary.SnoozeCount;
                result.PopupReportQuestionSummary.ShowCount = possibleShowCount > 0 ? possibleShowCount : 0;

                var popupResponseDetails = APIResponseParserHelper.ParseJsonToObject<List<PopupReportResponseDetails>>(responseDetailsJson);

                result.PopupResponseSnooze = popupResponseDetails.Where(x => x.BubbleSnoozeDate != null && x.BubbleShowDate != null).ToList();
                result.PopupResponseAutoHide = popupResponseDetails.Where(x => x.BubbleAutoHideDate != null).ToList();
                result.PopupResponseShow = popupResponseDetails.Where(x => x.BubbleShowDate != null && x.BubbleClickDate == null && x.BubbleSnoozeDate == null).ToList();
                result.PopupResponseClick = popupResponseDetails.Where(x => x.BubbleClickDate != null).ToList();
                result.PopupResponseDismiss = popupResponseDetails.Where(x => x.BubbleDismissDate != null).ToList();

                result.PopupReportOutstanding = APIResponseParserHelper.ParseJsonToObject<List<PopupReportOutstanding>>(outstandingJson);
                result.PopupReportAllData = APIResponseParserHelper.ParseJsonToObject<List<PopupReportAllData>>(allDataJson);

                LocalDataStorage.StagingData.AllPopupReports = result;

                return result;
            }
            catch (Exception ex)
            {

            }

            var emptyModel = new PopupReportsViewModel()
            {
                PopupReportSummary = new(),
                PopupReportQuestionSummary = new(),
                PopupResponseSnooze = new(),
                PopupResponseAutoHide = new(),
                PopupResponseShow = new(),
                PopupResponseClick = new(),
                PopupResponseDismiss = new(),
                PopupReportOutstanding = new(),
                PopupReportAllData = new()
            };

            return emptyModel;
        }

        public async Task<SurveyReports> GetSurveyReportsForExport(ModuleReportDataFilterViewModel filters)
        {
            var apiParams = new ModuleSummaryParamsViewModel
            {
                ModuleId = filters.ModuleId,
                Active = filters.Active,
                Dormant = filters.NotInstalled,
                InActive = filters.InActive,
                Environment = "",
                ShowActive = false,
                ShowComplete = true,
                ShowOutstanding = true,
                UseMachineId = false,
                ConnectToLive = false,
            };

            var detailsJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "Surveys_Detail");
            var questionsSummaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "SurveyQuestions_Summary");
            var questionDetailsJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "SurveyQuestions_Detail");
            var optInNoResponseJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "Surveys_Opt_In_No_Response");
            var summaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "Surveys_Summary");
            var summaryDetailsJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "Surveys_Summary_Detail");
            var allDataJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "Surveys_All_DataOnly");

            var reportsBaseAddress = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resources", "reports");

            var result = new SurveyReports
            {
                Details = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\???.rdlc",
                    RDLCName = "dsReporting_Surveys_Detail",
                    DataSet = ConvertJsonToDataSet(detailsJson)
                },
                QuestionsSummary = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\rptSurvey_Questions_Summary.rdlc",
                    RDLCName = "dsReporting_SurveyQuestions_Summary",
                    DataSet = ConvertJsonToDataSet(questionsSummaryJson)
                },
                QuestionsSummaryOptIn = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\rptSurvey_Questions_Summary_Opt_In.rdlc",
                    RDLCName = "dsReporting_SurveyQuestions_Summary_Opt_In",
                    DataSet = ConvertJsonToDataSet(questionsSummaryJson)
                },
                QuestionsDetails = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\rptSurvey_Questions_Detail.rdlc",
                    RDLCName = "dsReporting_SurveyQuestions_Detail",
                    DataSet = ConvertJsonToDataSet(questionDetailsJson)
                },
                QuestionsDetailsCorrect = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\rptSurvey_Questions_Detail_Correct.rdlc",
                    RDLCName = "dsReporting_SurveyQuestions_Detail",
                    DataSet = ConvertJsonToDataSet(questionDetailsJson)
                },
                QuestionsDetailsIncorrect = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\rptSurvey_Questions_Detail_Incorrect.rdlc",
                    RDLCName = "dsReporting_SurveyQuestions_Detail",
                    DataSet = ConvertJsonToDataSet(questionDetailsJson)
                },
                QuestionsDetailsOptIn = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\rptSurvey_Questions_Detail_Opt_In.rdlc",
                    RDLCName = "dsReporting_SurveyQuestions_Detail_Opt_In",
                    DataSet = ConvertJsonToDataSet(questionDetailsJson)
                },
                QuestionsDetailsOptInCorrect = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\rptSurvey_Questions_Detail_Opt_In_Correct.rdlc",
                    RDLCName = "dsReporting_SurveyQuestions_Detail_Opt_in",
                    DataSet = ConvertJsonToDataSet(questionDetailsJson)
                },
                QuestionsDetailsOptInIncorrect = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\rptSurvey_Questions_Detail_Opt_In_Incorrect.rdlc",
                    RDLCName = "dsReporting_SurveyQuestions_Detail_Opt_in",
                    DataSet = ConvertJsonToDataSet(questionDetailsJson)
                },
                OptInNoResponse = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\rptSurvey_Opt_In_No_Response.rdlc",
                    RDLCName = "dsReporting_Surveys_Opt_In_No_Response",
                    DataSet = ConvertJsonToDataSet(optInNoResponseJson)
                },
                Summary = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\rptSurvey_Summary.rdlc",
                    RDLCName = "dsReporting_Survey_Summary",
                    DataSet = ConvertJsonToDataSet(summaryJson)
                },
                SummaryDetails = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\??rdlc",
                    RDLCName = "dsReporting_Surveys_Summary_Detail",
                    DataSet = ConvertJsonToDataSet(summaryDetailsJson)
                },
                OptOut = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\rptSurvey_Opt_Out.rdlc",
                    RDLCName = "doesntMatter",
                    DataSet = ConvertJsonToDataSet(summaryDetailsJson)
                },
                Outstanding = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\rptSurvey_Outstanding.rdlc",
                    RDLCName = "doesntMatter",
                    DataSet = ConvertJsonToDataSet(summaryDetailsJson)
                },
                AllData = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\survey\\rptReporting_Survey_All_Export_Only",
                    RDLCName = "doesntMatter",
                    DataSet = ConvertJsonToDataSet(allDataJson)
                },
                Status = new ReportRDLC
                {
                    RDLCName = "dsStatus",
                    DataSet = CreateStatusDataSet(filters.Active, filters.NotInstalled, filters.InActive)
                }
            };

            return result;
        }

        public async Task<SurveyReportViewModel> GetSurveyReportsData(ModuleReportDataFilterViewModel filters)
        {
            var result = new SurveyReportViewModel() { SurveyId = filters.ModuleId };

            var apiParams = new ModuleSummaryParamsViewModel
            {
                ModuleId = filters.ModuleId,
                Active = filters.Active,
                Dormant = filters.NotInstalled,
                InActive = filters.InActive,
                Environment = "",
                ShowActive = false,
                ShowComplete = true,
                ShowOutstanding = true,
                UseMachineId = false,
                ConnectToLive = false,
            };

            var detailsJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "Surveys_Detail"); //summarized details
            var questionsSummaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "SurveyQuestions_Summary");
            var questionDetailsJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "SurveyQuestions_Detail");
            var optInNoResponseJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "Surveys_Opt_In_No_Response");
            var summaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "Surveys_Summary");
            var summaryDetailsJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "Surveys_Summary_Detail");
            var allDataJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Survey, "Surveys_All_DataOnly");

            result.SurveySummary = APIResponseParserHelper.ParseJsonToObject<SurveyReportSummary>(summaryJson, true);
            result.SummarizedDetails = APIResponseParserHelper.ParseJsonToObject<List<SurveyReportSummaryDetails>>(detailsJson);

            var summaryDetails = APIResponseParserHelper.ParseJsonToObject<List<SurveyOptInNoResponse>>(summaryDetailsJson);

            result.SurveyCompleteOptOut = new SurveyCompleteOptOutViewModel
            {
                Complete = summaryDetails.Count(x => x.IsSurveyComplete == 1 || x.IsSurveyComplete == 0),
                //OptOut = summaryDetails.Count(x => x.IsSurveyComplete == 0 && x.SurveyOptIn == 0),
            };

            result.Outstanding = result.SummarizedDetails.Where(x => x.IsComplete == 0).ToList();
            result.Outstanding.ForEach(x => 
            {
                x.LastSyncDate = x.LastUpdateDtUser != null ? x.LastUpdateDtUser : (x.LastUpdateDtMachine != null ? x.LastUpdateDtMachine : DateTime.MinValue);
            });

            return result;
        }

        public async Task<SurveyReportsRaw> LoadSurveyReportsTabs(ModuleReportDataFilterViewModel filters)
        {
            SurveyReportsRaw result = null;

            try
            {
                var data = await GetSurveyReportsForExport(filters);

                LocalDataStorage.StagingData.SurveyReports = data;

                if (!filters.ShowRawDataOnly)
                {
                    result = new SurveyReportsRaw()
                    {
                        Summary = GetReportHTMLString(new List<ReportRDLC> { data.Summary, data.Details, data.SummaryDetails }, data.Summary.ReportRDLCPath),
                        Outstanding = GetReportHTMLString(new List<ReportRDLC> { data.Details, data.Summary, data.SummaryDetails, data.Status }, data.Outstanding.ReportRDLCPath),
                        OptInNoResponse = GetReportHTMLString(new List<ReportRDLC> { data.OptInNoResponse, data.Summary, data.QuestionsSummaryOptIn, data.Details, data.SummaryDetails, data.Status }, data.OptInNoResponse.ReportRDLCPath),
                        OptOut = GetReportHTMLString(new List<ReportRDLC> { data.Summary, data.Details, data.Status }, data.OptOut.ReportRDLCPath),
                    };
                }
                else
                {
                    result = new SurveyReportsRaw()
                    {
                        AllData = GetReportHTMLString(new List<ReportRDLC> { data.AllData }, data.AllData.ReportRDLCPath),
                    };
                }
            }
            catch(Exception ex)
            {

            }
            return result;
        }

        public async Task<PolicyReports> GetPolicyReports(ModuleReportDataFilterViewModel filters)
        {
            var apiParams = new ModuleSummaryParamsViewModel
            {
                ModuleId = filters.ModuleId,
                Active = filters.Active,
                Dormant = filters.NotInstalled,
                InActive = filters.InActive,
                Environment = "",
                ShowActive = false,
                ShowComplete = true,
                ShowOutstanding = true,
                UseMachineId = false,
                ConnectToLive = false,
            };

            var summaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Policy, "Policy_Summary");
            var summaryDetailsJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Policy, "Policy_Summary_Detail");
            var outstandingJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Policy, "Policy_Outstanding");

            var reportsBaseAddress = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resources", "reports");

            var result = new PolicyReports
            {
                Summary = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\policy\\rptPolicy_Response_Summary.rdlc",
                    RDLCName = "dsReporting_Policies_Summary",
                    DataSet = ConvertJsonToDataSet(summaryJson)
                },
                SummaryDetails = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\policy\\rptPolicy_Response_Summary.rdlc",
                    RDLCName = "dsReporting_Policies_Summary_Detail",
                    DataSet = ConvertJsonToDataSet(summaryDetailsJson)
                },
                Outstanding = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\policy\\rptPolicy_Outstanding.rdlc",
                    RDLCName = "dsReporting_Policies_Outstanding",
                    DataSet = ConvertJsonToDataSet(outstandingJson)
                },
                ResponseDetails = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\policy\\rptPolicy_Completed_Responses.rdlc",
                    RDLCName = "dsReporting_Policies_Response_Detail",
                    DataSet = ConvertJsonToDataSet(outstandingJson)
                },
                AllData = new ReportRDLC
                {
                    ReportRDLCPath = $"{reportsBaseAddress}\\policy\\rptPolicy_DataOnly.rdlc",
                    RDLCName = "doesntMatter",
                },
                Status = new ReportRDLC
                {
                    RDLCName = "dsStatus",
                    DataSet = CreateStatusDataSet(filters.Active, filters.NotInstalled, filters.InActive)
                },
            };

            return result;
        }

        public async Task<PolicyReportsRaw> LoadPolicyReportsTabs(ModuleReportDataFilterViewModel filters)
        {
            PolicyReportsRaw result = null;

            try
            {
                var data = await GetPolicyReports(filters);
                
                LocalDataStorage.StagingData.PolicyReports = data;

                if (!filters.ShowRawDataOnly)
                {
                    result = new PolicyReportsRaw()
                    {
                        Summary = GetReportHTMLString(new List<ReportRDLC> { data.Summary, data.SummaryDetails, data.Outstanding, data.ResponseDetails }, data.Summary.ReportRDLCPath),
                        Outstanding = GetReportHTMLString(new List<ReportRDLC> { data.Summary, data.SummaryDetails, data.Outstanding, data.ResponseDetails, data.Status }, data.Outstanding.ReportRDLCPath),
                        ResponseSummary = GetReportHTMLString(new List<ReportRDLC> { data.Summary, data.SummaryDetails, data.Outstanding, data.ResponseDetails }, data.ResponseDetails.ReportRDLCPath),
                        AllData = GetReportHTMLString(new List<ReportRDLC> { data.Summary, data.SummaryDetails, data.Outstanding, data.ResponseDetails }, data.AllData.ReportRDLCPath),
                    };
                }
                else
                {
                    result = new PolicyReportsRaw()
                    {
                        AllData = GetReportHTMLString(new List<ReportRDLC> { data.Summary, data.SummaryDetails, data.Outstanding, data.ResponseDetails }, data.AllData.ReportRDLCPath),
                    };
                }
            }
            catch (Exception ex)
            {
                
            }

            return result;
        }

        public async Task<PolicyReportViewModel> GetPolicyReportData(ModuleReportDataFilterViewModel filters, PolicyReportEntityType policyReportEntityType)
        {
            var result = new PolicyReportViewModel()
            {
                PopupId = filters.ModuleId
            };

            var apiParams = new ModuleSummaryParamsViewModel
            {
                ModuleId = filters.ModuleId,
                Active = filters.Active,
                Dormant = filters.NotInstalled,
                InActive = filters.InActive,
                Environment = "",
                ShowActive = false,
                ShowComplete = true,
                ShowOutstanding = true,
                UseMachineId = false,
                ConnectToLive = false,
            };

            var summaryJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Policy, "Policy_Summary");
            var summaryDetailsJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Policy, "Policy_Summary_Detail");
            var outstandingJson = await _reportService.GetModuleSummaryReport(apiParams, ReportsNamesType.Policy, "Policy_Outstanding");

            var summaries = APIResponseParserHelper.ParseJsonToObject<List<PolicyReportSummary>>(summaryJson);
            var summaryDetails = APIResponseParserHelper.ParseJsonToObject<List<PolicyReportSummarizedDetail>>(summaryDetailsJson);
            var outstanding = APIResponseParserHelper.ParseJsonToObject<List<PolicyReportOutstanding>>(outstandingJson);

            result.PolicySummary = new PolicyReportSummaryViewModel
            {
                SummaryUsers = summaries.FirstOrDefault(x => x.TargetedType.ToLower() == "users"),
                SummarizedDetailsUsers = summaryDetails.Where(x => x.TargetedType.ToLower() == "users").ToList(),
                SummaryMachines = summaries.FirstOrDefault(x => x.TargetedType.ToLower() == "machines"),
                SummarizedDetailsMachines = summaryDetails.Where(x => x.TargetedType.ToLower() == "machines").ToList()
            };

            result.PolicyOutstanding = new PolicyReportOutstandingViewModel
            {
                PolicyOutstandingUsers = outstanding.Where(x => x.TargetedType.ToLower() == "users").ToList(),
                PolicyOutstandingMachines = outstanding.Where(x => x.TargetedType.ToLower() == "machines").ToList(),
                PolicyOutstandingUserMachines = outstanding.Where(x => x.TargetedType.ToLower() == "users-machines").ToList(),
            };

            result.PolicyOutstanding.PolicyOutstandingUsers.ForEach(x => x.LastSyncDate = (x.LastSyncDTUser != null) ? x.LastSyncDTUser : x.LastSyncDTMachine);
            result.PolicyOutstanding.PolicyOutstandingMachines.ForEach(x => x.LastSyncDate = (x.LastSyncDTUser != null) ? x.LastSyncDTUser : x.LastSyncDTMachine);
            result.PolicyOutstanding.PolicyOutstandingUserMachines.ForEach(x => x.LastSyncDate = (x.LastSyncDTUser != null) ? x.LastSyncDTUser : x.LastSyncDTMachine);

            if (policyReportEntityType == PolicyReportEntityType.Users) result.PolicyOutstanding.PolicyOutstandingSelected = result.PolicyOutstanding.PolicyOutstandingUsers;
            if (policyReportEntityType == PolicyReportEntityType.Machines) result.PolicyOutstanding.PolicyOutstandingSelected = result.PolicyOutstanding.PolicyOutstandingMachines;
            if (policyReportEntityType == PolicyReportEntityType.UsersAndMachines) result.PolicyOutstanding.PolicyOutstandingSelected = result.PolicyOutstanding.PolicyOutstandingUserMachines;

            result.PolicyOutstanding.PolicyOutstandingSelected = result.PolicyOutstanding.PolicyOutstandingUserMachines;

            return result;
        }

        public async Task<ActiveUserMachinesViewModel> LoadActiveUserMachineReport(ModuleReportDataFilterViewModel filters, ReportsNamesType reportName)
        {
            var result = new ActiveUserMachinesViewModel() { ReportName = reportName };

            var apiParams = new ModuleSummaryParamsViewModel
            {
                Active = filters.Active,
                Dormant = filters.NotInstalled,
                InActive = filters.InActive,
                ConnectToLive = false,
            };

            var activeUserMachineReportJson = await _reportService.GetActiveUsersMachinesReport(apiParams, reportName);

            if (reportName == ReportsNamesType.ActiveUsers)
            {
                result.ActiveUserReports = APIResponseParserHelper.ParseJsonToObject<List<ActiveUserReport>>(activeUserMachineReportJson);
            }
            else if(reportName == ReportsNamesType.ActiveMachines)
            {
                result.ActiveMachineReports = APIResponseParserHelper.ParseJsonToObject<List<ActiveMachineReport>>(activeUserMachineReportJson);
            }
            return result;
        }

        public async Task<CampaignDispatchViewModel> LoadCampaignDispatchReports(CampaignDispatchFiltersViewModel parameters)
        {
            var result = new CampaignDispatchViewModel
            {
                Filters = parameters,
                LockedDesktops = new(),
                Desktops = new(),
                Screensaver = new(),
                Popups = new(),
                Surveys = new(),
                Tickers = new(),
            };
            result.Filters.EffectiveFrom = TypesParserHelper.ParseDate(parameters.StartDate);
            result.Filters.EffectiveTo = TypesParserHelper.ParseDate(parameters.EndDate);

            parameters.IsAutomated = (parameters.ViewType == "automated") ? 1 : 0;

            var lockscreenJson = "";
            var desktopJson = "";
            var screensaverJson = "";
            var popupJson = "";
            var surveyJson = "";
            var tickerJson = "";

            if (parameters.LockscreenReport)
            {
                lockscreenJson = await _reportService.GetCampaignDispatchReport(parameters, "Dispatch_Listing_Locked_Desktop");
                result.LockedDesktops = APIResponseParserHelper.ParseJsonToObject<List<DispatchLockedDesktopResponse>>(lockscreenJson); 
            }
            if (parameters.DesktopReport)
            {
                desktopJson = await _reportService.GetCampaignDispatchReport(parameters, "Dispatch_Listing_Desktop");
                result.Desktops = APIResponseParserHelper.ParseJsonToObject<List<DispatchDesktopResponse>>(desktopJson);
            }
            if (parameters.ScreensaverReport)
            {
                screensaverJson = await _reportService.GetCampaignDispatchReport(parameters, "Dispatch_Listing_Screensaver");
                result.Screensaver = APIResponseParserHelper.ParseJsonToObject<List<DispatchScreensaverResponse>>(screensaverJson);
            }
            if (parameters.PopupReport)
            {
                popupJson = await _reportService.GetCampaignDispatchReport(parameters, "Dispatch_Listing_STM");
                result.Popups = APIResponseParserHelper.ParseJsonToObject<List<DispatchPopupResponse>>(popupJson);
            }
            if (parameters.SurveyReport)
            {
                surveyJson = await _reportService.GetCampaignDispatchReport(parameters, "Dispatch_Listing_Survey");
                result.Surveys = APIResponseParserHelper.ParseJsonToObject<List<DispatchSurveyResponse>>(surveyJson);
            }
            if (parameters.TickerReport)
            {
                tickerJson = await _reportService.GetCampaignDispatchReport(parameters, "Dispatch_Listing_Ticker");
                result.Tickers = APIResponseParserHelper.ParseJsonToObject<List<DispatchTickerResponse>>(tickerJson);
            }

            return result;
        }

        public async Task<CampainDispatchReports> GetCampaignDispatchListReporting(CampaignDispatchFiltersViewModel parameters)
        {
            parameters.IsAutomated = parameters.ViewType == "automated" ? 1 : 0;

            var lockscreenJson = await _reportService.GetCampaignDispatchReport(parameters, "Dispatch_Listing_Locked_Desktop"); ;
            var desktopJson = await _reportService.GetCampaignDispatchReport(parameters, "Dispatch_Listing_Desktop"); ;
            var screensaverJson = await _reportService.GetCampaignDispatchReport(parameters, "Dispatch_Listing_Screensaver"); ;
            var popupJson = await _reportService.GetCampaignDispatchReport(parameters, "Dispatch_Listing_STM"); ;
            var surveyJson = await _reportService.GetCampaignDispatchReport(parameters, "Dispatch_Listing_Survey"); ;
            var tickerJson = await _reportService.GetCampaignDispatchReport(parameters, "Dispatch_Listing_Ticker"); ;
            var paramsJson = await _reportService.GetReportingDispatchListingParams(parameters.StartDate, parameters.EndDate, parameters.IsAutomated);

            var reportsBaseAddress = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resources", "reports");

            var result = new CampainDispatchReports
            {
                ReportPath = $"{reportsBaseAddress}\\rptDispatch_Listings.rdlc",
                Screensaver = new ReportRDLC
                {
                    ReportRDLCPath = $"",
                    RDLCName = "dsReporting_Dispatch_Listing_Screensaver",
                    DataSet = ConvertJsonToDataSet(screensaverJson)
                },
                Desktop = new ReportRDLC
                {
                    ReportRDLCPath = $"",
                    RDLCName = "dsReporting_Dispatch_Listing_Desktop",
                    DataSet = ConvertJsonToDataSet(desktopJson)
                },
                Lockscreen = new ReportRDLC
                {
                    ReportRDLCPath = $"",
                    RDLCName = "dsReporting_Dispatch_Listing_Lockscreen",
                    DataSet = ConvertJsonToDataSet(lockscreenJson)
                },
                Popup = new ReportRDLC
                {
                    ReportRDLCPath = $"",
                    RDLCName = "dsReporting_Dispatch_Listing_STM",
                    DataSet = ConvertJsonToDataSet(popupJson)
                },
                Ticker = new ReportRDLC
                {
                    ReportRDLCPath = $"",
                    RDLCName = "dsReporting_Dispatch_Listing_Ticker",
                    DataSet = ConvertJsonToDataSet(tickerJson)
                },
                Survey = new ReportRDLC
                {
                    ReportRDLCPath = $"",
                    RDLCName = "dsReporting_Dispatch_Listing_Survey",
                    DataSet = ConvertJsonToDataSet(surveyJson)
                },
                Params = new ReportRDLC
                {
                    ReportRDLCPath = $"",
                    RDLCName = "dsReporting_Dispatch_Listing_Params",
                    DataSet = ConvertJsonToDataSet(paramsJson)
                },
            };

            return result;
        }

        public async Task<TroubleshootReportViewModel> GetTroubleshootReportData(CLAEntityType entityType, string entityValue)
        {
            var result = new TroubleshootReportViewModel();

            var entityJson = "";
            TroubleshootReportEntity entity = null;

            var entityColName = "";
            var entitySymbol = "";

            if (entityType == CLAEntityType.User)
            {
                entityColName = "User_ID";
                entitySymbol = "U";

                entityJson = await _reportService.GetNTUsernameForTroubleshootReporting(entityValue);
            }
            else if (entityType == CLAEntityType.Machine)
            {
                entityColName = "Machine_ID";
                entitySymbol = "M";

                entityJson = await _reportService.GetMachineNameForTroubleshootReporting(entityValue);
            }
            else if (entityType == CLAEntityType.IPAddress)
            {
                entityColName = "IP_Address";
                entitySymbol = "I";
            }

            var userEntityParam = entityType == CLAEntityType.User ? entityValue : "--####--";
            var machineEntityParam = entityType == CLAEntityType.Machine ? entityValue : "--####--";
            var ipAddressEntityParam = entityType == CLAEntityType.IPAddress ? entityValue : "--####--";

            var userEntityVal = entityType == CLAEntityType.User ? entityValue : ".";
            var machineEntityVal = entityType == CLAEntityType.Machine ? entityValue : ".";
            var ipAddressEntityVal = entityType == CLAEntityType.IPAddress ? entityValue : ".";

            var lastSyncDetailsJson = await _reportService.GetLastPostedValuesForTroubleshootReporting(entityColName, entityValue);
            var userGroup = await _reportService.GetGroupMembershipsForTroubleshootReporting(entityValue, entitySymbol); 
            var activeContentJson = await _reportService.GetActivePopupsSurveysForTroubleshootReporting(userEntityParam, machineEntityParam, ipAddressEntityParam);
            var targetingJson = await _reportService.GetActiveTargetedContentForTroubleshootReporting(userEntityParam, machineEntityParam, ipAddressEntityParam);
            var settingsJson = await _reportService.GetSettingsForTroubleshootReporting(userEntityVal, machineEntityVal, ipAddressEntityVal);

            entity = APIResponseParserHelper.ParseJsonToObject<TroubleshootReportEntity>(entityJson, true);

            result.ConnectedToLive = entity == null;
            result.LastSyncDetails = APIResponseParserHelper.ParseJsonToObject<TroubleshootReportLastSyncDetails>(lastSyncDetailsJson, true);
            result.UserGroups = APIResponseParserHelper.ParseJsonToObject<List<TroubleshootReportUserGroup>>(userGroup);
            result.Targeting = APIResponseParserHelper.ParseJsonToObject<List<TroubleshootReportTargeting>>(targetingJson);
            result.Settings = APIResponseParserHelper.ParseJsonToObject<TroubleshootReportSettings>(settingsJson, true);
            

            return result;
        }
    }
}
