using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Survey
{
    public class SurveyLegendTransposed
    {
        [JsonProperty("Question_Title")]
        public string QuestionTitle { get; set; }

        [JsonProperty("Question_Position")]
        public int QuestionPosition { get; set; }

        [JsonProperty("Question_Text")]
        public string QuestionText { get; set; }

        [JsonProperty("Question_is_Scored?")]
        public int QuestionIsScored { get; set; }
    }
}
