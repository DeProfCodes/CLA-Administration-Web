using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.Enums.Module;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Helpers.Modules;
using CLA_Administration_Web.Helpers.Shared;
using CLA_Administration_Web.ViewModels.Modules.ContentLibrary;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLA_Administration_Web.ViewModels.Modules.Rss;
using CLAModulesLibrary.Helpers.Enums.Modules.Popup;
using CLAModulesLibrary.Models.Popup.SubModels;

namespace CLA_Administration_Web.Helpers.MockData
{
    public class ModulesMockData
    {
        public static class StagingData
        {
            //PST
            public static List<ModulePSTDataViewModel> AllPopupsData { get; set; }

            public static List<ModulePSTDataViewModel> AllTickersData { get; set; }

            public static List<ModulePSTDataViewModel> AllSurveysData { get; set; }

            public static List<SurveyQuestionViewModel> AllSurveyQuestions { get; set; }

            //LDS
            public static List<ModuleLDSDataViewModel> AllScreensaversData { get; set; } = GenerateLDSRandomData();

            public static List<ModuleLDSDataViewModel> AllLockedDesktopsData { get; set; } = GenerateLDSRandomData();

            public static List<ModuleLDSDataViewModel> AllDesktopsData { get; set; } = GenerateLDSRandomData();

            public static List<RssCategoryOverviewViewModel> AllRSSCategories { get; set; } = GenerateRSSCategoriesRandomData();

            public static List<RssFeedOverviewViewModel> AllRSSFeed { get; set; } = GenerateRSSFeedRandomData();
        }

        public static class LiveData
        {
            //PST
            public static List<ModulePSTDataViewModel> AllPopupsData { get; set; }

            public static List<ModulePSTDataViewModel> AllTickersData { get; set; }

            public static List<ModulePSTDataViewModel> AllSurveysData { get; set; }

            public static List<SurveyQuestionViewModel> AllSurveyQuestions { get; set; }

            //LDS
            public static List<ModuleLDSDataViewModel> AllScreensaversData { get; set; } = GenerateLDSRandomData();

            public static List<ModuleLDSDataViewModel> AllLockedDesktopsData { get; set; } = GenerateLDSRandomData();

            public static List<ModuleLDSDataViewModel> AllDesktopsData { get; set; } = GenerateLDSRandomData();

            public static List<RssCategoryOverviewViewModel> AllRSSCategories { get; set; } = GenerateRSSCategoriesRandomData();

            public static List<RssFeedOverviewViewModel> AllRSSFeed { get; set; } = GenerateRSSFeedRandomData();
        }

        public static List<ContentLibraryCategoryTree> AllContentLibraryCategories { get; set; } = GenerateDummyDataContentLibraryCategories();

        public static List<ContentLibraryContentModel> AllContentLibraryContents { get; set; } = GenerateContentLibraryContents();

        public static bool IsListNullOrEmpty<T>(List<T> list)
        {
            return list == null || list.Count == 0;
        }

        public static void LoadPSTModulesData()
        {
            StagingData.AllPopupsData = IsListNullOrEmpty(StagingData.AllPopupsData) ? GeneratePSTRandomData(ModuleNamesType.Popup) : StagingData.AllPopupsData;
            StagingData.AllSurveysData = IsListNullOrEmpty(StagingData.AllSurveysData) ? GeneratePSTRandomData(ModuleNamesType.Survey) : StagingData.AllSurveysData;
            StagingData.AllSurveyQuestions = IsListNullOrEmpty(StagingData.AllSurveyQuestions) ? GenerateSurveyQuestions() : StagingData.AllSurveyQuestions;
            StagingData.AllTickersData = IsListNullOrEmpty(StagingData.AllTickersData) ? GeneratePSTRandomData(ModuleNamesType.Ticker) : StagingData.AllTickersData;

            LiveData.AllPopupsData = IsListNullOrEmpty(LiveData.AllPopupsData) ? GeneratePSTRandomData(ModuleNamesType.Popup) : LiveData.AllPopupsData;
            LiveData.AllSurveysData = IsListNullOrEmpty(LiveData.AllSurveysData) ? GeneratePSTRandomData(ModuleNamesType.Survey) : LiveData.AllSurveysData;
            LiveData.AllSurveyQuestions = IsListNullOrEmpty(LiveData.AllSurveyQuestions) ? GenerateSurveyQuestions() : LiveData.AllSurveyQuestions;
            LiveData.AllTickersData = IsListNullOrEmpty(LiveData.AllTickersData) ? GeneratePSTRandomData(ModuleNamesType.Ticker) : LiveData.AllTickersData;
        }

        // Generate Module Data for Popups, Tickers, Surveys
        private static List<ModulePSTDataViewModel> GeneratePSTRandomData(ModuleNamesType module)
        {
            var random = new Random();
            var items = new List<ModulePSTDataViewModel>();

            var popupIcons = Enum.GetValues(typeof(PopupIconType)).Cast<PopupIconType>().ToList();
            var popupDisplayTypes = Enum.GetValues(typeof(PopupDisplayTypes)).Cast<PopupDisplayTypes>().ToList();

            DateTime effectiveFrom = new();
            DateTime effectiveTo = new();

            for (int i = 1; i <= 1000; i++)
            {
                MockDataHelperFunctions.GetEffectiveDates(ref effectiveFrom, ref effectiveTo, i);
                var item = new ModulePSTDataViewModel
                {
                    Id = i,
                    HeaderText = MockDataHelperFunctions.RandomString(1, 5),
                    BodyText = MockDataHelperFunctions.RandomString(10, 50),
                    ConclusionText = MockDataHelperFunctions.RandomString(10, 30),
                    DisplayHeaderText = random.Next(0, 2) == 1,
                    DisplayBodyText = random.Next(0, 2) == 1,
                    DisplayConclusionText = random.Next(0, 2) == 1,

                    PopupIcon = popupIcons[random.Next(popupIcons.Count)],
                    PopupDisplayType = popupDisplayTypes[random.Next(popupDisplayTypes.Count)],
                    PopupAutoHideSeconds = random.Next(100),
                    PopupPosition = random.Next(10),
                    PopupFeedback = new FeedbackSettings
                    {
                        RequireFeedbackComment = random.Next(0, 2) == 1,
                        RequireFeedbackLikeDislike = random.Next(0, 2) == 1,
                    },

                    EffectiveFrom = effectiveFrom.ToString("yyyy/MM/dd"),
                    EffectiveTo = effectiveTo.ToString("yyyy/MM/dd"),
                    TimeslotFrom = MockDataHelperFunctions.RandomTime(),
                    TimeslotTo = MockDataHelperFunctions.RandomTime(),
                    LastModifiedDate = DateTime.Now.AddMinutes(-random.Next(0, 50000)).ToString("yyyy/MM/dd HH:mm"),
                    UserIdLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineLastModified = MockDataHelperFunctions.GetRandomMachineID()
                };

                if (module == ModuleNamesType.Popup)
                {
                    item.ModuleSkinUrl = ResourcesLibrary.ModulesLibrary.Skins.PopupDefaultSkin;
                }
                else if (module == ModuleNamesType.Survey)
                {
                    item.ModuleSkinUrl = ResourcesLibrary.ModulesLibrary.Skins.SurveyDefaultSkin;
                }

                items.Add(item);
            }
            return items;
        }

        //Generate Survey Questions for Survey Module
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

                var questionTitle = RandomQuestionTitle(random, 3, 5);
                var questionText = RandomQuestionText(random, questionTitle, 5, 20);

                var responseType = responseTypes[random.Next(responseTypes.Count)];
                var correctAnswer = isScored == "Yes" ? GenerateCorrectAnswer(responseType, random) : "";

                var item = new SurveyQuestionViewModel
                {
                    QuestionId = i,
                    QuestionNo = questionNo,
                    SurveyId = surveyId,
                    QuestionTitle = questionTitle,
                    QuestionText = questionText,
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

        private static string RandomQuestionTitle(Random random, int minWords, int maxWords)
        {
            var questionStarters = new List<string> { "What", "How", "Why", "When", "Which" };
            var wordList = new List<string>
            {
                "is", "the", "best", "way", "to", "solve", "this", "problem", "option", "method", "approach", "result", "choice",
                "task", "question", "issue", "decision", "situation", "analysis", "solution"
            };

            var words = new List<string> { questionStarters[random.Next(questionStarters.Count)] };
            words.AddRange(Enumerable.Range(0, random.Next(minWords - 1, maxWords)).Select(_ => wordList[random.Next(wordList.Count)]));

            return string.Join(" ", words) + "?";
        }

        private static string RandomQuestionText(Random random, string title, int minWords, int maxWords)
        {
            var wordList = new List<string>
            {
                "Please", "explain", "how", "you", "would", "approach", "this", "question", "given", "the", "following", "situation", "or", "problem",
                "outline", "your", "thoughts", "and", "suggestions", "for", "possible", "solutions", "or", "methods"
            };

            var words = new List<string> { title.Replace("?", ":") };
            words.AddRange(Enumerable.Range(0, random.Next(minWords, maxWords)).Select(_ => wordList[random.Next(wordList.Count)]));

            return string.Join(" ", words);
        }

        private static string GenerateCorrectAnswer(string responseType, Random random)
        {
            switch (responseType)
            {
                case "Single Select":
                    return GetSingleSelectAnswer(random);

                case "Multi Select":
                    return string.Join("; ", Enumerable.Range(0, random.Next(1, 4)).Select(_ => GetSingleSelectAnswer(random)));

                case "Yes/No":
                    return random.Next(0, 2) == 0 ? "Yes" : "No";

                case "Yes/No/NA":
                    return new List<string> { "Yes", "No", "NA" }[random.Next(3)];

                case "Agree/Disagree":
                    return random.Next(0, 2) == 0 ? "Agree" : "Disagree";

                case "Text":
                    return "Free Text Response"; // For Text, just use a placeholder response

                case "Re-Arrange":
                    return string.Join("; ", Enumerable.Range(1, 3).OrderBy(_ => random.Next()));

                default:
                    return "";
            }
        }

        private static string GetSingleSelectAnswer(Random random)
        {
            var options = new List<string> { "1", "2", "3", "4", "5", "A", "B", "C", "D", "Yes", "No" };
            return options[random.Next(options.Count)];
        }

        private static List<ModuleLDSDataViewModel> GenerateLDSRandomData()
        {
            var random = new Random();
            var items = new List<ModuleLDSDataViewModel>();

            var contentType = new List<string> { "Picture", "Audio", "Video", "URL" };

            DateTime effectiveFrom = new();
            DateTime effectiveTo = new();

            var savedContent = new List<string>();

            for (int i = 1; i <= 1000; i++)
            {
                MockDataHelperFunctions.GetEffectiveDates(ref effectiveFrom, ref effectiveTo, i);

                var content = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(3, 5));

                while (savedContent.Contains(content))
                    content = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(3, 5));

                savedContent.Add(content);

                var item = new ModuleLDSDataViewModel
                {
                    Id = i,
                    CategoryName = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(1, 2)),
                    CategoryDescription = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(3, 5)),
                    ContentType = SharedFunctions.CapitalizeFirst(contentType[random.Next(contentType.Count)]),
                    ContentDescription = content,
                    Duration = random.Next(0, 61),
                    EffectiveFrom = effectiveFrom.ToString("yyyy/MM/dd"),
                    EffectiveTo = effectiveTo.ToString("yyyy/MM/dd"),
                    TimeslotFrom = MockDataHelperFunctions.RandomTime(),
                    TimeslotTo = MockDataHelperFunctions.RandomTime(),
                    LastModifiedDate = DateTime.Now.AddMinutes(-random.Next(0, 50000)).ToString("yyyy/MM/dd HH:mm"),
                    UserIdLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineIdLastModified = MockDataHelperFunctions.GetRandomMachineID()
                };

                items.Add(item);
            }
            return items;
        }

        private static List<RssCategoryOverviewViewModel> GenerateRSSCategoriesRandomData()
        {
            var items = new List<RssCategoryOverviewViewModel>();

            for (int i = 1; i <= 10; i++)
            {
                var rssCat = new RssCategoryOverviewViewModel
                {
                    CategoryId = i,
                    CategoryName = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(1, 2)),
                    CategoryDescription = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(3, 5)),
                };
                items.Add(rssCat);
            }
            return items;
        }

        private static List<RssFeedOverviewViewModel> GenerateRSSFeedRandomData()
        {
            var items = new List<RssFeedOverviewViewModel>();

            for (int i = 1; i <= 10; i++)
            {
                var rssCat = new RssFeedOverviewViewModel
                {
                    CategoryId = i,
                    FeedId = i,
                    CategoryName = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(1, 2)),
                    FeedName = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(1, 2)),
                    FeedURL = $"https://www.{MockDataHelperFunctions.RandomString(1, 1)}.com",
                };
                items.Add(rssCat);
            }
            return items;
        }

        private static List<ContentLibraryCategoryModel> GenerateContentLibraryRandomData()
        {
            var random = new Random();
            var items = new List<ContentLibraryCategoryModel>();

            for (int i = 1; i <= 50; i++)
            {
                var contentLibCat = new ContentLibraryCategoryModel
                {
                    CategoryId = i,
                    CategoryName = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(1, 3)),
                    CategoryDescription = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(1, 5)),
                    ContentsCount = random.Next(320),
                    DateLastModified = DateTime.Now.AddMinutes(-random.Next(0, 50000)).ToString("yyyy/MM/dd HH:mm"),
                    UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineLastModified = MockDataHelperFunctions.GetRandomMachineID()
                };
                items.Add(contentLibCat);
            }

            return items;
        }

        private static ContentLibraryCategoryTree PopulateCategoryTree(int currentCategoryId, int maxDepth, int currentDepth = 1)
        {
            Random random = new Random();

            if (currentDepth > maxDepth) return null;

            var category = new ContentLibraryCategoryTree
            {
                CategoryId = currentCategoryId,
                CategoryName = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(1, 1)),
                CategoryDescription = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(1, 7)),
                ContentsCount = random.Next(0, 100),
                _children = null,
            };

            int childrenCount = random.Next(0, 6);

            for (int i = 0; i < childrenCount; i++)
            {
                var childCategory = PopulateCategoryTree(currentCategoryId * 10 + (i + 1), maxDepth, currentDepth + 1);
                if (childCategory != null)
                {
                    if (category._children == null)
                        category._children = new List<ContentLibraryCategoryTree>();

                    category._children.Add(childCategory);
                }
            }
            return category;
        }

        public static List<ContentLibraryCategoryTree> GenerateDummyDataContentLibraryCategories()
        {
            var items = new List<ContentLibraryCategoryTree>();
            var random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                var treeCategory = PopulateCategoryTree(i, random.Next(0, 5));

                if (treeCategory != null)
                    items.Add(treeCategory);
            }
            return items;
        }

        private static List<ContentLibraryContentModel> GenerateContentLibraryContents()
        {
            var items = new List<ContentLibraryContentModel>();

            var random = new Random();

            var contentType = new List<string> { "Picture", "Audio", "Video", "URL" };

            var allCategories = ModulesHelper.GetAllCategoriesInTree(ModulesMockData.AllContentLibraryCategories);
            var allCatIDs = allCategories.Select(c => c.CategoryId).ToList();

            List<string> options = new List<string> { "SCR", "DSK", "LCK" };
            int numberOfOptions = random.Next(1, options.Count + 1);

            DateTime effectiveFrom = new();
            DateTime effectiveTo = new();

            for (int i = 1; i <= 1000; i++)
            {
                MockDataHelperFunctions.GetEffectiveDates(ref effectiveFrom, ref effectiveTo, i);

                string[] selectedOptions = options.OrderBy(x => random.Next())
                                          .Take(numberOfOptions)
                                          .ToArray();

                var catID = allCatIDs[random.Next(allCatIDs.Count)];
                var catName = allCategories.FirstOrDefault(x => x.CategoryId == catID)?.CategoryName ?? "";

                var item = new ContentLibraryContentModel
                {
                    ContentId = i,
                    AdvertId = random.Next(101),
                    ProductId = random.Next(101),
                    CategoryId = catID,
                    CategoryName = catName,
                    AdvertDescription = SharedFunctions.CapitalizeFirst(MockDataHelperFunctions.RandomString(3, 5)),
                    ContentType = SharedFunctions.CapitalizeFirst(contentType[random.Next(contentType.Count)]),
                    ContentPath = "C:\\Users\\Resources\\Data\\Urgent\\",
                    Duration = random.Next(0, 61),
                    EffectiveFrom = effectiveFrom.ToString("yyyy/MM/dd"),
                    EffectiveTo = effectiveTo.ToString("yyyy/MM/dd"),
                    Archive = (random.Next(2) == 0 ? "No" : "Yes"),
                    TargetedModules = string.Join(";", selectedOptions),
                    DateLastModified = DateTime.Now.AddMinutes(-random.Next(0, 50000)).ToString("yyyy/MM/dd HH:mm"),
                    UserIdLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineIdLastModified = MockDataHelperFunctions.GetRandomMachineID(),
                };

                items.Add(item);
            }

            return items;
        }
    }
}
