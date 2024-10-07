using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.ViewModels.Modules;

namespace CLA_Administration_Web.Helpers.Layout
{
    public class BreadcrumbsHelper
    {
        public static List<ModuleBreadcrumbViewModel> GetAllModulesBreadcrumbData(int moduleDetailsId = 0)
        {
            var modulesBreadcrumbs = new List<ModuleBreadcrumbViewModel>()
            {
                //Popups
                new ModuleBreadcrumbViewModel()
                {
                    IsAllModulesBreadcrumb = true,
                    ModulePage = ModulesPages.AllModules,
                    ModulePageName = "Modules",
                    ModuleSubPage = "Overview",
                    HasActionButton = false,
                    IsAddNewIcon = false,
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.PopupOverview,
                    ModulePageName = "Popup Module",
                    ModuleName = "Popup",
                    ModuleSubPage = "Overview",
                    HasActionButton = true,
                    IsAddNewIcon = true,
                    ActionButtonText = "Add New Popup",
                    ActionButtonPage = ModulesPages.PopupAddNew
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.PopupDetails,
                    ModulePageName = "Popup Module",
                    ModuleName = "Popup",
                    ModuleSubPage = "Details",
                    HasActionButton = true,
                    IsDetailsPage = true,
                    ModuleDetailsId = moduleDetailsId, 
                    ModulePreviewPage = ModulesPages.PopupOverview,
                    IsAddNewIcon = true,
                    ActionButtonText = "Edit Popup",
                    ActionButtonPage = ModulesPages.PopupAddNew
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.PopupAddNew,
                    ModulePageName = "Popup Module",
                    ModuleName = "Popup",
                    ModuleSubPage = "Add New",
                    HasActionButton = true,
                    IsAddNewIcon = false,
                    ActionButtonText = "Popups Overview",
                    ActionButtonPage = ModulesPages.PopupOverview
                },
                //Content Library
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.ContentLibraryCategories,
                    ModulePageName = "Content Library Module",
                    ModuleName = "Content Library",
                    ModuleSubPage = "Categories",
                    HasActionButton = true,
                    IsAddNewIcon = true,
                    ActionButtonText = "Add New Category",
                    ActionButtonPage = ModulesPages.AddNewContentLibraryCategory
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.AddNewContentLibraryCategory,
                    ModulePageName = "Content Library Module",
                    ModuleName = "Content Library",
                    ModuleSubPage = "Add New Categories",
                    HasActionButton = true,
                    IsAddNewIcon = false,
                    ActionButtonText = "Categories Overview",
                    ActionButtonPage = ModulesPages.ContentLibraryCategories
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.ContentLibraryCategoryDetails,
                    ModulePageName = "Content Library Module",
                    ModuleName = "Content Library",
                    ModuleSubPage = "Details",
                    HasActionButton = true,
                    IsDetailsPage = true,
                    ModuleDetailsId = moduleDetailsId,
                    ModulePreviewPage = ModulesPages.ContentLibraryCategories,
                    IsAddNewIcon = true,
                    ActionButtonText = "Edit Category",
                    ActionButtonPage = ModulesPages.PopupAddNew
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.ContentLibraryContent,
                    ModulePageName = "Content Library Module",
                    ModuleName = "Content Library",
                    ModuleSubPage = "Content",
                    HasActionButton = true,
                    IsAddNewIcon = true,
                    ActionButtonText = "Add New Content",
                    ActionButtonPage = ModulesPages.AddNewContentLibraryContent
                },
                //Desktops
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.DesktopOverview,
                    ModulePageName = "Desktop Module",
                    ModuleName = "Desktop",
                    ModuleSubPage = "Overview",
                    HasActionButton = true,
                    IsAddNewIcon = true,
                    ActionButtonText = "Add New Desktop",
                    ActionButtonPage = ModulesPages.DesktopAddNew
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.DesktopDetails,
                    ModulePageName = "Desktop Module",
                    ModuleName = "Locked Desktop",
                    ModuleSubPage = "Details",
                    HasActionButton = true,
                    IsDetailsPage = true,
                    ModuleDetailsId = moduleDetailsId,
                    ModulePreviewPage = ModulesPages.DesktopOverview,
                    IsAddNewIcon = true,
                    ActionButtonText = "Edit Desktop",
                    ActionButtonPage = ModulesPages.DesktopAddNew
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.DesktopAddNew,
                    ModulePageName = "Desktop Module",
                    ModuleName = "Desktop",
                    ModuleSubPage = "Add New",
                    HasActionButton = true,
                    IsAddNewIcon = true,
                    ActionButtonText = "Desktop Overview",
                    ActionButtonPage = ModulesPages.DesktopOverview
                },
                //Locked Desktops
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.LockedDesktopAddNew,
                    ModulePageName = "Locked Desktop Module",
                    ModuleName = "Locked Desktop",
                    ModuleSubPage = "Add New",
                    HasActionButton = true,
                    IsAddNewIcon = false,
                    ActionButtonText = "Locked Desktop Overview",
                    ActionButtonPage = ModulesPages.LockedDesktopOverview
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.LockedDesktopDetails,
                    ModulePageName = "Locked Desktop Module",
                    ModuleName = "Locked Desktop",
                    ModuleSubPage = "Details",
                    HasActionButton = true,
                    IsDetailsPage = true,
                    ModuleDetailsId = moduleDetailsId,
                    ModulePreviewPage = ModulesPages.LockedDesktopOverview,
                    IsAddNewIcon = true,
                    ActionButtonText = "Edit Locked Desktop",
                    ActionButtonPage = ModulesPages.LockedDesktopAddNew
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.LockedDesktopOverview,
                    ModulePageName = "Locked Desktop Module",
                    ModuleName = "Locked Desktop",
                    ModuleSubPage = "Overview",
                    HasActionButton = true,
                    IsAddNewIcon = true,
                    ActionButtonText = "Add New Locked Desktop",
                    ActionButtonPage = ModulesPages.LockedDesktopAddNew
                },
                //Screensavers
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.ScreensaverAddNew,
                    ModulePageName = "Screensaver Module",
                    ModuleName = "Screensaver",
                    ModuleSubPage = "Add New",
                    HasActionButton = true,
                    IsAddNewIcon = false,
                    ActionButtonText = "Screensaver Overview",
                    ActionButtonPage = ModulesPages.ScreensaverOverview
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.ScreensaverDetails,
                    ModulePageName = "Screensaver Module",
                    ModuleName = "Screensaver",
                    ModuleSubPage = "Details",
                    HasActionButton = true,
                    IsDetailsPage = true,
                    ModuleDetailsId = moduleDetailsId,
                    ModulePreviewPage = ModulesPages.ScreensaverOverview,
                    IsAddNewIcon = true,
                    ActionButtonText = "Edit Screensaver",
                    ActionButtonPage = ModulesPages.ScreensaverAddNew
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.ScreensaverOverview,
                    ModulePageName = "Screensaver Module",
                    ModuleName = "Screensaver",
                    ModuleSubPage = "Overview",
                    HasActionButton = true,
                    IsAddNewIcon = true,
                    ActionButtonText = "Add New Screensaver",
                    ActionButtonPage = ModulesPages.ScreensaverAddNew
                },
                //Surveys
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.SurveyOverview,
                    ModulePageName = "Survey Module",
                    ModuleName = "Survey",
                    ModuleSubPage = "Overview",
                    HasActionButton = true,
                    IsAddNewIcon = true,
                    ActionButtonText = "Add New Survey",
                    ActionButtonPage = ModulesPages.SurveyAddNew
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.SurveyAddNew,
                    ModulePageName = "Survey Module",
                    ModuleName = "Survey",
                    ModuleSubPage = "Add New",
                    HasActionButton = true,
                    IsAddNewIcon = false,
                    ActionButtonText = "Survey Overview",
                    ActionButtonPage = ModulesPages.SurveyOverview
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.SurveyDetails,
                    ModulePageName = "Survey Module",
                    ModuleName = "Survey",
                    ModuleSubPage = "Details",
                    HasActionButton = true,
                    IsDetailsPage = true,
                    ModuleDetailsId = moduleDetailsId,
                    ModulePreviewPage = ModulesPages.SurveyOverview,
                    IsAddNewIcon = true,
                    ActionButtonText = "Edit Survey",
                    ActionButtonPage = ModulesPages.SurveyAddNew
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.SurveyQuestionsOverview,
                    ModulePageName = "Survey Module",
                    ModuleName = "Survey",
                    ModuleSubPage = "Questions Overview",
                    HasActionButton = true,
                    IsDetailsPage = true,
                    ModuleDetailsId = moduleDetailsId,
                    ModulePreviewPage = ModulesPages.SurveyOverview,
                    IsAddNewIcon = false,
                    ActionButtonText = "Surveys Overview",
                    ActionButtonPage = ModulesPages.SurveyOverview
                },
                //Tickers
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.TickerAddNew,
                    ModulePageName = "Ticker Module",
                    ModuleName = "Ticker",
                    ModuleSubPage = "Add New",
                    HasActionButton = true,
                    IsAddNewIcon = false,
                    ActionButtonText = "Ticker Overview",
                    ActionButtonPage = ModulesPages.TickerOverview
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.TickerOverview,
                    ModulePageName = "Ticker Module",
                    ModuleName = "Ticker",
                    ModuleSubPage = "Overview",
                    HasActionButton = true,
                    IsAddNewIcon = true,
                    ActionButtonText = "Add New Ticker",
                    ActionButtonPage = ModulesPages.TickerAddNew
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.TickerDetails,
                    ModulePageName = "Ticker Module",
                    ModuleName = "Ticker",
                    ModuleSubPage = "Details",
                    HasActionButton = true,
                    IsDetailsPage = true,
                    ModuleDetailsId = moduleDetailsId,
                    ModulePreviewPage = ModulesPages.TickerOverview,
                    IsAddNewIcon = true,
                    ActionButtonText = "Edit Ticker",
                    ActionButtonPage = ModulesPages.TickerAddNew
                },
                //RSS
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.RSSAddNewCategory,
                    ModulePageName = "RSS Module",
                    ModuleName = "RSS",
                    ModuleSubPage = "Add New",
                    HasActionButton = true,
                    IsAddNewIcon = false,
                    ActionButtonText = "RSS Overview",
                    ActionButtonPage = ModulesPages.RSSCategoryOverview
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.RSSCategoryOverview,
                    ModulePageName = "RSS Module",
                    ModuleName = "RSS",
                    ModuleSubPage = "Categories",
                    HasActionButton = true,
                    IsAddNewIcon = true,
                    ActionButtonText = "Add New RSS",
                    ActionButtonPage = ModulesPages.RSSAddNewCategory
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.RSSCategoryDetails,
                    ModulePageName = "RSS Module",
                    ModuleName = "RSS",
                    ModuleSubPage = "Details",
                    HasActionButton = true,
                    IsDetailsPage = true,
                    ModuleDetailsId = moduleDetailsId,
                    ModulePreviewPage = ModulesPages.RSSCategoryOverview,
                    IsAddNewIcon = true,
                    ActionButtonText = "Edit RSS Category",
                    ActionButtonPage = ModulesPages.RSSAddNewCategory
                },
                new ModuleBreadcrumbViewModel()
                {
                    ModulePage = ModulesPages.RSSFeedOverview,
                    ModulePageName = "RSS Module",
                    ModuleName = "RSS",
                    ModuleSubPage = "Feeds",
                    HasActionButton = true,
                    IsAddNewIcon = true,
                    ActionButtonText = "Add New Feed",
                    ActionButtonPage = ModulesPages.RSSAddNewCategory
                }
            };
            return modulesBreadcrumbs;
        }
        
        public static ModuleBreadcrumbViewModel GetModuleBreadcrumbData(ModulesPages modulePage, int moduleDetailsId = 0)
        {
            var allModulesBreadcrumbs = GetAllModulesBreadcrumbData(moduleDetailsId);

            return allModulesBreadcrumbs.FirstOrDefault(m => m.ModulePage == modulePage);
        }
    }
}
