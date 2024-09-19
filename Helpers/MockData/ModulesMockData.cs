using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.ViewModels.Modules;

namespace CLA_Administration_Web.Helpers.MockData
{
    public class ModulesMockData
    {
        public static List<ModuleDataViewModel> AllPopupsData { get; set; } = GenerateRandomData();

        public static List<ModuleDataViewModel> AllTickersData { get; set; } = GenerateRandomData();

        public static List<ModuleDataViewModel> AllSurveysData { get; set; } = GenerateRandomData();

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

        private static List<ModuleDataViewModel> GenerateRandomData()
        {
            var random = new Random();
            var items = new List<ModuleDataViewModel>();

            var today = DateTime.Today;

            var usersList = new List<string> { "NdhuvaziM", "LegeB", "SinethembaS", "LeboC", "Administrator", "CathrineT", "LarryM", "Tarryn" };

            for (int i = 1; i <= 50; i++)
            {
                // Choose randomization case for EffectiveFrom and EffectiveTo
                DateTime effectiveFrom, effectiveTo;

                int caseSelector = (i <= 17 ? 0 : (i <= 35 ? 1 : 2));
                switch (caseSelector)
                {
                    // Case 1: EffectiveFrom and EffectiveTo both earlier than today
                    case 0:
                        effectiveFrom = RandomDateInRange(new DateTime(2024, 1, 1), today.AddDays(-1), random);
                        effectiveTo = RandomDateInRange(effectiveFrom, today.AddDays(-1), random);
                        break;

                    // Case 2: EffectiveFrom earlier than today, and EffectiveTo is today or later
                    case 1:
                        effectiveFrom = RandomDateInRange(new DateTime(2024, 1, 1), today.AddDays(-1), random);
                        effectiveTo = RandomDateInRange(today, new DateTime(2024, 12, 31), random);
                        break;

                    // Case 3: Both EffectiveFrom and EffectiveTo later than today
                    case 2:
                        effectiveFrom = RandomDateInRange(today.AddDays(1), new DateTime(2024, 12, 31), random);
                        effectiveTo = RandomDateInRange(effectiveFrom, new DateTime(2024, 12, 31), random);
                        break;

                    default:
                        effectiveFrom = today;
                        effectiveTo = today;
                        break;
                }
                
                var item = new ModuleDataViewModel
                {
                    Id = i,
                    HeaderText = RandomString(random, 5, 10),
                    BodyText = RandomString(random, 20, 50),
                    EffectiveFrom = effectiveFrom.ToString("yyyy/MM/dd"),
                    EffectiveTo = effectiveTo.ToString("yyyy/MM/dd"),
                    TimeslotFrom = RandomTime(random),
                    TimeslotTo = RandomTime(random),
                    LastModifiedDate = DateTime.Now.AddMinutes(-random.Next(0, 50000)).ToString("yyyy/MM/dd HH:mm"),
                    UserIdLastModified = usersList[random.Next(0,7)],
                };

                items.Add(item);
            }
            return items;
        }
    }
}
