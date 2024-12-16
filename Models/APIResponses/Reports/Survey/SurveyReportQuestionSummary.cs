using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Survey
{
    public class SurveyReportQuestionSummary
    {
        [JsonProperty("Question_Title")]
        public string QuestionTitle { get; set; }

        [JsonProperty("Question_Position")]
        public int QuestionPosition { get; set; }

        [JsonProperty("Question_Text")]
        public string QuestionText { get; set; }

        [JsonProperty("Question_ID")]
        public int QuestionId { get; set; }

        [JsonProperty("Question_Type")]
        public string QuestionType { get; set; }

        [JsonProperty("Response_ID")]
        public int ResponseId { get; set; }

        [JsonProperty("Response")]
        public string Response { get; set; }

        [JsonProperty("No_Responses")]
        public int NoResponses { get; set; }

        [JsonProperty("Perc_Responses")]
        public int PercResponses { get; set; }

        [JsonProperty("No_Targeted")]
        public int NoTargeted { get; set; }
    }
}
