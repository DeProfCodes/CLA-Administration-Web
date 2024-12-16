namespace CLA_Administration_Web.Helpers.MockData
{
    public class MockDataHelperFunctions
    {
        private static Random Random = new Random();

        public static string RandomTime()
        {
            return $"{Random.Next(0, 24):D2}:{Random.Next(0, 60):D2}";
        }

        public static DateTime RandomDateInRange(DateTime start, DateTime end)
        {
            int range = (end - start).Days;
            return start.AddDays(Random.Next(range));
        }

        public static string RandomString(int minWords, int maxWords)
        {
            var wordList = new List<string>
            {
                "random", "survey", "data", "user", "information", "value", "result", "questionnaire", "response", "choice",
                "lift", "happiness", "optional", "mandatory", "feedback", "evaluation", "completion", "rate", "option", "field",
                "section", "page", "submit", "save", "progress", "time", "record", "analysis", "report", "summary", "point",
                "critical", "flagged", "marked", "highlight", "understand", "decision", "query", "system", "entry", "method", "CLA",
                "Corporate Voice", "Marketing Company", "Employee engagement", "Admin Tool", "Popups", "Surveys", "Tickers"
            };

            int wordCount = Random.Next(minWords, maxWords + 1);
            var words = Enumerable.Range(0, wordCount).Select(_ => wordList[Random.Next(wordList.Count)]);

            return string.Join(" ", words);
        }


        public static DateTime RandomDateInSameMonth(DateTime effectiveFrom)
        {
            int daysInMonth = DateTime.DaysInMonth(effectiveFrom.Year, effectiveFrom.Month);
            int day = Random.Next(effectiveFrom.Day, daysInMonth + 1);
            return new DateTime(effectiveFrom.Year, effectiveFrom.Month, day);
        }

        public static void GetEffectiveDates(ref DateTime effectiveFrom, ref DateTime effectiveTo, int index)
        {
            var today = DateTime.Today;
            double sameMonthProbability = 1.00;

            var startDate = DateTime.Now.AddMonths(-9);
            var endDate = DateTime.Now.AddMonths(9);

            int caseSelector = Random.Next(3);

            switch (caseSelector)
            {
                case 0:
                    effectiveFrom = RandomDateInRange(startDate, today.AddDays(-1));
                    effectiveTo = RandomDateInRange(effectiveFrom, today.AddDays(-1));
                    break;

                case 1:
                    effectiveFrom = RandomDateInRange(startDate, today.AddDays(-1));

                    if (Random.NextDouble() <= sameMonthProbability)
                    {
                        effectiveTo = RandomDateInSameMonth(effectiveFrom);
                    }
                    else
                    {
                        effectiveTo = RandomDateInRange(today, endDate);
                    }
                    break;

                case 2:
                    effectiveFrom = RandomDateInRange(today.AddDays(1), endDate);

                    if (Random.NextDouble() <= sameMonthProbability)
                    {
                        effectiveTo = RandomDateInSameMonth(effectiveFrom);
                    }
                    else
                    {
                        effectiveTo = RandomDateInRange(effectiveFrom, endDate);
                    }
                    break;

                default:
                    effectiveFrom = today;
                    effectiveTo = today;
                    break;
            }
        }

        public static string GetRandomFirstname()
        {
            var usersList = new List<string> { "Ndhuvazi", "Lege", "Sinethemba", "Lebo", "Administrator", "Cathrine", "Larry", "Tarry", "Nyiko", "Proficient" };

            return usersList[Random.Next(usersList.Count)];
        }

        public static string GetRandomLastname()
        {
            var usersList = new List<string> { "Mkansi", "Baloyi", "Ncube", "Scoffield", "Administrator", "Mason", "Larry", "Bonty", "Brice", "Micassa" };

            return usersList[Random.Next(usersList.Count)];
        }

        public static string GetRandomUserID()
        {
            var usersList = new List<string> { "NdhuvaziM", "LegeB", "SinethembaS", "LeboC", "Administrator", "CathrineT", "LarryM", "Tarryn", "NyikoB", "ProficientX" };

            return usersList[Random.Next(usersList.Count)];
        }

        public static string GetRandomMachineID()
        {
            var machinesList = new List<string> { "NdhuvaziM-PC", "LegeB-PC", "Sinethemba-PC", "LeboC-PC", "Administrator-PC", "CathrineT-PC", "LarryM-PC", "Tarryn-PC" };

            return machinesList[Random.Next(machinesList.Count)];
        }

        public static string GetRandomDomainName()
        {
            var domainsList = new List<string> { "NTHDIM", "Admin", "Test-Domain", "Corporate-Voice" };

            return domainsList[Random.Next(domainsList.Count)];
        }


    }
}
