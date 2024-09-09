using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.ViewModels.Layouts;

namespace CLA_Administration_Web.Helpers.Layout
{
    public class LayoutsHelper
    {
        public static List<ModulesLeftNavigationViewModel> GetModuleNamesAndPages()
        {
            var whiteModuleIcons = "/images/icons/white/modules";
            var blueModuleIcons = "/images/icons/blue/modules";

            var modulesList = new List<ModulesLeftNavigationViewModel>
            {
                new ModulesLeftNavigationViewModel
                {
                    ModuleName = ModuleNamesType.ContentLibrary,
                    OverviewPage = ModulesPages.ContentLibraryCategories,
                    AddNewPage = ModulesPages.ContentLibraryContent,
                    IconWhiteUrl = $"{whiteModuleIcons}/content-library.png",
                    IconBlueUrl = $"{blueModuleIcons}/content-library.png"
                },
                new ModulesLeftNavigationViewModel
                {
                    ModuleName = ModuleNamesType.LockedDesktop,
                    OverviewPage = ModulesPages.LockedDesktopOverview,
                    AddNewPage = ModulesPages.LockedDesktopAddNew,
                    IconWhiteUrl = $"{whiteModuleIcons}/lockscreen.png",
                    IconBlueUrl = $"{blueModuleIcons}/lockscreen.png"
                },
                new ModulesLeftNavigationViewModel
                {
                    ModuleName = ModuleNamesType.Desktop,
                    OverviewPage = ModulesPages.DesktopOverview,
                    AddNewPage = ModulesPages.DesktopAddNew,
                    IconWhiteUrl = $"{whiteModuleIcons}/desktop.png",
                    IconBlueUrl = $"{blueModuleIcons}/desktop.png"
                },
                new ModulesLeftNavigationViewModel
                {
                    ModuleName = ModuleNamesType.Screensaver,
                    OverviewPage = ModulesPages.ScreensaverOverview,
                    AddNewPage = ModulesPages.ScreensaverAddNew,
                    IconWhiteUrl = $"{whiteModuleIcons}/screensaver.png",
                    IconBlueUrl = $"{blueModuleIcons}/screensaver.png"
                },
                new ModulesLeftNavigationViewModel
                {
                    ModuleName = ModuleNamesType.Popup,
                    OverviewPage = ModulesPages.PopupOverview,
                    AddNewPage = ModulesPages.PopupAddNew,
                    IconWhiteUrl = $"{whiteModuleIcons}/popup.png",
                    IconBlueUrl = $"{blueModuleIcons}/popup.png"
                },
                new ModulesLeftNavigationViewModel
                {
                    ModuleName = ModuleNamesType.Survey,
                    OverviewPage = ModulesPages.SurveyOverview,
                    AddNewPage = ModulesPages.SurveyAddNew,
                    IconWhiteUrl = $"{whiteModuleIcons}/survey.png",
                    IconBlueUrl = $"{blueModuleIcons}/survey.png"
                },
                new ModulesLeftNavigationViewModel
                {
                    ModuleName = ModuleNamesType.Ticker,
                    OverviewPage = ModulesPages.TickerOverview,
                    AddNewPage = ModulesPages.TickerAddNew,
                    IconWhiteUrl = $"{whiteModuleIcons}/ticker.png",
                    IconBlueUrl = $"{blueModuleIcons}/ticker.png"
                },
                new ModulesLeftNavigationViewModel
                {
                    ModuleName = ModuleNamesType.RSS,
                    OverviewPage = ModulesPages.RSSOverview,
                    AddNewPage = ModulesPages.RSSAddNew,
                    IconWhiteUrl = $"{whiteModuleIcons}/rss.png",
                    IconBlueUrl = $"{blueModuleIcons}/rss.png"
                }
            };
            return modulesList;
        }

        public static List<SettingsLeftNavigationViewModel> GetSettingsNamesTypes()
        {
            var whiteSettingsIcons = "/images/icons/white/settings";
            var blueSettingsIcons = "/images/icons/blue/settings";

            var settingsList = new List<SettingsLeftNavigationViewModel>
            {
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.StagingUsers,
                    IconWhiteUrl = $"{whiteSettingsIcons}/staging-users.png",
                    IconBlueUrl = $"{blueSettingsIcons}/staging-users.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.SetupExlusions,
                    IconWhiteUrl = $"{whiteSettingsIcons}/setup-exclusions.png",
                    IconBlueUrl = $"{blueSettingsIcons}/setup-exclusions.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.AdminAccess,
                    IconWhiteUrl = $"{whiteSettingsIcons}/admin-access.png",
                    IconBlueUrl = $"{blueSettingsIcons}/admin-access.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.TargetGroups,
                    IconWhiteUrl = $"{whiteSettingsIcons}/rebuild-targeted-groups.png",
                    IconBlueUrl = $"{blueSettingsIcons}/rebuild-targeted-groups.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.CustomUserSettings,
                    IconWhiteUrl = $"{whiteSettingsIcons}/custom-user.png",
                    IconBlueUrl = $"{blueSettingsIcons}/custom-user.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.ActiveConnections,
                    IconWhiteUrl = $"{whiteSettingsIcons}/active-connections.png",
                    IconBlueUrl = $"{blueSettingsIcons}/active-connections.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.SkinsOfflineImages,
                    IconWhiteUrl = $"{whiteSettingsIcons}/skins-offline-images.png",
                    IconBlueUrl = $"{blueSettingsIcons}/skins-offline-images.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.DesktopInformation,
                    IconWhiteUrl = $"{whiteSettingsIcons}/desktop-information.png",
                    IconBlueUrl = $"{blueSettingsIcons}/desktop-information.png"
                }
            };
            return settingsList;
        }

        public static List<ReportsLeftNavigationViewModel> GetReportsNamesTypes()
        {
            var whiteReportsIcons = "/images/icons/white/reports";
            var blueReportsIcons = "/images/icons/blue/reports";

            var reportsList = new List<ReportsLeftNavigationViewModel>
            {
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.Survey,
                    IconWhiteUrl = $"{whiteReportsIcons}/survey.png",
                    IconBlueUrl = $"{blueReportsIcons}/survey.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.Popup,
                    IconWhiteUrl = $"{whiteReportsIcons}/popup.png",
                    IconBlueUrl = $"{blueReportsIcons}/popup.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.Ticker,
                    IconWhiteUrl = $"{whiteReportsIcons}/ticker.png",
                    IconBlueUrl = $"{blueReportsIcons}/ticker.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.Policy,
                    IconWhiteUrl = $"{whiteReportsIcons}/policy.png",
                    IconBlueUrl = $"{blueReportsIcons}/policy.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.ActiveUsers,
                    IconWhiteUrl = $"{whiteReportsIcons}/active-users.png",
                    IconBlueUrl = $"{blueReportsIcons}/active-users.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.ActiveMachines,
                    IconWhiteUrl = $"{whiteReportsIcons}/active-machines.png",
                    IconBlueUrl = $"{blueReportsIcons}/active-machines.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.CampaignDispatch,
                    IconWhiteUrl = $"{whiteReportsIcons}/campaign-dispatch.png",
                    IconBlueUrl = $"{blueReportsIcons}/campaign-dispatch.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.Troubleshoot,
                    IconWhiteUrl = $"{whiteReportsIcons}/troubleshoot.png",
                    IconBlueUrl = $"{blueReportsIcons}/troubleshoot.png"
                }
            };
            return reportsList;
        }
    }
}
