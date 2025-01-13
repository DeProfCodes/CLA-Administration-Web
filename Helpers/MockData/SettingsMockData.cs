using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Helpers.Shared;
using CLA_Administration_Web.ViewModels.Modules.ContentLibrary;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLA_Administration_Web.ViewModels.Settings.ActiveConections;
using CLA_Administration_Web.ViewModels.Settings.ActiveConnections;
using CLA_Administration_Web.ViewModels.Settings.CustomUser;
using CLA_Administration_Web.ViewModels.Settings.DefaultFonts;
using CLA_Administration_Web.ViewModels.Settings.DesktopInformation;
using CLA_Administration_Web.ViewModels.Settings.ManageAdminAccess;
using CLA_Administration_Web.ViewModels.Settings.SetupExclusion;
using CLA_Administration_Web.ViewModels.Settings.SkinAndOfflineImage;
using CLA_Administration_Web.ViewModels.Settings.StagingUsers;
using CLA_Administration_Web.ViewModels.Shared;
using CLA_Administration_Web.ViewModels.Targeting;
using CLAModulesLibrary.Enums;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.AspNetCore.Identity.Data;

using System;

namespace CLA_Administration_Web.Helpers.MockData
{
    public class SettingsMockData
    {
        public static List<StagingUserMachineViewModel> StagingUsers { get; set; } = GetStagingUsersOrMachines();

        public static List<StagingUserMachineViewModel> StagingMachines { get; set; } = GetStagingUsersOrMachines();

        public static List<SetupExclusionsUsersViewModel> SetupExcludedUsers { get; set; } = GetSetupUsersExclusions();

        public static List<SetupExclusionMachinesViewModel> SetupExcludedMachines { get; set; } = GetSetupMachinesExclusions();

        public static List<TargetedUser> TargetGroupUsers { get; set; } = GetTargetGroupUsers();
        public static List<TargetedMachine> TargetedMachines { get; set; } = GetTargetedMachines();

        public static List<TargetedGroup> TargetedGroups { get; set; } = GetTargetedGroups();

        public static List<TargetedIPRange> TargetedIPRanges { get; set; } = GetTargetedIPRanges();


        public static List<ActiveConnection> ActiveConnections { get; set; } = GetActiveConnections();

        public static List<CustomUserViewModel> CustomUserSettings { get; set; } = GetCustomUserSettings();

        public static List<SkinsAndOfflineModel> SkinsAndOfflineImage { get; set; } = GetSkinsAndOfflineImage();

        public static List<FontCustomizationModel> CustomFontSettings { get; set; } = GetFontSettings();
        public static List<AdminAccessItem> AdminAccess { get; set; } = GetAdminAccessData();

        public static List<PositionViewModel> DesktopPosition { get; set; } = GetDesktopPositionData();

        public static List<SkinOfflineCategortyTree> AllSkinsOfflineImageCategories { get; set; } = GenerateDummyDataSkinsOfflineImage();


        public static List<StagingUserMachineViewModel> GetStagingUsersOrMachines()
        {
            var result = new List<StagingUserMachineViewModel>();

            var rand = new Random();

            for (int i = 0; i < 15; i++)
            {
                var item = new StagingUserMachineViewModel()
                {
                    Id = rand.Next(41, 999),
                    Domain = MockDataHelperFunctions.GetRandomDomainName(),
                    UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),
                    Firstname = MockDataHelperFunctions.GetRandomFirstname(),
                    Lastname = MockDataHelperFunctions.GetRandomLastname(),
                    MachineName = MockDataHelperFunctions.GetRandomMachineID(),
                    Username = MockDataHelperFunctions.GetRandomUserID(),
                    MachineDescription = MockDataHelperFunctions.GetRandomMachineID(),
                };
                result.Add(item);
            }
            return result;
        }

        public static List<SetupExclusionMachinesViewModel> GetSetupMachinesExclusions()
        {
            var result = new List<SetupExclusionMachinesViewModel>();

            var rand = new Random();

            for (int i = 0; i < 15; i++)
            {
                var item = new SetupExclusionMachinesViewModel()
                {
                    Id = rand.Next(41, 999),
                    Domain = MockDataHelperFunctions.GetRandomDomainName(),
                    UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),
                    MachineName = MockDataHelperFunctions.GetRandomMachineID(),
                    MachineDescription = MockDataHelperFunctions.GetRandomMachineID(),
                };
                result.Add(item);
            }
            return result;
        }

        public static List<SetupExclusionsUsersViewModel> GetSetupUsersExclusions()
        {
            var result = new List<SetupExclusionsUsersViewModel>();

            var rand = new Random();

            for (int i = 0; i < 15; i++)
            {
                var item = new SetupExclusionsUsersViewModel()
                {
                    Id = rand.Next(41, 999),
                    Domain = MockDataHelperFunctions.GetRandomDomainName(),
                    Username = MockDataHelperFunctions.GetRandomUserID(),
                    Firstname = MockDataHelperFunctions.GetRandomFirstname(),
                    Lastname = MockDataHelperFunctions.GetRandomLastname(),
                    UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineLastModified = MockDataHelperFunctions.GetRandomMachineID()
                };
                result.Add(item);
            }
            return result;
        }
        public static List<ActiveConnection> GetActiveConnections()
        {

            var result = new List<ActiveConnection>();

            var rand = new Random();

            for (int i = 0; i < 15; i++)
            {
                var item = new ActiveConnection()
                {
                    ConnectionID = MockDataHelperFunctions.GetRandomConnectionsID(),
                    Minutes = MockDataHelperFunctions.GetRandomConnectionsMinutes(),
                    Host = MockDataHelperFunctions.GetRandomConnectionsHost(),
                    Login = MockDataHelperFunctions.GetRandomConnectionsLogin(),
                    Program = MockDataHelperFunctions.GetRandomConnectionsProgram(),
                    Command = MockDataHelperFunctions.GetRandomConnectionsCommand()

                };
                result.Add(item);
            }
            return result;
        }
        public static List<TargetedUser> GetTargetGroupUsers()
        {
            var result = new List<TargetedUser>();


            var rand = new Random();
            for (int i = 0; i < 15; i++)
            {
                
                var item = new TargetedUser()
                {
                   
                    Id = rand.Next(41, 999),
                    DomainName = MockDataHelperFunctions.GetRandomDomainName(),
                    DisplayName = MockDataHelperFunctions.GetRandomFirstname(),
                    NTUsername = MockDataHelperFunctions.GetRandomLastname(),
                    LastSyncDT = MockDataHelperFunctions.GetRandomMachineID(),

                };
                result.Add(item);
            }
            return result;
        }

        public static List<CustomUserViewModel> GetCustomUserSettings()
        {
            var result = new List<CustomUserViewModel>();

            var rand = new Random();

            for (int i = 0; i < 15; i++)
            {
                var item = new CustomUserViewModel()
                {
                    
                    Id = rand.Next(41, 999),
                    Description = MockDataHelperFunctions.GetRandomUserID(),
                    ScreensaverTimeout = MockDataHelperFunctions.GetRandomCustomUserNumbers(),
                    PopupTimeout = MockDataHelperFunctions.GetRandomCustomUserNumbers(),
                    DeskTopTimeout = MockDataHelperFunctions.GetRandomCustomUserNumbers(),
                    SyncTimeout = MockDataHelperFunctions.GetRandomCustomUserNumbers(),
                    Network = MockDataHelperFunctions.GetRandomDomainName(),
                    TickerTimeout = MockDataHelperFunctions.GetRandomCustomUserNumbers()

                };
                result.Add(item);
            }
            return result;
        }

        private static List<AdminAccessItem> GetAdminAccessData()
        {
            var random = new Random();
            var items = new List<AdminAccessItem>();
         

            for (int i = 1; i <= 15; i++)
            {            
              
                var domain = MockDataHelperFunctions.GetRandomDomainName();
                var username = $"User{random.Next(1, 101)}";
                var id = random.Next(1, 100);
                var desktopEnvironment = $"Environment{random.Next(1, 6)}";
             

                var item = new AdminAccessItem
                {
                   
                    Domain = domain,
                    Username = MockDataHelperFunctions.GetRandomMachineID(),
                    DesktopEnvironment = desktopEnvironment,
                    DesktopRead = random.Next(0, 2) == 0 ? "Allowed" : "Restricted",
                    DesktopWrite = random.Next(0, 2) == 0 ? "Allowed" : "Restricted",
                    DesktopReport = random.Next(0, 2) == 0 ? "Enabled" : "Disabled",
                    TickersEnvironment = $"TickersEnv{random.Next(1, 6)}",
                    TickersRead = random.Next(0, 2) == 0 ? "Allowed" : "Restricted",
                    TickersWrite = random.Next(0, 2) == 0 ? "Allowed" : "Restricted",
                    TickersReport = random.Next(0, 2) == 0 ? "Enabled" : "Disabled",
                    RSS_Environment = $"RSS_Env{random.Next(1, 6)}",
                    RSS_Read = random.Next(0, 2) == 0 ? "Allowed" : "Restricted",
                    RSS_Write = random.Next(0, 2) == 0 ? "Allowed" : "Restricted",
                    RSS_Report = random.Next(0, 2) == 0 ? "Enabled" : "Disabled",
                    LockscreenEnvironment = $"LockscreenEnv{random.Next(1, 6)}",
                    LockscreenRead = random.Next(0, 2) == 0 ? "Allowed" : "Restricted",
                    LockscreenWrite = random.Next(0, 2) == 0 ? "Allowed" : "Restricted",
                    LockscreenReport = random.Next(0, 2) == 0 ? "Enabled" : "Disabled",
                    UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineLastModified = MockDataHelperFunctions.GetRandomMachineID()

                };

                items.Add(item);
            }
            return items;
        }

        private static List<PositionViewModel> GetDesktopPositionData()
        {
           
            var positions = new List<string>
            {
            "Top Left", "Top Center", "Top Right",
            "Middle Left", "Center", "Middle Right",
            "Bottom Left", "Bottom Center", "Bottom Right"
            };

          
            var selectedPosition = "Top Left"; 

            
            var informationToDisplay = new Dictionary<string, bool>
            {
                { "IP Address", false },
                { "CPU Details", false },
                { "Memory Details", false },
                { "User Name", false },
                { "Machine Name", false },
                { "Operating System", false },
                { "Domain Name", false },
                { "HDD Free", false },
                { "Network Status", false },
                { "Domain Controller", false },
                { "Last Boot Time", false },
                { "Serial Number", false }
            };

            var item = new PositionViewModel
            {
                Positions = positions,
                SelectedPosition = selectedPosition,
                Checkboxes = informationToDisplay
            };

        
            return new List<PositionViewModel> { item };
        }
        private static List<SurveyQuestionViewModel> GenerateSurveyQuestions()
        {
            var random = new Random();
            var items = new List<SurveyQuestionViewModel>();
            var surveyQuestionCounters = new Dictionary<int, int>();

            var responseTypes = new List<string> { "Single Select", "Multi Select", "Yes/No", "Yes/No/NA", "Agree/Disagree", "Text", "Re-Arrange" };

            for (int i = 1; i <= 200; i++)
            {
                var surveyId = random.Next(1, 51);

                if (!surveyQuestionCounters.ContainsKey(surveyId))
                {
                    surveyQuestionCounters[surveyId] = 1;
                }

                var questionNo = surveyQuestionCounters[surveyId].ToString();
                surveyQuestionCounters[surveyId]++;

                var isScored = random.Next(0, 2) == 0 ? "No" : "Yes";



                var responseType = responseTypes[random.Next(responseTypes.Count)];
                var correctAnswer = isScored == "Yes" ? "No" : "";

                var item = new SurveyQuestionViewModel
                {
                    QuestionId = i,
                    QuestionNo = questionNo,
                    SurveyId = surveyId,

                    CorrectAnswer = correctAnswer,
                    Dependencies = random.Next(0, 2) == 0 ? "" : $"Q{random.Next(1, i)}",
                    IsAnonymous = random.Next(0, 2) == 0 ? "No" : "Yes",
                    IsScored = isScored,
                    Randomize = random.Next(0, 2) == 0 ? "No" : "Yes",
                    ResponseType = responseType,
                    LastModifiedDate = DateTime.Now.AddMinutes(-random.Next(0, 50000)).ToString("yyyy/MM/dd HH:mm"),
                    MachineLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    UserIdLastModified = MockDataHelperFunctions.GetRandomMachineID(),
                };

                items.Add(item);
            }
            return items;
        }
        public static List<SkinsAndOfflineModel> GetSkinsAndOfflineImage()
        {
            var random = new Random();
            var result = new List<SkinsAndOfflineModel>();

            for (int i = 0; i < 15; i++)
            {
                var item = new SkinsAndOfflineModel
                {
                    Id = random.Next(41, 999),
                    IsDefault = random.Next(0, 2) == 0 ? "No" : "Yes",
                    Description = MockDataHelperFunctions.GetRandomConnectionsMinutes(),
                    UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),
                };
                result.Add(item);
            }
            return result;
        }

        public static List<SkinsAndOfflineModel> GetSkinsAndOfflineImages()
        {
            var random = new Random();
            var result = new List<SkinsAndOfflineModel>();

            var rand = new Random();

            for (int i = 0; i < 15; i++)
            {

                var item = new SkinsAndOfflineModel()
                {

                    Id = rand.Next(41, 999),
                    IsDefault = random.Next(0, 2) == 0 ? "No" : "Yes",
                    Description = MockDataHelperFunctions.GetRandomConnectionsMinutes(),
                    UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),


                };
                result.Add(item);
            }
            return result;
        }

        public static List<FontCustomizationModel> GetFontSettings()
        {
            var random = new Random();
            var result = new List<FontCustomizationModel>();

            for (int i = 0; i < 15; i++)
            {
                var item = new FontCustomizationModel()
                {
                    Id = random.Next(41, 999),
                    HeadingFontFamily = MockDataHelperFunctions.FontFamilies(),
                    FontSize = MockDataHelperFunctions.FontSize(),
                    FontWeight = MockDataHelperFunctions.FontWeight(),
                    FontStyle = MockDataHelperFunctions.FontStyle(),
                    TextColor = MockDataHelperFunctions.RandomHexColor(),
                    BackgroundColor = MockDataHelperFunctions.RandomHexColor()
                };

                result.Add(item);
            }

            return result;
        }
        public static List<DefaultFontsViewModel> GetDefaultFontsData()
        {
            int idCounter = 1;
            int subIdCounter = 1; 

            return new List<DefaultFontsViewModel>
    {
        new DefaultFontsViewModel
        {
            DefaultHeading = "Popups",
            Id = idCounter++, 
            SubHeadings = new List<SubHeadingViewModel>
            {
                new SubHeadingViewModel
                {
                    SubId = subIdCounter++, 
                    Title = "Popup Text",
                    Icon = "https://via.placeholder.com/30",
                    Text = "Popup Subheading Text"
                },
                new SubHeadingViewModel
                {
                    SubId = subIdCounter++,
                    Title = "Popup Title",
                    Icon = "https://via.placeholder.com/30",
                    Text = "CLA - Corporate LAN Advertising"
                }
            }
        },
        new DefaultFontsViewModel
        {
            DefaultHeading = "Surveys",
            Id = idCounter++,
            SubHeadings = new List<SubHeadingViewModel>
            {
                new SubHeadingViewModel
                {
                    SubId = subIdCounter++,
                    Title = "Survey Title",
                    Icon = "https://via.placeholder.com/30",
                    Text = "Survey Subheading Text"
                },
                new SubHeadingViewModel
                {
                    SubId = subIdCounter++,
                    Title = "Question Title",
                    Icon = "https://via.placeholder.com/30",
                    Text = "Survey Subheading Text"
                },
                new SubHeadingViewModel
                {
                    SubId = subIdCounter++,
                    Title = "Survey/Question Text",
                    Icon = "https://via.placeholder.com/30",
                    Text = "Survey Subheading Text"
                }
            }
        },
        new DefaultFontsViewModel
        {
            DefaultHeading = "Tickers",
            Id = idCounter++,
            SubHeadings = new List<SubHeadingViewModel>
            {
                new SubHeadingViewModel
                {
                    SubId = subIdCounter++,
                    Title = "Ticker Text",
                    Icon = "https://via.placeholder.com/30",
                    Text = "CLA - Corporate LAN Advertising"
                }
            }
        },
        new DefaultFontsViewModel
        {
            DefaultHeading = "RSS",
            Id = idCounter++,
            SubHeadings = new List<SubHeadingViewModel>
            {
                new SubHeadingViewModel
                {
                    SubId = subIdCounter++,
                    Title = "RSS Text",
                    Icon = "https://via.placeholder.com/30",
                    Text = "CLA - Corporate LAN Advertising"
                }
            }
        },
        new DefaultFontsViewModel
        {
            DefaultHeading = "Desktop Information",
            Id = idCounter++,
            SubHeadings = new List<SubHeadingViewModel>
            {
                new SubHeadingViewModel
                {
                    SubId = subIdCounter++,
                    Title = "Desktop Info",
                    Icon = "https://via.placeholder.com/30",
                    Text = "CLA - Corporate LAN Advertising"
                }
            }
        }
    };
        }
        public static List<SkinOfflineCategortyTree> GenerateDummyDataSkinsOfflineImage()
        {
            int idCounter = 1;
               var random = new Random();
            ModuleNamesType module;
            var rootCategory = new SkinOfflineCategortyTree
            {
                CategoryId = random.Next(41, 99),
                CategoryName = "Existing Skin", 
                CategoryDescription = "This is the root category for Existing Skin",
                ContentsCount = 0, 
                UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),
                _children = new List<SkinOfflineCategortyTree>
        {
          
            new SkinOfflineCategortyTree
            {
                CategoryId = random.Next(41, 99),
                CategoryName = ModuleNamesType.Popup.GetDisplayName(),
                CategoryDescription = "This is the popups category",
                UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),
                      
                ContentsCount = 0,
                _children = GenerateRandomTreeChildren(ref idCounter) 
            },
             new SkinOfflineCategortyTree
            {
                CategoryId = random.Next(41, 99),
                CategoryName = "Offline Desktop",
                CategoryDescription = "This is the offline desktop category",
                UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),

                ContentsCount = 0,
                _children = GenerateRandomTreeChildren(ref idCounter)
            },  new SkinOfflineCategortyTree
            {
                CategoryId = random.Next(41, 99),
                CategoryName = "Offline Lockscreen Wallpaper",
                CategoryDescription = "This is the offline lockscreen wallpaper category",
                UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),

                ContentsCount = 0,
                _children = GenerateRandomTreeChildren(ref idCounter)
            },  new SkinOfflineCategortyTree
            {
                CategoryId = random.Next(41, 99),
                CategoryName = "Offline Screensaver",
                CategoryDescription = "This is the offline screensaver category",
                UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),

                ContentsCount = 0,
                _children = GenerateRandomTreeChildren(ref idCounter)
            },
          
            new SkinOfflineCategortyTree
            {
                CategoryId = random.Next(41, 99),
                CategoryName =  ModuleNamesType.Survey.GetDisplayName(),
                CategoryDescription = "This is the skin category",
                ContentsCount = 0,
                UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),
                _children = GenerateRandomTreeChildren(ref idCounter) 
            },
              new SkinOfflineCategortyTree
            {
                CategoryId = random.Next(41, 99),
                CategoryName = ModuleNamesType.Ticker.GetDisplayName(),
                CategoryDescription = "This is the popups category",
                UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),

                ContentsCount = 0,
                _children = GenerateRandomTreeChildren(ref idCounter)
            }
        }
            };

           
            return new List<SkinOfflineCategortyTree> { rootCategory };
        }

        public static List<SkinOfflineCategortyTree> GenerateRandomTreeChildren(ref int idCounter)
        {
            Random random = new Random();
            var children = new List<SkinOfflineCategortyTree>();
            int childrenCount = random.Next(1, 4); // Random number of children

            for (int i = 0; i < childrenCount; i++)
            {
                children.Add(new SkinOfflineCategortyTree
                {
                    CategoryId = random.Next(41, 99),
                    CategoryName = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(1, 3)),
                    CategoryDescription = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(5, 15)),
                    ContentsCount = random.Next(0, 100),
                    UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),
                    _children = null
                });
            }

            return children;
        }


        public static List<TargetedMachine> GetTargetedMachines()
        {
            var result = new List<TargetedMachine>();
            var random = new Random();
            for (int i = 0; i < 15; i++)
            {
                result.Add(new TargetedMachine
                {  machineId = random.Next(41, 999),
                    DomainName = MockDataHelperFunctions.GetRandomDomainName(),
                    LastSyncDT = DateTime.Now.AddHours(-new Random().Next(1, 100)).ToString("yyyy/MM/dd HH:mm"),
                    DisplayName = MockDataHelperFunctions.GetRandomFirstname(),
                    NTUsername = MockDataHelperFunctions.GetRandomLastname(),
                });
            }

            return result;
        }

        public static List<TargetedGroup> GetTargetedGroups()
        {
            var result = new List<TargetedGroup>();
            var random = new Random();
            for (int i = 0; i < 15; i++)
            {
                result.Add(new TargetedGroup
                {
                    DomainName = MockDataHelperFunctions.GetRandomDomainName(),
                    GroupId = random.Next(41, 999),
                    DisplayName = MockDataHelperFunctions.GetRandomUserID(),
                });
            }

            return result;
        }

        public static List<TargetedIPRange> GetTargetedIPRanges()
        {
            var result = new List<TargetedIPRange>();
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var ipRange = MockDataHelperFunctions.GetRandomIPRange();
                result.Add(new TargetedIPRange
                {
                    RangeId = random.Next(41, 999),
                    StartIP = ipRange.StartIP,
                    EndIP = ipRange.EndIP,
                    Description = MockDataHelperFunctions.GetRandomUserID(),
                });
            }

            return result;
        }



        /* public static SkinOfflineCategortyTree GetCategoryTreeStructure(List<SkinOfflineCategortyTree> categories, int categoryId)
        {
            var contentLibraryVm = new SkinOfflineCategortyTree { CategoryId = categoryId };

            var tree = GetAllCategoriesInTree(categories, categoryId);

            var category = tree?.LastOrDefault() ?? null;

            if (category != null)
            {
                contentLibraryVm.CategoryName = category.CategoryName;
                contentLibraryVm.CategoryId = categoryId;
                contentLibraryVm.CategoryDescription = category.CategoryDescription;
               
            }

            if (tree?.Count > 1)
            {
                tree.RemoveAt(tree.Count - 1);
                var categoryList = tree.Select(x => x.CategoryName);

                var structure = string.Join(" > ", categoryList);

                contentLibraryVm.ContentLibraryParents = structure;

            }

            return contentLibraryVm;
        }*/

        public static List<ContentLibraryCategoryModel> GetAllCategoriesInTree(List<ContentLibraryCategoryTree> categories, int categoryId = 0)
        {
            var result = new List<ContentLibraryCategoryModel>();

            foreach (var category in categories)
            {
                var data = GetCategoryPath(category, categoryId);
                if (data != null)
                {
                    result.AddRange(data);
                }
            }
            return result;
        }


        public static bool SearchCategoryPath(ContentLibraryCategoryTree category, List<ContentLibraryCategoryModel> path, int searchId = 0)
        {
            if (category == null) return false;

            // Add current category data to the path
            path.Add(new ContentLibraryCategoryModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                ContentsCount = category.ContentsCount,
                DateLastModified = "2024-01-01",  // Example date
                UserLastModified = "UserA",       // Example user
                MachineLastModified = "Machine1"  // Example machine
            });

            // Check if the current category ID matches the search ID
            if (searchId != 0 && category.CategoryId == searchId) return true;

            // If category has children, search in them
            if (category._children != null)
            {
                foreach (var child in category._children)
                {
                    if (SearchCategoryPath(child, path, searchId)) return true;
                }
            }

            // If not found, remove the current category from the path
            path.RemoveAt(path.Count - 1);

            if (searchId != 0)
                return false;
            else
                return true;
        }

        private static List<ContentLibraryCategoryModel> GetCategoryPath(ContentLibraryCategoryTree root, int searchId = 0)
        {
            var path = new List<ContentLibraryCategoryModel>();

            if (SearchCategoryPath(root, path, searchId))
            {
                return path;
            }
            else
            {
                return null;
            }
        }
    }
}
