using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Layout;
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

                var filtersViewModel = new ModuleOverviewFilterViewModel
                {
                    ModuleName = modulePage.GetDisplayShortName(),
                    Usernames = new List<string> { "NdhuvaziM", "BertusB", "LeboC" }
                };

                return View("ModulesDataFilter", filtersViewModel);
            }
            return View("Default");
        }
    }
}
