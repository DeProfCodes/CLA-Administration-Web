using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Services.API;
using CLA_Administration_Web.ViewModels.API.Reports;
using CLA_Administration_Web.ViewModels.Modules.ContentLibrary;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLA_Administration_Web.ViewModels.Modules.Rss;
using CLACommonFunctionsLibrary_NET.Helpers.Enums;

namespace CLA_Administration_Web.Services.Reporting
{
    public class ReportingService : BaseService, IReportingService
    {
        public string apiControllerName { get; set; }

        public ReportingService(IApiService webApi) : base(webApi)
        {
            apiControllerName = "Reporting";
        }

        #region Modules 

        public async Task<string> GetModuleListForReporting(ReportsNamesType reportNameType, string effectiveFrom, string effectiveTo, int isAutomated = 0, bool connectToLive = false)
        {
            var endpoint = $"{apiControllerName}/GetModulesListForReporting?moduleName={reportNameType.GetDisplayName().ToLower()}&" +
                           $"effectiveFrom={effectiveFrom}&effectiveTo={effectiveTo}&isAutomated={isAutomated}&connectToLive={connectToLive}";

            var apiResponse = await _webApi.HttpGetAsync(endpoint);

            return apiResponse;
        }

        public async Task<string> GetModuleSummaryReport(ModuleSummaryParamsViewModel moduleParams, ReportsNamesType reportNameType, string reportType)
        {
            try
            {
                var endpoint = $"{apiControllerName}/GetModuleSummaryReport?moduleName={reportNameType.GetDisplayName().ToLower()}&report={reportType}" +
                               $"&moduleId={moduleParams.ModuleId}&useMachineId={moduleParams.UseMachineId}&showComplete={moduleParams.ShowComplete}" +
                               $"&showOutstanding={moduleParams.ShowOutstanding}&showActive={moduleParams.ShowActive}&environment={moduleParams.Environment}" +
                               $"&active={moduleParams.Active}&dormant={moduleParams.Dormant}&inactive={moduleParams.InActive}&connectToLive={moduleParams.ConnectToLive}";

                var apiResponse = await _webApi.HttpGetAsync(endpoint);

                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Active Users Machines

        public async Task<string> GetActiveUsersMachinesReport(ModuleSummaryParamsViewModel parameters, ReportsNamesType reportName)
        {
            try
            {
                var method = (reportName == ReportsNamesType.ActiveUsers) ? "GetReportingActiveUsers" : 
                             ((reportName == ReportsNamesType.ActiveMachines) ?  "GetReportingActiveMachines" : "");
                
                var endpoint = $"{apiControllerName}/{method}?&active={parameters.Active}&dormant={parameters.Dormant}&inactive={parameters.InActive}&connectToLive={parameters.ConnectToLive}";

                var apiResponse = await _webApi.HttpGetAsync(endpoint);

                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
