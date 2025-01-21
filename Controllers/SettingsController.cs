using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Helpers.Modules;
using CLA_Administration_Web.Helpers.Targeting;
using CLA_Administration_Web.Models.APIResponses.Reports.Troubleshoot;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.ViewModels.Settings.ActiveConnections;
using CLA_Administration_Web.ViewModels.Settings.CustomUser;
using CLA_Administration_Web.ViewModels.Settings.DefaultFonts;
using CLA_Administration_Web.ViewModels.Settings.DesktopInformation;
using CLA_Administration_Web.ViewModels.Settings.ManageAdminAccess;
using CLA_Administration_Web.ViewModels.Settings.SetupExclusion;
using CLA_Administration_Web.ViewModels.Settings.Shared;
using CLA_Administration_Web.ViewModels.Settings.SkinAndOfflineImage;
using CLA_Administration_Web.ViewModels.Settings.StagingUsers;


using CLA_Administration_Web.ViewModels.Targeting;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Reflection.PortableExecutable;

namespace CLA_Administration_Web.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;

        public SettingsController(ILogger<SettingsController> logger)
        {
            _logger = logger;
        }



        public ActionResult Index()
        {
            return View();
        }

        #region StagingUsers
        [HttpGet]
        public async Task<IActionResult> StagingUsers()
        {
            var targetingTree = TargetingHelper.GetTargetedEntities();
            var targetingSelect = TargetingHelper.GetTargetedEntitiesSelect();

            var stagingUsersData = new StagingUsersMainViewModel()
            {
                StagingUsers = SettingsMockData.StagingUsers,
                StagingMachines = SettingsMockData.StagingMachines,
                // ModuleName = moduleName,
                TargetedEntities = targetingTree,
                TargetedAccepted = targetingSelect,
                TargetedGroups = targetingSelect,
            };

            return PartialView(AppPagesLinks.Settings.StagingUsersPageLink, stagingUsersData);
        }

        [HttpGet]
        public async Task<IActionResult> SearchOrFetchAllUsers(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                var allUsers = SettingsMockData.StagingUsers;
                return Json(allUsers);
            }
            else
            {
                var users = SettingsMockData.StagingUsers
                            .Where(u => u.Username.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                            .ToList();

                if (users.Any())
                {
                    return Json(users);
                }
            }

            return Json(new List<StagingUserMachineViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> SearchOrFetchAllMachines(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                var allMachines = SettingsMockData.StagingMachines;
                return Json(allMachines);
            }
            else
            {
                var machines = SettingsMockData.StagingMachines
                            .Where(m => m.MachineName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                            .ToList();

                if (machines.Any())
                {
                    return Json(machines);
                }
            }

            return Json(new List<StagingUserMachineViewModel>()); 
        }


        [HttpGet]
        public ActionResult EditStagingMachine(int machineId, string entityType)
        {
            var stagingUsersData = new StagingUsersMainViewModel()
            {
                StagingUsers = SettingsMockData.StagingUsers,
                StagingMachines = SettingsMockData.StagingMachines
            };

            object selectedEntity = null;

            if (entityType == "Machine")
            {
                selectedEntity = stagingUsersData.StagingMachines.FirstOrDefault(m => m.Id == machineId);
            }
            else if (entityType == "User")
            {
                selectedEntity = stagingUsersData.StagingUsers.FirstOrDefault(u => u.Id == machineId);
            }

            if (selectedEntity == null)
            {
                return NotFound($"{entityType} with ID {machineId} not found.");
            }

            ViewBag.EntityType = entityType;
            return PartialView(AppPagesLinks.Settings.StagingModalViewPageLink, selectedEntity);
        }

        [HttpGet]
        public ActionResult EditSetupExclusions(int machineId, string entityType)
        {
            var setupExcludedData = new SetupExclusionsMainViewModel()
            {
                Users = SettingsMockData.SetupExcludedUsers,
                Machines = SettingsMockData.SetupExcludedMachines
            };

            object selectedEntity = null;

            if (entityType == "Machine")
            {
                selectedEntity = setupExcludedData.Machines.FirstOrDefault(m => m.Id == machineId);
            }
            else if (entityType == "User")
            {
                selectedEntity = setupExcludedData.Users.FirstOrDefault(u => u.Id == machineId);
            }

            if (selectedEntity == null)
            {
                return NotFound($"{entityType} with ID {machineId} not found.");
            }

            ViewBag.EntityType = entityType;
            return PartialView(AppPagesLinks.Settings.SetupExclusionModalPageLink, selectedEntity);
        }

        [HttpPost]
        public ActionResult UpdateStagingMachine(StagingUserMachineViewModel updatedMachine)
        {
            var machine = LocalDataStorage.StagingData.SingleStagingMachine.FirstOrDefault(m => m.Id == updatedMachine.Id);

            if (machine != null)
            {
                machine.MachineName = updatedMachine.MachineName;
                machine.MachineDescription = updatedMachine.MachineDescription;
                machine.UserLastModified = updatedMachine.UserLastModified;
                machine.MachineLastModified = updatedMachine.MachineLastModified;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SetupExclusions()
        {
            var targetingTree = TargetingHelper.GetTargetedEntities();
            var targetingSelect = TargetingHelper.GetTargetedEntitiesSelect();
            var setupExcludedData = new SetupExclusionsMainViewModel()
            {
                Users = SettingsMockData.SetupExcludedUsers,
                Machines = SettingsMockData.SetupExcludedMachines,
                TargetedEntities = targetingTree,
                TargetedAccepted = targetingSelect,
                TargetedGroups = targetingSelect,
            };

            return PartialView(AppPagesLinks.Settings.SetupExclusionsPageLink, setupExcludedData);
        }

        [HttpGet]
        public ActionResult EditSetupExclusionss(int machineId, string entityType)
        {
            var setupExcludedData = new BaseSettingsViewModel()
            {
                Users = SettingsMockData.SetupExcludedUsers,
                Machines = SettingsMockData.SetupExcludedMachines
            };

            object selectedEntity = null;

            if (entityType == "Machine")
            {
                selectedEntity = setupExcludedData.Machines.FirstOrDefault(m => m.Id == machineId);
            }
            else if (entityType == "User")
            {
                selectedEntity = setupExcludedData.Users.FirstOrDefault(u => u.Id == machineId);
            }

            if (selectedEntity == null)
            {
                return NotFound($"{entityType} with ID {machineId} not found.");
            }

            ViewBag.EntityType = entityType;
            return PartialView(AppPagesLinks.Settings.EditAdminModalPageLink, selectedEntity);
        }
        #endregion


        #region Admin
        public async Task<IActionResult> AdminAccess()
        {

            var adminAccessData = new ManageAdminAccessMainViewModel()
            {
                AdminAccessItems = SettingsMockData.AdminAccess,
               
            };

            return PartialView(AppPagesLinks.Settings.AdminAccessPageLink, adminAccessData);
        }


        [HttpGet]
        public ActionResult EditAdminAccess(int adminID)
        {
            var adminAccessData = new ManageAdminAccessMainViewModel()
            {
                AdminAccessItems = SettingsMockData.AdminAccess,
            };

            var data = adminAccessData.AdminAccessItems.FirstOrDefault(m => m.AdminID == adminID);

            if (data == null)
            {
                return NotFound($"Admin with ID {adminID} not found.");
            }

            return PartialView(AppPagesLinks.Settings.EditAdminModalPageLink, data);
        }


        #endregion  

        #region TargetGroup

        [HttpGet]
        public async Task<IActionResult> TargetGroups()
        {
            var targetGroups = new TargetingExposureViewModel()
            {
                TargetedUsers = SettingsMockData.TargetGroupUsers,
                TargetedMachines = SettingsMockData.TargetedMachines,
                TargetedGroups = SettingsMockData.TargetedGroups,
                TargetedIPRanges = SettingsMockData.TargetedIPRanges
            };

            return PartialView(AppPagesLinks.Settings.TargetGroupsPageLink, targetGroups);
        }


        [HttpGet]
        public ActionResult EditTargetGroups(int targetId, string entityType)
        {
            var targetGroups = new TargetingExposureViewModel()
            {
                TargetedUsers = SettingsMockData.TargetGroupUsers,
                TargetedMachines = SettingsMockData.TargetedMachines,
                TargetedGroups = SettingsMockData.TargetedGroups,
                TargetedIPRanges = SettingsMockData.TargetedIPRanges
            };

            object selectedEntity = null;

            if (entityType == "User")
            {
                selectedEntity = targetGroups.TargetedUsers.FirstOrDefault(m => m.Id == targetId);
            }
            else if (entityType == "Machine")
            {
                selectedEntity = targetGroups.TargetedMachines.FirstOrDefault(u => u.machineId == targetId);
            }
            else if (entityType == "Groups")
            {
                selectedEntity = targetGroups.TargetedGroups.FirstOrDefault(u => u.GroupId == targetId);
            }
            else if (entityType == "IPRanges")
            {
                selectedEntity = targetGroups.TargetedIPRanges.FirstOrDefault(u => u.RangeId == targetId);
            }

            if (selectedEntity == null)
            {
                return NotFound($"{entityType} with ID {targetId} not found.");
            }

            ViewBag.EntityType = entityType;

            return PartialView(AppPagesLinks.Settings.TargeGroupEditModal, targetGroups);
        }


        #endregion

        #region  CustomUser
        [HttpGet]
        public async Task<IActionResult> CustomUserSettings()

        {
            var customUserData = new CustomUserMainViewModel()
            {
                IsBlank = false,
                CustomUsersSettings = SettingsMockData.CustomUserSettings,

                ConnectedToLive = true,

                LastSyncDetails = new TroubleshootReportLastSyncDetails(),
                UserGroups = new List<TroubleshootReportUserGroup>(),
                Targeting = new List<TroubleshootReportTargeting>(),
                Settings = new TroubleshootReportSettings()

            };
            return PartialView(AppPagesLinks.Settings.CustomUserSettingsPageLink, customUserData);
        }

        public async Task<IActionResult> CustomUserSettingsDetails(int customId)
        {

            var customVm = SettingsMockData.CustomUserSettings.FirstOrDefault(x => x.Id == customId);

            return PartialView(AppPagesLinks.Settings.CustomUserSettingsDetailsPageLink, customVm);
        }

        #endregion

        #region Defaults
        [HttpGet]
        public async Task<IActionResult> DefaultFonts()
        {
            var defaultFontsData = new DefaultFontMainViewModel
            {
                DefaultFonts = SettingsMockData.GetDefaultFontsData(),
                CustomFonts = SettingsMockData.GetFontSettings()
            };

            return PartialView(AppPagesLinks.Settings.DefaultFontsPageLink, defaultFontsData);
        }


        [HttpGet]
      public IActionResult DefaultFontsDetails(int subId)
            {
                var defaultFontsData = SettingsMockData.GetDefaultFontsData();

                var subheading = defaultFontsData
                    .SelectMany(df => df.SubHeadings)
                    .FirstOrDefault(sh => sh.SubId == subId);

                if (subheading == null)
                {
                    return NotFound("Subheading not found.");
                }

                return View("~/Views/Settings/DefaultFonts/DefaultFontsDetails.cshtml", subheading);
            }

  

        #endregion Defaults

        #region ActiveConnections
        [HttpGet]
        public async Task<IActionResult> ActiveConnections()
        {

            var connections = new ActiveConnectionsMainViewModel()
            {
                Connections = SettingsMockData.ActiveConnections,
            };

            return PartialView(AppPagesLinks.Settings.ActiveConnectionsPageLink, connections);
        }

        #endregion

        #region SkinsandOfflineImages
      
        public async Task<IActionResult> SkinsOfflineImages()
        {

            var skinsAndOfflineImageData = new SkinsAndOfflineImageMainViewModel()
            {
                SkinAndOfflineImage = SettingsMockData.SkinsAndOfflineImage,
                SkinOfflineCategortyTrees = SettingsMockData.AllSkinsOfflineImageCategories,

            };

            return PartialView(AppPagesLinks.Settings.SkinsOfflineImagesPageLink, skinsAndOfflineImageData);
        }


        [HttpGet]
        public async Task<IActionResult> EditSkinsAndOfflineImage(int CategoryId)
        {
        
            SkinOfflineCategortyTree FindSkinOfflineImageById(List<SkinOfflineCategortyTree> categories, int CategoryId)
            {
                foreach (var category in categories)
                {
                    if (category.CategoryId == CategoryId)
                    {
                        return category;
                    }

                    if (category._children != null && category._children.Any())
                    {
                        var found = FindSkinOfflineImageById(category._children, CategoryId);
                        if (found != null)
                        {
                            return found; 
                        }
                    }
                }

                return null;
            }

        
            var customVm = FindSkinOfflineImageById(SettingsMockData.AllSkinsOfflineImageCategories, CategoryId);

            if (customVm == null)
            {
                return NotFound(new { Message = "Category not found." });
            }

        
            var skinsAndOfflineImageData = new SkinsAndOfflineModel
            {
                Id = customVm.CategoryId,
                ItemPath = "path/to/item",
                ViewImagePath = "path/to/image",
                IsDefault = "No",
                Description = customVm.CategoryDescription,
                UserLastModified = customVm.UserLastModified,
                MachineLastModified = customVm.MachineLastModified,
                CategoryName = customVm.CategoryName,
                SkinOfflineCategortyTrees = new List<SkinOfflineCategortyTree>()
            };

         
            return PartialView(AppPagesLinks.Settings.SkinsOfflineImagesModalPageLink, skinsAndOfflineImageData);
        }


        [HttpGet]
     
        public async Task<IActionResult> SkinsAndOfflineImageDetails(int CategoryId)
        {
            SkinOfflineCategortyTree FindSkinOfflineImageById(
                List<SkinOfflineCategortyTree> categories,
                int id,
                ref string parentName,
                ref string grandparentName,
                ref string grandchildName)
            {
                foreach (var category in categories)
                {
                    if (category.CategoryId == id)
                    {
                        return category;
                    }

                    if (category._children != null && category._children.Any())
                    {
                        grandchildName = parentName;
                        grandparentName = parentName;
                        parentName = category.CategoryName;

                        var found = FindSkinOfflineImageById(category._children, id, ref parentName, ref grandparentName, ref grandchildName);
                        if (found != null)
                        {
                            return found;
                        }

                     
                        parentName = grandparentName;
                        grandparentName = grandchildName;
                        grandchildName = string.Empty;
                    }
                }

                return null;
            }

            string parentName = string.Empty;
            string grandparentName = string.Empty;
            string grandchildName = string.Empty;

            var customVm = FindSkinOfflineImageById(SettingsMockData.AllSkinsOfflineImageCategories, CategoryId, ref parentName, ref grandparentName, ref grandchildName);

            var model = new SkinsAndOfflineModel
            {
                Id = customVm?.CategoryId ?? 0,
                ItemPath = "path/to/item",
                ViewImagePath = "path/to/image",
                IsDefault = "No",
                Description = customVm?.CategoryDescription ?? "",
                UserLastModified = customVm?.UserLastModified ?? "",
                MachineLastModified = customVm?.MachineLastModified ?? "",
                CategoryName = customVm?.CategoryName ?? "",
                SkinOfflineCategortyTrees = customVm?._children ?? new List<SkinOfflineCategortyTree>()
            };

            ViewBag.ParentCategoryName = parentName;
            ViewBag.GrandparentCategoryName = grandparentName;
            ViewBag.GrandchildCategoryName = grandchildName;

            return PartialView(AppPagesLinks.Settings.SkinsOfflineImagesDetailsPageLink, model);
        }

        #endregion

        #region Desktopinfo
        [HttpGet]
        public async Task<IActionResult> DesktopInformation()
        {
            var desktopData = new DesktopInformantionMainModel()
            {
                positions = SettingsMockData.DesktopPosition,
         

            };

            return PartialView(AppPagesLinks.Settings.DesktopInformationPageLink, desktopData);
        }

        #endregion


    }

}
