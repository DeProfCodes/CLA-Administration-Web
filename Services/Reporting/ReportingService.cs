using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Services.API;
using CLA_Administration_Web.ViewModels.API.Reports;
using CLA_Administration_Web.ViewModels.Modules.ContentLibrary;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLA_Administration_Web.ViewModels.Modules.Rss;
using CLA_Administration_Web.ViewModels.Reports.CampaignDispatch;
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
                             ((reportName == ReportsNamesType.ActiveMachines) ? "GetReportingActiveMachines" : "");

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

        public async Task<string> GetCampaignDispatchReport(CampaignDispatchFiltersViewModel parameters, string report)
        {
            try
            {
                var endpoint = $"{apiControllerName}/GetReportingExecutorDispatchListing?report={report}&effectiveFrom={parameters.StartDate}&effectiveTo={parameters.EndDate}&isAutomated={parameters.IsAutomated}&connectToLive=false";

                var apiResponse = await _webApi.HttpGetAsync(endpoint);

                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetReportingDispatchListingParams(string startDate, string endDate, int isAutomated)
        {
            var endpoint = $"{apiControllerName}/GetReportingDispatchListingParams?effectiveFrom={startDate}&effectiveTo={endDate}&isAutomated={isAutomated}" +
                                                 $"&displayScreenSaver=1&displayDesktop=1&displayLockscreen=1&displayPopup=1&displaySurvey=1&displayTicker=1&connectToLive=false";

            var apiResponse = await _webApi.HttpGetAsync(endpoint);

            return apiResponse;
        }

        public async Task<string> GetNTUsernameForTroubleshootReporting(string entityValue)
        {
            try
            {
                var endpoint = $"{apiControllerName}/GetNTUsernameForTroubleshootReporting?userMachineIPAddress={entityValue}&connectToLive=false";

                var apiResponse = await _webApi.HttpGetAsync(endpoint);

                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetMachineNameForTroubleshootReporting(string entityValue)
        {
            try
            {
                var endpoint = $"{apiControllerName}/GetMachineNameForTroubleshootReporting?userMachineIPAddress={entityValue}&connectToLive=false";

                var apiResponse = await _webApi.HttpGetAsync(endpoint);

                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetLastPostedValuesForTroubleshootReporting(string entityColName, string entityValue)
        {
            try
            {
                var endpoint = $"{apiControllerName}/GetLastPostedValuesForTroubleshootReporting?field={entityColName}&value={entityValue}";

                var apiResponse = await _webApi.HttpGetAsync(endpoint);

                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetGroupMembershipsForTroubleshootReporting(string entityValue, string entitySymbol)
        {
            try
            {
                var endpoint = $"{apiControllerName}/GetGroupMembershipsForTroubleshootReporting?userMachineIPAddress={entityValue}&userMachineIPAddressSelection={entitySymbol}&connectToLive=false";

                var apiResponse = await _webApi.HttpGetAsync(endpoint);

                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetActivePopupsSurveysForTroubleshootReporting(string user, string machine, string ipAddress)
        {
            var endpoint = $"{apiControllerName}/GetActivePopupsSurveysForTroubleshootReporting?umipUser={user}&umipMachine={machine}&umipIP={ipAddress}&connectToLive=false";

            var apiResponse = await _webApi.HttpGetAsync(endpoint);

            return apiResponse;
        }

        public async Task<string> GetActiveTargetedContentForTroubleshootReporting(string user, string machine, string ipAddress)
        {
            var endpoint = $"{apiControllerName}/GetActiveTargetedContentForTroubleshootReporting?umipUser={user}&umipMachine={machine}&umipIP={ipAddress}&connectToLive=false";

            var apiResponse = await _webApi.HttpGetAsync(endpoint);

            return apiResponse;
        }

        public async Task<string> GetSettingsForTroubleshootReporting(string user, string machine, string ipAddress)
        {
            var endpoint = $"{apiControllerName}/GetSettingsForTroubleshootReporting?providerId={6}&userIdQuery={user}&machineIdQuery={machine}&ipAddressQuery={ipAddress}&connectToLive=false";

            var apiResponse = await _webApi.HttpGetAsync(endpoint);

            return apiResponse;
        }
    }
}
