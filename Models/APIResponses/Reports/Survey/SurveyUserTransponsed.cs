using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Survey
{
    public class SurveyUserTransposed
    {
        [JsonProperty("Survey_ID")]
        public int? SurveyId { get; set; }

        [JsonProperty("User_ID")]
        public string? UserId { get; set; }

        [JsonProperty("Machine_ID")]
        public string? MachineId { get; set; }

        [JsonProperty("Q1")]
        public string? Question1 { get; set; }

        [JsonProperty("Q2")]
        public string? Question2 { get; set; }

        [JsonProperty("Q3")]
        public string? Question3 { get; set; }

        [JsonProperty("Q4")]
        public string? Question4 { get; set; }

        [JsonProperty("Q5")]
        public string? Question5 { get; set; }

        [JsonProperty("Q6")]
        public string? Question6 { get; set; }

        [JsonProperty("Q7")]
        public string? Question7 { get; set; }

        [JsonProperty("Q8")]
        public string? Question8 { get; set; }
    }
}
