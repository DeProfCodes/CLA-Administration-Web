using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Shared;
using CLA_Administration_Web.ViewModels.Modules.ContentLibrary;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLA_Administration_Web.ViewModels.Modules.Rss;
using CLA_Administration_Web.ViewModels.Shared;
using System;
using System.Net.Mime;

namespace CLA_Administration_Web.Helpers.MockData
{
    public class ModulesMockData
    {
        public static class StagingData
        {
            //PST
            public static List<ModulePSTDataViewModel> AllPopupsData { get; set; } = GeneratePSTRandomData();

            public static List<ModulePSTDataViewModel> AllTickersData { get; set; } = GeneratePSTRandomData();

            public static List<ModulePSTDataViewModel> AllSurveysData { get; set; } = GeneratePSTRandomData();

            public static List<SurveyQuestionViewModel> AllSurveyQuestions { get; set; } = GenerateSurveyQuestions();

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
            public static List<ModulePSTDataViewModel> AllPopupsData { get; set; } = GeneratePSTRandomData();

            public static List<ModulePSTDataViewModel> AllTickersData { get; set; } = GeneratePSTRandomData();

            public static List<ModulePSTDataViewModel> AllSurveysData { get; set; } = GeneratePSTRandomData();

            public static List<SurveyQuestionViewModel> AllSurveyQuestions { get; set; } = GenerateSurveyQuestions();

            //LDS
            public static List<ModuleLDSDataViewModel> AllScreensaversData { get; set; } = GenerateLDSRandomData();

            public static List<ModuleLDSDataViewModel> AllLockedDesktopsData { get; set; } = GenerateLDSRandomData();

            public static List<ModuleLDSDataViewModel> AllDesktopsData { get; set; } = GenerateLDSRandomData();

            public static List<RssCategoryOverviewViewModel> AllRSSCategories { get; set; } = GenerateRSSCategoriesRandomData();

            public static List<RssFeedOverviewViewModel> AllRSSFeed { get; set; } = GenerateRSSFeedRandomData();
        }

        public static List<ContentLibraryCategoryModel> AllContentLibraryCategories { get; set; } = GenerateContentLibraryRandomData();


        // Generate Module Data for Popups, Tickers, Surveys
        private static List<ModulePSTDataViewModel> GeneratePSTRandomData()
        {
            var random = new Random();
            var items = new List<ModulePSTDataViewModel>();

            var usersList = new List<string> { "NdhuvaziM", "LegeB", "SinethembaS", "LeboC", "Administrator", "CathrineT", "LarryM", "Tarryn" };
            var machinesList = new List<string> { "NdhuvaziM-PC", "LegeB-PC", "Sinethemba-PC", "LeboC-PC", "Administrator-PC", "CathrineT-PC", "LarryM-PC", "Tarryn-PC" };

            DateTime effectiveFrom = new();
            DateTime effectiveTo = new();

            for (int i = 1; i <= 1000; i++)
            {
                GetEffectiveDates(ref effectiveFrom, ref effectiveTo, i);

                var item = new ModulePSTDataViewModel
                {
                    Id = i,
                    HeaderText = RandomString(random, 5, 10),
                    BodyText = RandomString(random, 20, 50),
                    EffectiveFrom = effectiveFrom.ToString("yyyy/MM/dd"),
                    EffectiveTo = effectiveTo.ToString("yyyy/MM/dd"),
                    TimeslotFrom = RandomTime(random),
                    TimeslotTo = RandomTime(random),
                    LastModifiedDate = DateTime.Now.AddMinutes(-random.Next(0, 50000)).ToString("yyyy/MM/dd HH:mm"),
                    UserIdLastModified = usersList[random.Next(usersList.Count)],
                    MachineLastModified = machinesList[random.Next(machinesList.Count)]
                };

                items.Add(item);
            }
            return items;
        }

        private static string RandomTime(Random random)
        {
            return $"{random.Next(0, 24):D2}:{random.Next(0, 60):D2}";
        }

        private static DateTime RandomDateInRange(DateTime start, DateTime end, Random random)
        {
            int range = (end - start).Days;
            return start.AddDays(random.Next(range));
        }

        private static string RandomString(Random random, int minWords, int maxWords)
        {
            var wordList = new List<string>
            {
                "random", "survey", "data", "user", "information", "value", "result", "questionnaire", "response", "choice",
                "lift", "happiness", "optional", "mandatory", "feedback", "evaluation", "completion", "rate", "option", "field",
                "section", "page", "submit", "save", "progress", "time", "record", "analysis", "report", "summary", "point",
                "critical", "flagged", "marked", "highlight", "understand", "decision", "query", "system", "entry", "method", "CLA",
                "Corporate Voice", "Marketing Company", "Employee engagement", "Admin Tool", "Popups", "Surveys", "Tickers"
            };

            int wordCount = random.Next(minWords, maxWords + 1);
            var words = Enumerable.Range(0, wordCount).Select(_ => wordList[random.Next(wordList.Count)]);

            return string.Join(" ", words);
        }

        
        //Generate Survey Questions for Survey Module
        private static List<SurveyQuestionViewModel> GenerateSurveyQuestions()
        {
            var random = new Random();
            var items = new List<SurveyQuestionViewModel>();
            var surveyQuestionCounters = new Dictionary<int, int>();

            var responseTypes = new List<string> { "Single Select", "Multi Select", "Yes/No", "Yes/No/NA", "Agree/Disagree", "Text", "Re-Arrange" };
            var usersList = new List<string> { "NdhuvaziM", "LegeB", "SinethembaS", "LeboC", "Administrator", "CathrineT", "LarryM", "Tarryn" };
            var machinesList = new List<string> { "NdhuvaziM-PC", "LegeB-PC", "Sinethemba-PC", "LeboC-PC", "Administrator-PC", "CathrineT-PC", "LarryM-PC", "Tarryn-PC" };

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
                    MachineLastModified = machinesList[random.Next(0, 8)],
                    UserIdLastModified = usersList[random.Next(0, 8)],
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

        private static DateTime RandomDateInSameMonth(DateTime effectiveFrom, Random random)
        {
            int daysInMonth = DateTime.DaysInMonth(effectiveFrom.Year, effectiveFrom.Month);
            int day = random.Next(effectiveFrom.Day, daysInMonth + 1); 
            return new DateTime(effectiveFrom.Year, effectiveFrom.Month, day);
        }

        static void GetEffectiveDates(ref DateTime effectiveFrom, ref DateTime effectiveTo, int index)
        {
            var random = new Random();
            var today = DateTime.Today;
            double sameMonthProbability = 1.00;

            var startDate = DateTime.Now.AddMonths(-9);
            var endDate = DateTime.Now.AddMonths(9);

            int caseSelector = random.Next(3);

            switch (caseSelector)
            {
                case 0:
                    effectiveFrom = RandomDateInRange(startDate, today.AddDays(-1), random);
                    effectiveTo = RandomDateInRange(effectiveFrom, today.AddDays(-1), random);
                    break;

                case 1:
                    effectiveFrom = RandomDateInRange(startDate, today.AddDays(-1), random);

                    if (random.NextDouble() <= sameMonthProbability)
                    {
                        effectiveTo = RandomDateInSameMonth(effectiveFrom, random);
                    }
                    else
                    {
                        effectiveTo = RandomDateInRange(today, endDate, random);
                    }
                    break;

                case 2:
                    effectiveFrom = RandomDateInRange(today.AddDays(1), endDate, random);

                    if (random.NextDouble() <= sameMonthProbability)
                    {
                        effectiveTo = RandomDateInSameMonth(effectiveFrom, random);
                    }
                    else
                    {
                        effectiveTo = RandomDateInRange(effectiveFrom, endDate, random);
                    }
                    break;

                default:
                    effectiveFrom = today;
                    effectiveTo = today;
                    break;
            }
        }

        private static List<ModuleLDSDataViewModel> GenerateLDSRandomData()
        {
            var random = new Random();
            var items = new List<ModuleLDSDataViewModel>();

            var usersList = new List<string> { "NdhuvaziM", "LegeB", "SinethembaS", "LeboC", "Administrator", "CathrineT", "LarryM", "Tarryn" };
            var contentType = new List<string> { "Picture", "Audio", "Video", "URL" };

            DateTime effectiveFrom = new();
            DateTime effectiveTo = new();

            var savedContent = new List<string>();

            for (int i = 1; i <= 1000; i++)
            {
                GetEffectiveDates(ref effectiveFrom, ref effectiveTo, i);

                var content = SharedFunctions.CapitalizeFirst(RandomString(random, 3, 5));

                while(savedContent.Contains(content))
                    content = SharedFunctions.CapitalizeFirst(RandomString(random, 3, 5));

                savedContent.Add(content);

                var item = new ModuleLDSDataViewModel
                {
                    Id = i,
                    CategoryName = SharedFunctions.CapitalizeFirst(RandomString(random, 1, 2)),
                    CategoryDescription = SharedFunctions.CapitalizeFirst(RandomString(random, 3, 5)),
                    ContentType = SharedFunctions.CapitalizeFirst(contentType[random.Next(contentType.Count)]),
                    ContentDescription = content,
                    Duration = random.Next(0,61),
                    EffectiveFrom = effectiveFrom.ToString("yyyy/MM/dd"),
                    EffectiveTo = effectiveTo.ToString("yyyy/MM/dd"),
                    TimeslotFrom = RandomTime(random),
                    TimeslotTo = RandomTime(random),
                    LastModifiedDate = DateTime.Now.AddMinutes(-random.Next(0, 50000)).ToString("yyyy/MM/dd HH:mm"),
                    UserIdLastModified = usersList[random.Next(0, 8)],
                };

                items.Add(item);
            }
            return items;
        }

        private static List<RssCategoryOverviewViewModel> GenerateRSSCategoriesRandomData()
        {
            var random = new Random();
            var items = new List<RssCategoryOverviewViewModel>();

            for (int i = 1; i <= 10; i++)
            {
                var rssCat = new RssCategoryOverviewViewModel
                {
                    CategoryId = i,
                    CategoryName = SharedFunctions.CapitalizeFirst(RandomString(random, 1, 2)),
                    CategoryDescription = SharedFunctions.CapitalizeFirst(RandomString(random, 3, 5)),
                };
                items.Add(rssCat);
            }
            return items;
        }

        private static List<RssFeedOverviewViewModel> GenerateRSSFeedRandomData()
        {
            var random = new Random();
            var items = new List<RssFeedOverviewViewModel>();

            for (int i = 1; i <= 10; i++)
            {
                var rssCat = new RssFeedOverviewViewModel
                {
                    CategoryId = i,
                    FeedId = i,
                    CategoryName = SharedFunctions.CapitalizeFirst(RandomString(random, 1, 2)),
                    FeedName = SharedFunctions.CapitalizeFirst(RandomString(random, 1, 2)),
                    FeedURL = $"https://www.{RandomString(random, 1,1)}.com",
                };
                items.Add(rssCat);
            }
            return items;
        }

        private static List<ContentLibraryCategoryModel> GenerateContentLibraryRandomData()
        {
            var random = new Random();
            var items = new List<ContentLibraryCategoryModel>();

            var usersList = new List<string> { "NdhuvaziM", "LegeB", "SinethembaS", "LeboC", "Administrator", "CathrineT", "LarryM", "Tarryn" };
            var machinesList = new List<string> { "NdhuvaziM-PC", "LegeB-PC", "Sinethemba-PC", "LeboC-PC", "Administrator-PC", "CathrineT-PC", "LarryM-PC", "Tarryn-PC" };

            for (int i = 1; i <= 50; i++)
            {
                var contentLibCat = new ContentLibraryCategoryModel
                {
                    CategoryId = i,
                    CategoryName = SharedFunctions.CapitalizeFirst(RandomString(random, 1, 3)),
                    CategoryDescription = SharedFunctions.CapitalizeFirst(RandomString(random, 1, 5)),
                    ContentsCount = random.Next(320),
                    UserLastModified = usersList[random.Next(usersList.Count)],
                    MachineLastModified = machinesList[random.Next(machinesList.Count)]
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
                CategoryName = SharedFunctions.CapitalizeFirst(RandomString(random, 1, 1)),
                CategoryDescription = SharedFunctions.CapitalizeFirst(RandomString(random, 1, 7)),
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
                
                if(treeCategory != null)
                    items.Add(treeCategory);
            }
            return items;
        }
    }
}
