using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Layout;
using Microsoft.AspNetCore.Mvc;

namespace CLA_Administration_Web.ViewComponents.Modules
{
    [ViewComponent(Name = "Breadcrumbs")]
    public class BreadcrumbsViewComponent : ViewComponent
    {
        public BreadcrumbsViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(Enum page, int itemId = 0)
        {
            if (page is ModulesPages)
            {
                var modulePage = (ModulesPages)page;

                var breadcrumbViewModel = BreadcrumbsHelper.GetModuleBreadcrumbData(modulePage, itemId);

                return View("ModuleBreadcrumbs", breadcrumbViewModel);
            }
            return View("Default");
        }
    }
}
