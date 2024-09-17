using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Layout;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.ViewModels.Modules;
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

                if (modulePage == ModulesPages.PopupOverview)
                {
                    var usersFilter = LocalDataStorage.AllPopupData.Select(x => x.UserIdLastModified).Distinct().ToList();

                    var filtersViewModel = new ModuleOverviewFilterViewModel
                    {
                        ModulePage = modulePage,
                        Usernames = usersFilter
                    };
                    return View("ModulesDataFilter", filtersViewModel);
                }
            }
            return View("Default");
        }
    }
}
