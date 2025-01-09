using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Helpers.Modules;
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
using System;

namespace CLA_Administration_Web.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;

        public SettingsController(ILogger<SettingsController> logger)
        {
            _logger = logger;
        }

        #region Stagingusers
        [HttpGet]
        public async Task<IActionResult> StagingUsers()
        {
            var stagingUsersData = new StagingUsersMainViewModel()
            {
                StagingUsers = SettingsMockData.StagingUsers,
                StagingMachines = SettingsMockData.StagingMachines
            };

            return PartialView(AppPagesLinks.Settings.StagingUsersPageLink, stagingUsersData);
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


            machine.MachineName = updatedMachine.MachineName;
            machine.MachineDescription = updatedMachine.MachineDescription;
            machine.UserLastModified = updatedMachine.UserLastModified;
            machine.MachineLastModified = updatedMachine.MachineLastModified;


            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SetupExclusions()
        {
            var setupExcludedData = new SetupExclusionsMainViewModel()
            {
                Users = SettingsMockData.SetupExcludedUsers,
                Machines = SettingsMockData.SetupExcludedMachines
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

        [HttpGet]

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
        public ActionResult EditAdminAccess(int adminID, string entityType = null)
        {

            var adminAccessData = new ManageAdminAccessMainViewModel()
            {
                AdminAccessItems = SettingsMockData.AdminAccess,

            };

            var data = adminAccessData.AdminAccessItems.FirstOrDefault(m => m.AdminID == adminID);
            //var adminAccessData = SettingsMockData.AdminAccess.FirstOrDefault(m => m.AdminID == adminID);

         


            if (data == null)
            {
                return NotFound($"{entityType} with ID {adminID} not found.");
            }

            return PartialView(AppPagesLinks.Settings.EditAdminModalPageLink, data);
        }

        #endregion  

        #region Target

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
        public ActionResult EditTargetGroups(int machineId, string entityType)
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
            else if (entityType == "Group")
            {
                
                selectedEntity = stagingUsersData.StagingUsers.FirstOrDefault(u => u.Id == machineId);
            }
            else if (entityType == "IPRanges")
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
        [HttpGet]
        public async Task<IActionResult> SkinsOfflineImages()
        {

            var skinsAndOfflineImageData = new SkinsAndOfflineImageMainViewModel()
            {
                SkinAndOfflineImage = SettingsMockData.SkinsAndOfflineImage,
                SkinOfflineCategortyTrees = SettingsMockData.AllSkinsOfflineImageCategories,

            };

            return PartialView(AppPagesLinks.Settings.SkinsOfflineImagesPageLink, skinsAndOfflineImageData);
        }

        public async Task<IActionResult> SkinsAndOfflineImageDetails(int customId)
        {
            //var categoryTreeVm = (customId != null && customId != 0) ? ModulesHelper.GetCategoryTreeStructure(SettingsMockData.AllContentLibraryCategories, customId) : new();
            var customVm = SettingsMockData.AllSkinsOfflineImageCategories.FirstOrDefault(x => x.CategoryId == customId);
            return PartialView(AppPagesLinks.Settings.SkinsOfflineImagesDetailsPageLink, customVm);
        }

        [HttpGet]
        public ActionResult EditSkinsAndOfflineImages(int machineId, string entityType)
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
