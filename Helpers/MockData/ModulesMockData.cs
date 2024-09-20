using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PSTR;
using CLA_Administration_Web.ViewModels.Shared;
using System.Net.Mime;

namespace CLA_Administration_Web.Helpers.MockData
{
    public class ModulesMockData
    {
        //PSTR
        public static class StagingData
        {
            public static List<ModulePSTRDataViewModel> AllPopupsData { get; set; } = GeneratePSTRRandomData();

            public static List<ModulePSTRDataViewModel> AllTickersData { get; set; } = GeneratePSTRRandomData();

            public static List<ModulePSTRDataViewModel> AllSurveysData { get; set; } = GeneratePSTRRandomData();

            public static List<SurveyQuestionViewModel> AllSurveyQuestions { get; set; } = GenerateSurveyQuestions();

            //LDS
            public static List<ModuleLDSDataViewModel> AllScreensaversData { get; set; } = GenerateLDSRandomData();

            public static List<ModuleLDSDataViewModel> AllLockedDesktopsData { get; set; } = GenerateLDSRandomData();

            public static List<ModuleLDSDataViewModel> AllDesktopsData { get; set; } = GenerateLDSRandomData();
        }

        public static class LiveData
        {
            public static List<ModulePSTRDataViewModel> AllPopupsData { get; set; } = GeneratePSTRRandomData();

            public static List<ModulePSTRDataViewModel> AllTickersData { get; set; } = GeneratePSTRRandomData();

            public static List<ModulePSTRDataViewModel> AllSurveysData { get; set; } = GeneratePSTRRandomData();

            public static List<SurveyQuestionViewModel> AllSurveyQuestions { get; set; } = GenerateSurveyQuestions();

            //LDS
            public static List<ModuleLDSDataViewModel> AllScreensaversData { get; set; } = GenerateLDSRandomData();

            public static List<ModuleLDSDataViewModel> AllLockedDesktopsData { get; set; } = GenerateLDSRandomData();

            public static List<ModuleLDSDataViewModel> AllDesktopsData { get; set; } = GenerateLDSRandomData();
        }

        // Generate Module Data for Popups, Tickers, Surveys
        private static List<ModulePSTRDataViewModel> GeneratePSTRRandomData()
        {
            var random = new Random();
            var items = new List<ModulePSTRDataViewModel>();

            var today = DateTime.Today;

            var usersList = new List<string> { "NdhuvaziM", "LegeB", "SinethembaS", "LeboC", "Administrator", "CathrineT", "LarryM", "Tarryn" };

            for (int i = 1; i <= 50; i++)
            {
                DateTime effectiveFrom, effectiveTo;

                int caseSelector = (i <= 17 ? 0 : (i <= 35 ? 1 : 2));
                switch (caseSelector)
                {
                    case 0:
                        effectiveFrom = RandomDateInRange(new DateTime(2024, 1, 1), today.AddDays(-1), random);
                        effectiveTo = RandomDateInRange(effectiveFrom, today.AddDays(-1), random);
                        break;

                    case 1:
                        effectiveFrom = RandomDateInRange(new DateTime(2024, 1, 1), today.AddDays(-1), random);
                        effectiveTo = RandomDateInRange(today, new DateTime(2024, 12, 31), random);
                        break;

                    case 2:
                        effectiveFrom = RandomDateInRange(today.AddDays(1), new DateTime(2024, 12, 31), random);
                        effectiveTo = RandomDateInRange(effectiveFrom, new DateTime(2024, 12, 31), random);
                        break;

                    default:
                        effectiveFrom = today;
                        effectiveTo = today;
                        break;
                }

                var item = new ModulePSTRDataViewModel
                {
                    Id = i,
                    HeaderText = RandomString(random, 5, 10),
                    BodyText = RandomString(random, 20, 50),
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
                "valid", "invalid", "optional", "mandatory", "feedback", "evaluation", "completion", "rate", "option", "field",
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

        private static List<ModuleLDSDataViewModel> GenerateLDSRandomData()
        {
            var random = new Random();
            var items = new List<ModuleLDSDataViewModel>();

            var today = DateTime.Today;

            var usersList = new List<string> { "NdhuvaziM", "LegeB", "SinethembaS", "LeboC", "Administrator", "CathrineT", "LarryM", "Tarryn" };
            var contentType = new List<string> { "Picture", "Audio", "Video", "URL" };

            for (int i = 1; i <= 50; i++)
            {
                DateTime effectiveFrom, effectiveTo;

                int caseSelector = (i <= 17 ? 0 : (i <= 35 ? 1 : 2));
                switch (caseSelector)
                {
                    case 0:
                        effectiveFrom = RandomDateInRange(new DateTime(2024, 1, 1), today.AddDays(-1), random);
                        effectiveTo = RandomDateInRange(effectiveFrom, today.AddDays(-1), random);
                        break;

                    case 1:
                        effectiveFrom = RandomDateInRange(new DateTime(2024, 1, 1), today.AddDays(-1), random);
                        effectiveTo = RandomDateInRange(today, new DateTime(2024, 12, 31), random);
                        break;

                    case 2:
                        effectiveFrom = RandomDateInRange(today.AddDays(1), new DateTime(2024, 12, 31), random);
                        effectiveTo = RandomDateInRange(effectiveFrom, new DateTime(2024, 12, 31), random);
                        break;

                    default:
                        effectiveFrom = today;
                        effectiveTo = today;
                        break;
                }

                var item = new ModuleLDSDataViewModel
                {
                    Id = i,
                    CategoryName = RandomString(random, 1, 2),
                    CategoryDescription = RandomString(random, 3, 5),
                    ContentType = contentType[random.Next(contentType.Count)],
                    ContentDescription = RandomString(random, 1, 2),
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

    }
}
