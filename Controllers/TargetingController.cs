using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Helpers.Targeting;
using CLA_Administration_Web.ViewModels.Targeting;
using Microsoft.AspNetCore.Mvc;

namespace CLA_Administration_Web.Controllers
{
    public class TargetingController : Controller
    {
        private readonly ILogger<TargetingController> _logger;

        public TargetingController(ILogger<TargetingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> TargetedEntities(ModuleNamesType moduleName)
        {
            var targetingTree = TargetingHelper.GetTargetedEntities();
            var targetingSelect = TargetingHelper.GetTargetedEntitiesSelect();

            var targetedEntityVm = new TargetedEntityViewModel
            {
                ModuleName = moduleName,
                TargetedEntities = targetingTree,
                TargetedAccepted = targetingSelect,
                TargetedGroups = targetingSelect
            };

            return PartialView(AppPagesLinks.Targeting.TargetedEntityPSTPageLink, targetedEntityVm);
        }

    }
}
 