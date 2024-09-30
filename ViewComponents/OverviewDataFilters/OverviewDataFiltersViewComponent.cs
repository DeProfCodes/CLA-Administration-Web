using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Layout;
using CLA_Administration_Web.Helpers.Modules;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.ViewModels.Modules;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLACommonFunctionsLibrary_NET.Helpers.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CLA_Administration_Web.ViewComponents.OverviewDataFilters
{
    [ViewComponent(Name = "OverviewDataFilters")]
    public class OverviewDataFiltersViewComponent : ViewComponent
    {
        public OverviewDataFiltersViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(Enum page)
        {
            if (page is ModulesPages)
            {
                var modulePage = (ModulesPages) page;

                var moduleNameType = ModulesHelper.GetModuleNameTypeFromModulePage(modulePage);

                var dataSource = LocalDataStorage.GetLocalModulePSTAllData(moduleNameType);
                var usersFilter = dataSource.Select(x => x.UserIdLastModified).Distinct().ToList();

                if (modulePage == ModulesPages.ScreensaverOverview || modulePage == ModulesPages.DesktopOverview || modulePage == ModulesPages.LockedDesktopOverview)
                {
                    var filtersViewModel = new ModuleLDSOverviewFilterViewModel
                    {
                        ModulePage = modulePage,
                        ModuleName = ModulesHelper.GetModuleNameTypeFromModulePage(modulePage),
                        MonthsAndYears = ModulesHelper.GetMonthsAndYears()
                    };
                    return View("ModulesDataFilterLDS", filtersViewModel);
                }
                else if (modulePage == ModulesPages.PopupOverview || modulePage == ModulesPages.TickerOverview || modulePage == ModulesPages.SurveyOverview ||
                         modulePage == ModulesPages.RSSCategoryOverview)
                {
                    var filtersViewModel = new ModulePSTOverviewFilterViewModel
                    {
                        ModulePage = modulePage,
                        Usernames = usersFilter
                    };
                    return View("ModulesDataFilterPST", filtersViewModel);
                }
            }
            return View("Default");
        }
    }
}
