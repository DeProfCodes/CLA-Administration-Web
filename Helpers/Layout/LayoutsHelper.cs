using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.ViewModels.Layouts;

namespace CLA_Administration_Web.Helpers.Layout
{
    public class LayoutsHelper
    {
        public static string WhiteIconsFolder = $"{LaunchSettingsHelper.GetBaseAddressForImages()}/images/icons/white";
        public static string BlueIconsFolder = $"{LaunchSettingsHelper.GetBaseAddressForImages()}/images/icons/blue";

        public static List<DashboardLeftNavigationViewModel> GetDashboardNamesTypes()
        {
            var whiteDashboardIcons = $"{WhiteIconsFolder}/dashboard";
            var blueDashboardIcons = $"{BlueIconsFolder}/dashboard";

            var dashboardList = new List<DashboardLeftNavigationViewModel>
            {
                new DashboardLeftNavigationViewModel
                {
                    DashboardName = DashboardNameTypes.Dashboard,
                    DashboardPage = DashboardPages.Dashboard,
                    IconWhiteUrl = $"{whiteDashboardIcons}/home.png",
                    IconBlueUrl = $"{blueDashboardIcons}/home.png"
                },
                new DashboardLeftNavigationViewModel
                {
                    DashboardName = DashboardNameTypes.Calendar,
                    DashboardPage = DashboardPages.Calendar,
                    IconWhiteUrl = $"{whiteDashboardIcons}/calendar.png",
                    IconBlueUrl = $"{blueDashboardIcons}/calendar.png"
                }
            };
            return dashboardList;
        }

        public static List<AdminLeftNavigationViewModel> GetAdminNamesTypes()
        {
            var whiteAdminIcons = $"{WhiteIconsFolder}/admin";
            var blueAdminIcons = $"{BlueIconsFolder}/admin";

            var settingsList = new List<AdminLeftNavigationViewModel>
            {
                new AdminLeftNavigationViewModel
                {
                    AdminName = AdminNamesTypes.UploadFiles,
                    AdminPage = AdminPages.UploadFiles,
                    IconWhiteUrl = $"{whiteAdminIcons}/upload-files.png",
                    IconBlueUrl = $"{blueAdminIcons}/upload-files.png"
                },
                new AdminLeftNavigationViewModel
                {
                    AdminName = AdminNamesTypes.ApplicationParameters,
                    AdminPage = AdminPages.ApplicationParameters,
                    IconWhiteUrl = $"{whiteAdminIcons}/application-parameters.png",
                    IconBlueUrl = $"{blueAdminIcons}/application-parameters.png"
                },
                new AdminLeftNavigationViewModel
                {
                    AdminName = AdminNamesTypes.Licensing,
                    AdminPage = AdminPages.Licensing,
                    IconWhiteUrl = $"{whiteAdminIcons}/licensing.png",
                    IconBlueUrl = $"{blueAdminIcons}/licensing.png"
                },
                new AdminLeftNavigationViewModel
                {
                    AdminName = AdminNamesTypes.SQLBrowser,
                    AdminPage = AdminPages.SQLBrowser,
                    IconWhiteUrl = $"{whiteAdminIcons}/sql-browser.png",
                    IconBlueUrl = $"{blueAdminIcons}/sql-browser.png"
                }
            };
            return settingsList;
        }

        public static List<ModulesLeftNavigationViewModel> GetModuleNamesAndPages()
        {
            var whiteModuleIcons = $"{WhiteIconsFolder}/modules";
            var blueModuleIcons = $"{BlueIconsFolder}/modules";

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
            var whiteSettingsIcons = $"{WhiteIconsFolder}/settings";
            var blueSettingsIcons = $"{BlueIconsFolder}/settings";

            var settingsList = new List<SettingsLeftNavigationViewModel>
            {
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.StagingUsers,
                    SettingsPage = SettingsPages.StagingUsers,
                    IconWhiteUrl = $"{whiteSettingsIcons}/staging-users.png",
                    IconBlueUrl = $"{blueSettingsIcons}/staging-users.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.SetupExlusions,
                    SettingsPage = SettingsPages.SetupExclusions,
                    IconWhiteUrl = $"{whiteSettingsIcons}/setup-exclusions.png",
                    IconBlueUrl = $"{blueSettingsIcons}/setup-exclusions.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.AdminAccess,
                    SettingsPage = SettingsPages.AdminAccess,
                    IconWhiteUrl = $"{whiteSettingsIcons}/admin-access.png",
                    IconBlueUrl = $"{blueSettingsIcons}/admin-access.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.TargetGroups,
                    SettingsPage = SettingsPages.TargetGroups,
                    IconWhiteUrl = $"{whiteSettingsIcons}/rebuild-targeted-groups.png",
                    IconBlueUrl = $"{blueSettingsIcons}/rebuild-targeted-groups.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.CustomUserSettings,
                    SettingsPage = SettingsPages.CustomUserSettings,
                    IconWhiteUrl = $"{whiteSettingsIcons}/custom-user.png",
                    IconBlueUrl = $"{blueSettingsIcons}/custom-user.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.ActiveConnections,
                    SettingsPage = SettingsPages.ActiveConnections,
                    IconWhiteUrl = $"{whiteSettingsIcons}/active-connections.png",
                    IconBlueUrl = $"{blueSettingsIcons}/active-connections.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.SkinsOfflineImages,
                    SettingsPage = SettingsPages.SkinsOfflineImages,
                    IconWhiteUrl = $"{whiteSettingsIcons}/skins-offline-images.png",
                    IconBlueUrl = $"{blueSettingsIcons}/skins-offline-images.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.DefaultFonts,
                    SettingsPage = SettingsPages.DefaultFonts,
                    IconWhiteUrl = $"{whiteSettingsIcons}/default-fonts.png",
                    IconBlueUrl = $"{blueSettingsIcons}/default-fonts.png"
                },
                new SettingsLeftNavigationViewModel
                {
                    SettingName = SettingsNamesType.DesktopInformation,
                    SettingsPage = SettingsPages.DesktopInformation,
                    IconWhiteUrl = $"{whiteSettingsIcons}/desktop-information.png",
                    IconBlueUrl = $"{blueSettingsIcons}/desktop-information.png"
                }
            };
            return settingsList;
        }

        public static List<ReportsLeftNavigationViewModel> GetReportsNamesTypes()
        {
            var whiteReportsIcons = $"{WhiteIconsFolder}/reports";
            var blueReportsIcons = $"{BlueIconsFolder}/reports";

            var reportsList = new List<ReportsLeftNavigationViewModel>
            {
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.Survey,
                    ReportPage = ReportsPages.Survey,
                    IconWhiteUrl = $"{whiteReportsIcons}/survey.png",
                    IconBlueUrl = $"{blueReportsIcons}/survey.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.Popup,
                    ReportPage = ReportsPages.Popup,
                    IconWhiteUrl = $"{whiteReportsIcons}/popup.png",
                    IconBlueUrl = $"{blueReportsIcons}/popup.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.Ticker,
                    ReportPage = ReportsPages.Ticker,
                    IconWhiteUrl = $"{whiteReportsIcons}/ticker.png",
                    IconBlueUrl = $"{blueReportsIcons}/ticker.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.Policy,
                    ReportPage = ReportsPages.Policy,
                    IconWhiteUrl = $"{whiteReportsIcons}/policy.png",
                    IconBlueUrl = $"{blueReportsIcons}/policy.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.ActiveUsers,
                    ReportPage = ReportsPages.ActiveUsers,
                    IconWhiteUrl = $"{whiteReportsIcons}/active-users.png",
                    IconBlueUrl = $"{blueReportsIcons}/active-users.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.ActiveMachines,
                    ReportPage = ReportsPages.ActiveMachines,
                    IconWhiteUrl = $"{whiteReportsIcons}/active-machines.png",
                    IconBlueUrl = $"{blueReportsIcons}/active-machines.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.CampaignDispatch,
                    ReportPage = ReportsPages.CampaignDispatch,
                    IconWhiteUrl = $"{whiteReportsIcons}/campaign-dispatch.png",
                    IconBlueUrl = $"{blueReportsIcons}/campaign-dispatch.png"
                },
                new ReportsLeftNavigationViewModel
                {
                    ReportName = ReportsNamesType.Troubleshoot,
                    ReportPage = ReportsPages.Troubleshoot,
                    IconWhiteUrl = $"{whiteReportsIcons}/troubleshoot.png",
                    IconBlueUrl = $"{blueReportsIcons}/troubleshoot.png"
                }
            };
            return reportsList;
        }

        public static List<SupportLeftNavigationViewModel> GetSupportNamesTypes()
        {
            var whiteSupportIcons = $"{WhiteIconsFolder}/support";
            var blueSupportIcons = $"{BlueIconsFolder}/support";

            var supportList = new List<SupportLeftNavigationViewModel>
            {
                new SupportLeftNavigationViewModel
                {
                    SupportName = SupportNamesType.AboutUs,
                    SupportPage = SupportPages.AboutUs,
                    IconWhiteUrl = $"{whiteSupportIcons}/about-us.png",
                    IconBlueUrl = $"{blueSupportIcons}/survey.png"
                },
                new SupportLeftNavigationViewModel
                {
                    SupportName = SupportNamesType.Tutorials,
                    SupportPage = SupportPages.Tutorials,
                    IconWhiteUrl = $"{whiteSupportIcons}/tutorials.png",
                    IconBlueUrl = $"{blueSupportIcons}/popup.png"
                },
                new SupportLeftNavigationViewModel
                {
                    SupportName = SupportNamesType.RemoteAssistance,
                    SupportPage = SupportPages.RemoteAssistance,
                    IconWhiteUrl = $"{whiteSupportIcons}/remote-assistance.png",
                    IconBlueUrl = $"{blueSupportIcons}/remote-assistance.png"
                },
                new SupportLeftNavigationViewModel
                {
                    SupportName = SupportNamesType.Contact,
                    SupportPage = SupportPages.ContactUs,
                    IconWhiteUrl = $"{whiteSupportIcons}/contact.png",
                    IconBlueUrl = $"{blueSupportIcons}/contact.png"
                },
                new SupportLeftNavigationViewModel
                {
                    SupportName = SupportNamesType.FAQ,
                    SupportPage = SupportPages.FAQ,
                    IconWhiteUrl = $"{whiteSupportIcons}/faq.png",
                    IconBlueUrl = $"{blueSupportIcons}/faq.png"
                }
            };
            return supportList;
        }

        public static List<AccountLeftNavigationViewModel> GetAccountNamesTypes()
        {
            var whiteAccountIcons = $"{WhiteIconsFolder}/account";
            var blueAccountIcons = $"{BlueIconsFolder}/account";

            var accountList = new List<AccountLeftNavigationViewModel>
            {
                new AccountLeftNavigationViewModel
                {
                    AccountName = AccountNamesType.AccountOverview,
                    AccountPage = AccountPages.AccountOverview,
                    IconWhiteUrl = $"{whiteAccountIcons}/account-overview.png",
                    IconBlueUrl = $"{blueAccountIcons}/account-overview.png"
                },
                new AccountLeftNavigationViewModel
                {
                    AccountName = AccountNamesType.Security,
                    AccountPage = AccountPages.SecuritySettings,
                    IconWhiteUrl = $"{whiteAccountIcons}/security-settings.png",
                    IconBlueUrl = $"{blueAccountIcons}/security-settings.png"
                }
            };
            return accountList;
        }
    }
}
