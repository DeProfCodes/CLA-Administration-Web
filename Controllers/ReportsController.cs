using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.Enums.Reports;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Helpers.Reporting;
using CLA_Administration_Web.Services.Reporting;
using CLA_Administration_Web.ViewModels.Reports;
using CLA_Administration_Web.ViewModels.Reports.CampaignDispatch;
using CLACommonFunctionsLibrary_NET.Helpers.Enums;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Spreadsheet;
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
            var surveyReportVm = await reportingHelper.GetSurveyReportsData(parameters);

            if (parameters.ShowRawDataOnly)
            {
                return PartialView(AppPagesLinks.Reports.ModuleRawDataPageLink, surveyReportVm);
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
        public async Task<IActionResult> PolicyReportOnly([FromQuery] ModuleReportDataFilterViewModel parameters, PolicyReportEntityType policyReportEntityType)
        {
            var policyReportVm = await reportingHelper.GetPolicyReportData(parameters, policyReportEntityType);

            if (parameters.ShowRawDataOnly)
            {
                return PartialView(AppPagesLinks.Reports.ModuleRawDataPageLink, policyReportVm);
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
        public async Task<IActionResult> ActiveUsersMachinesReport([FromQuery] ModuleReportDataFilterViewModel parameters, ReportsNamesType reportName)
        {
            var activeUserMachineReportVm = await reportingHelper.LoadActiveUserMachineReport(parameters, reportName);

            return PartialView(AppPagesLinks.Reports.ActiveUserMachineTablePageLink, activeUserMachineReportVm);
        }

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

        public async Task<IActionResult> ExportFileToExcel(ReportsNamesType reportType, ModuleReportDataFilterViewModel parameters, string reportPageName, CLAEntityType entityType, string entityValue, CampaignDispatchFiltersViewModel dispatchParams)
        {
            var filename = "";
            using (var workbook = new XLWorkbook())
            {
                if (reportType == ReportsNamesType.Popup)
                {
                    var data = await reportingHelper.GetPopupReportsForExport(parameters);

                    ExportHelper.ExportPopupReport(workbook, reportPageName, data);
                    filename = (reportPageName == "all") ? "rptPopup.xlsx" : $"rptPopup-{reportPageName}.xlsx";
                }
                else if (reportType == ReportsNamesType.Survey)
                {
                    var data = await reportingHelper.GetSurveyReportsForExport(parameters);

                    ExportHelper.ExportSurveyReport(workbook, reportPageName, data);
                    filename = (reportPageName == "all") ? "rptSurvey.xlsx" : $"rptSurvey-{reportPageName}.xlsx";
                }
                else if (reportType == ReportsNamesType.Ticker)
                {
                    var data = await reportingHelper.GetTickerReports(parameters);

                    ExportHelper.ExportTickerReport(workbook, reportPageName, data);
                    filename = (reportPageName == "all") ? "rptTicker.xlsx" : $"rptTicker-{reportPageName}.xlsx";
                }
                else if (reportType == ReportsNamesType.Policy)
                {
                    ExportHelper.ExportPolicyReport(workbook);
                    filename = "rptPolicy.xlsx";
                }
                else if (reportType == ReportsNamesType.ActiveUsers || reportType == ReportsNamesType.ActiveMachines)
                {
                    var data = await reportingHelper.GetActiveUsersReport(parameters, reportType);
                    var status = reportingHelper.GetStatusReport(parameters);

                    ExportHelper.ExportActiveUsersReport(workbook, reportType.GetDisplayDescription(), data, status);
                    filename = $"rpt{reportType.GetDisplayName()}.xlsx";
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

        [HttpPost]
        public IActionResult ExportFileToExcel2([FromBody] ReportExportViewModel exportData)
        {
            var content = $"<html><body>{exportData.HTMLData}</body></html>";
            var bytes = System.Text.Encoding.UTF8.GetBytes(content);

            return File(bytes, "application/vnd.ms-excel", "Report.xls");
        }

        public async Task<IActionResult> ExportTroubleshootReport(CLAEntityType entityType, string entityValue)
        {
            var troubleshootVm = await reportingHelper.GetTroubleshootReportData(entityType, entityValue);
            ExportHelper.GenerateCSV(troubleshootVm);

            return Ok();
        }
    }
}
 