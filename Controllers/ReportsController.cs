using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.Enums.Reports;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Helpers.Reporting;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.Services.Reporting;
using CLA_Administration_Web.ViewModels.Reports;
using CLA_Administration_Web.ViewModels.Reports.CampaignDispatch;
using CLACommonFunctionsLibrary_NET.Helpers.Enums;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> SurveyReportOnly([FromQuery] ModuleReportDataFilterViewModel parameters, bool transponsed)
        {
            var surveyReportVm = await reportingHelper.GetSurveyReportsData(parameters, transponsed);
            LocalDataStorage.ReportsData.SurveyReportsData = surveyReportVm;

            if (parameters.ShowRawDataOnly)
            {
                var anyFirst = surveyReportVm.SurveyAllData.FirstOrDefault();
                var effectiveFrom = anyFirst?.EffFrom ?? DateTime.MinValue;
                var effectiveTo = anyFirst?.EffTo ?? DateTime.MinValue;

                var surveyRawData = new ModuleReportRawDataOnlyViewModel
                {
                    ReportNameType = ReportsNamesType.Survey,
                    ReportModuleId = parameters.ModuleId,
                    EffectiveFrom = effectiveFrom,
                    EffectiveTo = effectiveTo,
                    SurveyAllRawData = surveyReportVm.SurveyAllData
                };
                return PartialView(AppPagesLinks.Reports.ModuleRawDataPageLink, surveyRawData);
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
        public async Task<IActionResult> PopupReportOnly([FromQuery] ModuleReportDataFilterViewModel parameters)
        {
            var popupReportVm = await reportingHelper.LoadPopupReportsData(parameters);
            LocalDataStorage.ReportsData.PopupReportsData = popupReportVm;

            if (parameters.ShowRawDataOnly)
            {
                var anyFirst = popupReportVm.PopupReportAllData.FirstOrDefault();
                var effectiveFrom = anyFirst?.EffectiveFrom ?? DateTime.MinValue;
                var effectiveTo = anyFirst?.EffectiveTo ?? DateTime.MinValue;

                var popupRawData = new ModuleReportRawDataOnlyViewModel
                {
                    ReportNameType = ReportsNamesType.Popup,
                    ReportModuleId = parameters.ModuleId,
                    EffectiveFrom = effectiveFrom,
                    EffectiveTo = effectiveTo,
                    PopupAllRawData = popupReportVm.PopupReportAllData
                };
                return PartialView(AppPagesLinks.Reports.ModuleRawDataPageLink, popupRawData);
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
        public async Task<IActionResult> TickerReportOnly([FromQuery] ModuleReportDataFilterViewModel parameters)
        {
            var tickerReportVm = await reportingHelper.LoadTickerReportsData(parameters);
            LocalDataStorage.ReportsData.TickersReportsData = tickerReportVm;

            if (parameters.ShowRawDataOnly)
            {
                var anyFirst = tickerReportVm.TickerReportAllData.FirstOrDefault();
                var effectiveFrom = anyFirst?.EffectiveFrom ?? DateTime.MinValue;
                var effectiveTo = anyFirst?.EffectiveTo ?? DateTime.MinValue;

                var tickerRawData = new ModuleReportRawDataOnlyViewModel
                {
                    ReportNameType = ReportsNamesType.Ticker,
                    ReportModuleId = parameters.ModuleId,
                    EffectiveFrom = effectiveFrom,
                    EffectiveTo = effectiveTo,
                    TickerAllRawData = tickerReportVm.TickerReportAllData
                };
                return PartialView(AppPagesLinks.Reports.ModuleRawDataPageLink, tickerRawData);
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
        public async Task<IActionResult> PolicyReportOnly([FromQuery] ModuleReportDataFilterViewModel parameters, PolicyReportEntityType policyReportEntityType)
        {
            var policyReportVm = await reportingHelper.GetPolicyReportData(parameters, policyReportEntityType);
            LocalDataStorage.ReportsData.PolicyReportsData = policyReportVm;

            if (parameters.ShowRawDataOnly)
            {
                return PartialView(AppPagesLinks.Reports.PolicyReportRawDataPageLink, policyReportVm);
            }

            return PartialView(AppPagesLinks.Reports.PolicyReportOnlyPageLink, policyReportVm);
        }

        #endregion

        #region Active Users Machines

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
        public async Task<IActionResult> ActiveUsersMachinesReport([FromQuery] ModuleReportDataFilterViewModel parameters, ReportsNamesType reportName)
        {
            var activeUserMachineReportVm = await reportingHelper.LoadActiveUserMachineReport(parameters, reportName);

            return PartialView(AppPagesLinks.Reports.ActiveUserMachineTablePageLink, activeUserMachineReportVm);
        }

        #endregion

        #region Campaign Dispatch

        [HttpGet]
        public async Task<IActionResult> CampaignDispatchReport()
        {
            return PartialView(AppPagesLinks.Reports.CampaignDispatchPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> CampaignDispatchListReport([FromQuery] CampaignDispatchFiltersViewModel parameters)
        {
            var campaignDispatchReportVm = await reportingHelper.LoadCampaignDispatchReports(parameters);

            return PartialView(AppPagesLinks.Reports.CampaignDispatchListPageLink, campaignDispatchReportVm);
        }

        #endregion

        #region Troubleshoot

        [HttpGet]
        public async Task<IActionResult> TroubleshootReport()
        {
            return PartialView(AppPagesLinks.Reports.TroubleshootPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> TroubleshootReportData(CLAEntityType entityType, string entityValue)
        {
            var troubleshootVm = new TroubleshootReportViewModel();
            if (entityType != CLAEntityType.None)
            {
                troubleshootVm = await reportingHelper.GetTroubleshootReportData(entityType, entityValue);
            }
            else
            {
                troubleshootVm.IsBlank = true;
            }
            return PartialView(AppPagesLinks.Reports.TroubleshootDataPageLink, troubleshootVm);
        }

        #endregion

        public async Task<IActionResult> ExportFileToExcel(ReportsNamesType reportType, ModuleReportDataFilterViewModel parameters, string reportPageName, CLAEntityType entityType,
                                                           string entityValue, CampaignDispatchFiltersViewModel dispatchParams, string policyTargetType, bool surveyTransponsed)
        {
            var filename = "";
            using (var workbook = new XLWorkbook())
            {
                if (reportType == ReportsNamesType.Popup)
                {
                    var data = await reportingHelper.GetPopupReportsForExport(parameters);
                    var summaryData = LocalDataStorage.ReportsData.PopupReportsData.PopupReportSummary;

                    ExportHelper.ExportPopupReport(workbook, reportPageName, data);
                    filename = ExportHelper.GetReportFilename(ReportsNamesType.Popup, reportPageName, summaryData.PopupId, summaryData.Title);
                }
                else if (reportType == ReportsNamesType.Survey)
                {
                    if (!surveyTransponsed)
                    {
                        var data = await reportingHelper.GetSurveyReportsForExport(parameters);
                        var summaryData = LocalDataStorage.ReportsData.SurveyReportsData.SurveySummary;

                        ExportHelper.ExportSurveyReport(workbook, reportPageName, data);
                        filename = ExportHelper.GetReportFilename(ReportsNamesType.Survey, reportPageName, summaryData.SurveyId, summaryData.SurveyTitle);
                    }
                    else
                    {
                        var data2 = await reportingHelper.GetSurveyReportsData(parameters, surveyTransponsed);

                        var title = data2.SurveySummary.SurveyTitle;
                        var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                        ExportHelper.ExportSurveyTransposedData(workbook, data2);
                        filename = $"Survey_Report_{title}_{timestamp}.xlsx";
                    }

                }
                else if (reportType == ReportsNamesType.Ticker)
                {
                    var data = await reportingHelper.GetTickerReports(parameters);
                    var summaryData = LocalDataStorage.ReportsData.TickersReportsData.TickerReportSummary;

                    ExportHelper.ExportTickerReport(workbook, reportPageName, data);
                    filename = ExportHelper.GetReportFilename(ReportsNamesType.Ticker, reportPageName, summaryData.TickerId, summaryData.TickerText);
                }
                else if (reportType == ReportsNamesType.Policy)
                {
                    var data = await reportingHelper.GetPolicyReports(parameters);
                    var summaryData = LocalDataStorage.ReportsData.TickersReportsData.TickerReportSummary;

                    ExportHelper.ExportPolicyReport(workbook, reportPageName, data, policyTargetType);
                    filename = (reportPageName == "all") ? "rptPolicy.xlsx" : $"rptPolicy-{reportPageName}.xlsx";
                }
                else if (reportType == ReportsNamesType.ActiveUsers || reportType == ReportsNamesType.ActiveMachines)
                {
                    var data = await reportingHelper.GetActiveUsersReport(parameters, reportType);
                    var status = reportingHelper.GetStatusReport(parameters);

                    ExportHelper.ExportActiveUsersReport(workbook, reportType.GetDisplayDescription(), data, status);
                    filename = ExportHelper.GetReportFilename(reportType, reportPageName, 0, "");
                }
                else if (reportType == ReportsNamesType.CampaignDispatch)
                {
                    var data = await reportingHelper.GetCampaignDispatchListReporting(dispatchParams);

                    ExportHelper.ExportCampaignDispatchReport(workbook, data, dispatchParams);

                    filename = "rptDispatch_Listings.xlsx";
                }
                else if (reportType == ReportsNamesType.Troubleshoot)
                {
                    var troubleshootVm = await reportingHelper.GetTroubleshootReportData(entityType, entityValue);

                    ExportHelper.ExportTroubleshootReport(workbook, troubleshootVm);
                    filename = "rptTroubleshoot.xlsx";
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
