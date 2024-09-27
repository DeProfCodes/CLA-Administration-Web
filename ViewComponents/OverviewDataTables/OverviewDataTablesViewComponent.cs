using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Layout;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.ViewModels.Modules;
using CLACommonFunctionsLibrary_NET.Helpers.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CLA_Administration_Web.ViewComponents.OverviewDataFilters
{
    [ViewComponent(Name = "OverviewDataTables")]
    public class OverviewDataTablesViewComponent : ViewComponent
    {
        public OverviewDataTablesViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(Enum page)
        {
            if (page is ModulesPages)
            {
                var modulePage = (ModulesPages) page;

                if (modulePage == ModulesPages.PopupOverview || modulePage == ModulesPages.TickerOverview || modulePage == ModulesPages.SurveyOverview || modulePage == ModulesPages.RSSCategoryOverview)
                {
                    return View("ModulesOverviewDataTablePST", modulePage);
                }
                else if (modulePage == ModulesPages.LockedDesktopOverview || modulePage == ModulesPages.DesktopOverview || modulePage == ModulesPages.ScreensaverOverview)
                {
                    return View("ModulesOverviewDataTableLDS", modulePage);
                }
            }
            return View("Default");
        }
    }
}
