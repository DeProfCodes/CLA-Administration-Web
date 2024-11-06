using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Survey
{
    public class SurveyReportQuestionDetails
    {
        [JsonProperty("User_ID")]
        public string UserId { get; set; }

        [JsonProperty("Machine_ID")]
        public string MachineId { get; set; }

        [JsonProperty("Is_Survey_Complete")]
        public int IsSurveyComplete { get; set; }

        [JsonProperty("Survey_Opt_In")]
        public int SurveyOptIn { get; set; }

        [JsonProperty("Last_Update_DT_User")]
        public DateTime? LastUpdateDtUser { get; set; }

        [JsonProperty("Last_Update_DT_Machine")]
        public DateTime? LastUpdateDtMachine { get; set; }

        [JsonProperty("User_Name")]
        public string UserName { get; set; }

        [JsonProperty("Machine_Name")]
        public string MachineName { get; set; }

        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [JsonProperty("Question_Title")]
        public string QuestionTitle { get; set; }

        [JsonProperty("Question_Position")]
        public int QuestionPosition { get; set; }

        [JsonProperty("Question_Text")]
        public string QuestionText { get; set; }

        [JsonProperty("Is_Scored")]
        public int IsScored { get; set; }

        [JsonProperty("Question_ID")]
        public int QuestionId { get; set; }

        [JsonProperty("Question_Type")]
        public int QuestionType { get; set; }

        [JsonProperty("Response_ID")]
        public int ResponseId { get; set; }

        [JsonProperty("Response")]
        public string Response { get; set; }

        [JsonProperty("Mark")]
        public string Mark { get; set; }

        [JsonProperty("Response_Weighting")]
        public int ResponseWeighting { get; set; }

        [JsonProperty("Response_DT")]
        public DateTime? ResponseDt { get; set; }

        [JsonProperty("UseMachineID")]
        public int UseMachineId { get; set; }

        [JsonProperty("Is_Anonymous")]
        public int IsAnonymous { get; set; }
    }
}
