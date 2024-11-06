using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Survey
{
    public class SurveyOptInNoResponse
    {
        [JsonProperty("USER_ID")]
        public string UserId { get; set; }

        [JsonProperty("Machine_Id")]
        public string MachineId { get; set; }

        [JsonProperty("Is_Survey_Complete")]
        public int IsSurveyComplete { get; set; }

        [JsonProperty("Survey_Opt_In")]
        public int SurveyOptIn { get; set; }

        [JsonProperty("Response_Duration")]
        public string ResponseDuration { get; set; }

        [JsonProperty("Snooze_Count")]
        public string SnoozeCount { get; set; }
    }
}
