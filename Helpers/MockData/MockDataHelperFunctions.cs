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

        public static string GetRandomCustomUserNumbers()
        {
            var usersListnumber = new List<string>
            {
                "100", "900", "80", "200", "50", "1000", "800", "62002", "2985", "6033",
                "1234", "5678", "91011", "31415", "1617", "1820", "2122", "2324", "2500",
                "3333", "4444", "5555", "6666", "7777", "8888", "9999", "1020", "3060",
                "4050", "5060", "6070", "7080", "8090", "9000", "10000", "12000", "15000"
            };

            return usersListnumber[Random.Next(usersListnumber.Count)];
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

        public static string GetRandomActiveConnections()
        {
            var activeconnectionlist = new List<string> { "123", "50", "NTHWEB", "nthuser", ".net SQLClient", "Select" };

            return activeconnectionlist[Random.Next(activeconnectionlist.Count)];
        }

        public static string GetRandomConnectionsID()
        {
            var conectionidslist = new List<string> { "123", "150", "1253", "1203", "1273", "2897" };

            return conectionidslist[Random.Next(conectionidslist.Count)];
        }

        public static string GetRandomConnectionsMinutes()
        {
            var conectionMinuteslist = new List<string> { "3", "5", "7", "9", "10", "50" };

            return conectionMinuteslist[Random.Next(conectionMinuteslist.Count)];
        }

        public static string GetRandomConnectionsHost()
        {
            var conectionHostlist = new List<string> { "NTHWEB", "NTHTERACO", "NTHTERACO2", "NTHDEV", "NTHTERACO3" };

            return conectionHostlist[Random.Next(conectionHostlist.Count)];
        }

        public static string GetRandomConnectionsLogin()
        {
            var conectionLoginlist = new List<string> { "nthuser", "user1", "user2", "user3", "user4" };

            return conectionLoginlist[Random.Next(conectionLoginlist.Count)];
        }
        public static string GetRandomConnectionsProgram()
        {
            var conectionProgramlist = new List<string> { ".net sqlclient", ".netsql", " ", " ", " " };

            return conectionProgramlist[Random.Next(conectionProgramlist.Count)];
        }

        public static string GetRandomConnectionsCommand()
        {
            var conectionCommandlist = new List<string> { ".net sqlclient", ".netsql", " ", " ", " " };

            return conectionCommandlist[Random.Next(conectionCommandlist.Count)];
        }

        // Font-Related Mock Data
        public static string FontFamilies()
        {
            var fontFamilies = new List<string> { "Arial", "Verdana", "Times New Roman", "Courier New", "Georgia" };
            return fontFamilies[Random.Next(fontFamilies.Count)];
        }

        public static string FontWeight()
        {
            var fontWeights = new List<string> { "normal", "bold", "lighter" };
            return fontWeights[Random.Next(fontWeights.Count)];
        }

        public static int FontSize()
        {
            // Random font size between 10 and 50
            return Random.Next(10, 51);
        }

        public static string FontFamily()
        {
            return FontFamilies();
        }

        public static int FontWidth()
        {
            // Random font width between 100 and 900 (CSS valid font-weight values)
            var fontWidths = new List<int> { 100, 200, 300, 400, 500, 600, 700, 800, 900 };
            return fontWidths[Random.Next(fontWidths.Count)];
        }

        public static string HeadingFontFamily()
        {
            return FontFamilies();
        }

        // Color-Related Mock Data
        public static string RandomHexColor()
        {
            // Generate a random color in hex format
            return $"#{Random.Next(0x1000000):X6}";
        }

        public static string NamedColor()
        {
            var namedColors = new List<string>
            {
                "Red", "Green", "Blue", "Yellow", "Orange", "Purple", "Cyan", "Magenta", "Black", "White", "Gray"
            };
            return namedColors[Random.Next(namedColors.Count)];
        }
        public static string FontStyle()
        {
            var fontStyles = new List<string> { "normal", "italic", "oblique" };
            return fontStyles[Random.Next(fontStyles.Count)];
        }

        public static string RGBAColor()
        {
            // Generate a random RGBA color
            int r = Random.Next(256);
            int g = Random.Next(256);
            int b = Random.Next(256);
            double a = Math.Round(Random.NextDouble(), 2); // Alpha between 0.0 and 1.0
            return $"rgba({r}, {g}, {b}, {a})";
        }

        public static string BackgroundColor()
        {
            return RandomHexColor(); // Use RandomHexColor for background colors
        }

        public static string TextColor()
        {
            return RandomHexColor(); // Use RandomHexColor for text colors
        }

        public static string BorderColor()
        {
            return NamedColor(); // Use NamedColor for border colors
        }

    }
}
