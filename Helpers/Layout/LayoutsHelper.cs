using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.ViewModels.Layouts;

namespace CLA_Administration_Web.Helpers.Layout
{
    public class LayoutsHelper
    {
        public static List<ModuleNameAndPagesViewModel> GetModuleNamesAndPages()
        {
            var whiteModuleIcons = "/images/icons/white";
            var blueModuleIcons = "/images/icons/blue";

            var modulesList = new List<ModuleNameAndPagesViewModel>
            {
                new ModuleNameAndPagesViewModel
                {
                    ModuleName = ModuleNamesType.ContentLibrary,
                    OverviewPage = ModulesPages.ContentLibraryCategories,
                    AddNewPage = ModulesPages.ContentLibraryContent,
                    IconWhiteUrl = $"{whiteModuleIcons}/content-library.png",
                    IconBlueUrl = $"{blueModuleIcons}/content-library.png"
                },
                new ModuleNameAndPagesViewModel
                {
                    ModuleName = ModuleNamesType.LockedDesktop,
                    OverviewPage = ModulesPages.LockedDesktopOverview,
                    AddNewPage = ModulesPages.LockedDesktopAddNew,
                    IconWhiteUrl = $"{whiteModuleIcons}/lockscreen.png",
                    IconBlueUrl = $"{blueModuleIcons}/lockscreen.png"
                },
                new ModuleNameAndPagesViewModel
                {
                    ModuleName = ModuleNamesType.Desktop,
                    OverviewPage = ModulesPages.DesktopOverview,
                    AddNewPage = ModulesPages.DesktopAddNew,
                    IconWhiteUrl = $"{whiteModuleIcons}/desktop.png",
                    IconBlueUrl = $"{blueModuleIcons}/desktop.png"
                },
                new ModuleNameAndPagesViewModel
                {
                    ModuleName = ModuleNamesType.Screensaver,
                    OverviewPage = ModulesPages.ScreensaverOverview,
                    AddNewPage = ModulesPages.ScreensaverAddNew,
                    IconWhiteUrl = $"{whiteModuleIcons}/screensaver.png",
                    IconBlueUrl = $"{blueModuleIcons}/screensaver.png"
                },
                new ModuleNameAndPagesViewModel
                {
                    ModuleName = ModuleNamesType.Popup,
                    OverviewPage = ModulesPages.PopupOverview,
                    AddNewPage = ModulesPages.PopupAddNew,
                    IconWhiteUrl = $"{whiteModuleIcons}/popup.png",
                    IconBlueUrl = $"{blueModuleIcons}/popup.png"
                },
                new ModuleNameAndPagesViewModel
                {
                    ModuleName = ModuleNamesType.Survey,
                    OverviewPage = ModulesPages.SurveyOverview,
                    AddNewPage = ModulesPages.SurveyAddNew,
                    IconWhiteUrl = $"{whiteModuleIcons}/survey.png",
                    IconBlueUrl = $"{blueModuleIcons}/survey.png"
                },
                new ModuleNameAndPagesViewModel
                {
                    ModuleName = ModuleNamesType.Ticker,
                    OverviewPage = ModulesPages.TickerOverview,
                    AddNewPage = ModulesPages.TickerAddNew,
                    IconWhiteUrl = $"{whiteModuleIcons}/ticker.png",
                    IconBlueUrl = $"{blueModuleIcons}/ticker.png"
                },
                new ModuleNameAndPagesViewModel
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

        public static List<SettingsNamesType> GetSettingsNamesTypes()
        {
            var settingsList = new List<SettingsNamesType>
            {
                SettingsNamesType.StagingUsers, SettingsNamesType.SetupExlusions, SettingsNamesType.AdminAccess, SettingsNamesType.TargetGroups, SettingsNamesType.CustomUserSettings,
                SettingsNamesType.ActiveConnections, SettingsNamesType.SkinsOfflineImages, SettingsNamesType.DesktopInformation
            };
            return settingsList;
        }
    }
}
