using CLA_Administration_Web.Helpers.Enums.Dashboard;
using CLA_Administration_Web.Helpers.Enums.Shared;

namespace CLA_Administration_Web.Helpers.Html
{
    public class LayoutHtmlHelpers
    {
        public static string GetModuleIcon(ModuleNamesType moduleNameType)
        {
            switch (moduleNameType)
            {
                case ModuleNamesType.LockedDesktop: return "bi bi-display-fill";
                case ModuleNamesType.Desktop: return "bi bi-file-lock2-fill";
                case ModuleNamesType.Screensaver: return "ri-computer-line";
                case ModuleNamesType.Popup: return "bi bi-chat-fill";
                case ModuleNamesType.Survey: return "bi bi-clipboard2-plus-fill";
                case ModuleNamesType.Ticker: return "ri-mac-fill";
                case ModuleNamesType.RSS: return "ri-rss-fill";
                default:return "";
            }
        }

        public static ModulesPages GetModuleSubOverviewPageForLeftNavigation(ModuleNamesType moduleNameType)
        {
            switch (moduleNameType)
            {
                case ModuleNamesType.LockedDesktop: return ModulesPages.LockedDesktopOverview;
                case ModuleNamesType.Desktop: return ModulesPages.DesktopOverview;
                case ModuleNamesType.Screensaver: return ModulesPages.ScreensaverOverview;
                case ModuleNamesType.Popup: return ModulesPages.PopupOverview;
                case ModuleNamesType.Survey: return ModulesPages.SurveyOverview;
                case ModuleNamesType.Ticker: return ModulesPages.TickerOverview;
                case ModuleNamesType.RSS: return ModulesPages.RSSOverview;
                default: return ModulesPages.None;
            }
        }

        public static ModulesPages GetModuleSubAddNewPageForLeftNavigation(ModuleNamesType moduleNameType)
        {
            switch (moduleNameType)
            {
                case ModuleNamesType.LockedDesktop: return ModulesPages.LockedDesktopAddNew;
                case ModuleNamesType.Desktop: return ModulesPages.DesktopAddNew;
                case ModuleNamesType.Screensaver: return ModulesPages.ScreensaverAddNew;
                case ModuleNamesType.Popup: return ModulesPages.PopupAddNew;
                case ModuleNamesType.Survey: return ModulesPages.SurveyAddNew;
                case ModuleNamesType.Ticker: return ModulesPages.TickerAddNew;
                case ModuleNamesType.RSS: return ModulesPages.RSSAddNew;
                default: return ModulesPages.None;
            }
        }
    }
}
