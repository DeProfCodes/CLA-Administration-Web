using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.ViewModels.API.Reports;
using CLA_Administration_Web.ViewModels.Modules.ContentLibrary;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLA_Administration_Web.ViewModels.Modules.Rss;

namespace CLA_Administration_Web.Services.Reporting
{
    public interface IReportingService
    {
        #region Module

        public Task<string> GetModuleListForReporting(ReportsNamesType reportNameType, string effectiveFrom, string effectiveTo, int isAutomated = 0, bool connectToLive = false);

        public Task<string> GetModuleSummaryReport(ModuleSummaryParamsViewModel popupParams, ReportsNamesType reportNameType, string reportType);

        #endregion

        #region Active Users Machines

        public Task<string> GetActiveUsersMachinesReport(ModuleSummaryParamsViewModel parameters, ReportsNamesType reportName);

        #endregion
    }
}
