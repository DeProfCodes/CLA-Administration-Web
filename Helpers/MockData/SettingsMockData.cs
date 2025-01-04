using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLA_Administration_Web.ViewModels.Settings.ActiveConections;
using CLA_Administration_Web.ViewModels.Settings.ActiveConnections;
using CLA_Administration_Web.ViewModels.Settings.CustomUser;
using CLA_Administration_Web.ViewModels.Settings.DefaultFonts;
using CLA_Administration_Web.ViewModels.Settings.SetupExclusion;
using CLA_Administration_Web.ViewModels.Settings.SkinAndOfflineImage;
using CLA_Administration_Web.ViewModels.Settings.StagingUsers;
using CLA_Administration_Web.ViewModels.Shared;
using CLA_Administration_Web.ViewModels.Targeting;
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
   
        public static List<ActiveConnection> ActiveConnections { get; set; } = GetActiveConnections();

        public static List<CustomUserViewModel> CustomUserSettings { get; set; } = GetCustomUserSettings();

        public static List<SkinsAndOfflineModel> SkinsAndOfflineImage { get; set; } = GetSkinsAndOfflineImage();

        public static List<FontCustomizationModel> CustomFontSettings { get; set; } = GetFontSettings();

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
                    //This needs to be fixed , realised that im supposed to use TargetingHelper function
                    // Id = rand.Next(41, 999),
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
                    //This needs to be fixed , realised that im supposed to use TargetingHelper function
                    Id = rand.Next(41, 999),
                    Description = MockDataHelperFunctions.GetRandomUserID(),
                    ScreensaverTimeout = MockDataHelperFunctions.GetRandomCustomUserNumbers(),
                    PopupTimeout = MockDataHelperFunctions.GetRandomCustomUserNumbers(),
                    DeskTopTimeout = MockDataHelperFunctions.GetRandomCustomUserNumbers(),
                    SyncTimeout = MockDataHelperFunctions.GetRandomCustomUserNumbers(),
                    Network = MockDataHelperFunctions.GetRandomDomainName(),
                    TickerTimeout= MockDataHelperFunctions.GetRandomCustomUserNumbers()

                };
                result.Add(item);
            }
            return result;
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

        public static List<DefaultFontsViewModel> GetDefaultFontsData()
        {
            var rand = new Random();


            return new List<DefaultFontsViewModel>
        {
            new DefaultFontsViewModel
            {
                DefaultHeading = "Popups",
                Title = "Popup Title",
                Icon = "https://via.placeholder.com/30",
                Text = "CLA - Corporate LAN Advertising",
                Id = rand.Next(41, 999),
                SubHeadings = new List<SubHeadingViewModel>
                {
                    new SubHeadingViewModel
                    {
                        Id = 1,
                        Title = "Popup Text",
                        Icon = "https://via.placeholder.com/30",
                        Text = "Popup Subheading Text"
                    }
                }
            },
            new DefaultFontsViewModel
            {
                DefaultHeading = "Surveys",
                Title = "Survey Title",
                Icon = "https://via.placeholder.com/30",
                Text = "CLA - Corporate LAN Advertising",
                Id = rand.Next(41, 999),
                SubHeadings = new List<SubHeadingViewModel>
                {
                    new SubHeadingViewModel
                    {
                        Id =rand.Next(41, 999),
                        Title = "Survey Title",
                        Icon = "https://via.placeholder.com/30",
                        Text = "Survey Subheading Text"
                    },
                    new SubHeadingViewModel
                    {
                        Id =rand.Next(41, 999),
                        Title = "Question Title",
                        Icon = "https://via.placeholder.com/30",
                        Text = "Survey Subheading Text"
                    },
                    new SubHeadingViewModel
                    {
                        Id = rand.Next(41, 999),
                        Title = "Survey/Question Text",
                        Icon = "https://via.placeholder.com/30",
                        Text = "Survey Subheading Text"
                    }
                    }
                },
                new DefaultFontsViewModel
                {
                    DefaultHeading = "Tickers",
                    Title = "Ticker Text",
                    Icon = "https://via.placeholder.com/30",
                    Text = "CLA - Corporate LAN Advertising",
                    Id = rand.Next(41, 999)
                },
                new DefaultFontsViewModel
                {
                    DefaultHeading = "RSS",
                    Title = "RSS Text",
                    Icon = "https://via.placeholder.com/30",
                    Text = "CLA - Corporate LAN Advertising",
                    Id = rand.Next(41, 999)
                },
                new DefaultFontsViewModel
                {
                    DefaultHeading = "Desktop Information",
                    Title = "Desktop Info",
                    Icon = "https://via.placeholder.com/30",
                    Text = "CLA - Corporate LAN Advertising",
                    Id = rand.Next(41, 999)
                }
            };
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

    }
}
