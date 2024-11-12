using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.CampaignDispatch
{
    public class DispatchSurveyResponse
    {
        [JsonProperty("Environment")]
        public string? Environment { get; set; }

        [JsonProperty("Targeted")]
        public string? Targeted { get; set; }

        [JsonProperty("Survey_User_Last_Modified")]
        public string? SurveyUserLastModified { get; set; }

        [JsonProperty("Survey_Eff_From")]
        public DateTime? SurveyEffFrom { get; set; }

        [JsonProperty("Survey_Eff_To")]
        public DateTime? SurveyEffTo { get; set; }

        [JsonProperty("Survey_Timeslot_From")]
        public string? SurveyTimeslotFrom { get; set; }

        [JsonProperty("Survey_Timeslot_To")]
        public string? SurveyTimeslotTo { get; set; }

        [JsonProperty("Survey_Is_Automated")]
        public int? SurveyIsAutomated { get; set; }

        [JsonProperty("Survey_Provider_ID")]
        public int? SurveyProviderId { get; set; }

        [JsonProperty("Survey_Critical_Snoozes")]
        public int? SurveyCriticalSnoozes { get; set; }

        [JsonProperty("Survey_Critical_DateTime")]
        public DateTime? SurveyCriticalDateTime { get; set; }

        [JsonProperty("Survey_Survey_ID")]
        public int? SurveySurveyId { get; set; }

        [JsonProperty("Survey_Survey_Title")]
        public string? SurveySurveyTitle { get; set; }

        [JsonProperty("Survey_Introduction_Message")]
        public string? SurveyIntroductionMessage { get; set; }

        [JsonProperty("Survey_Conclusion_Message")]
        public string? SurveyConclusionMessage { get; set; }

        [JsonProperty("Survey_Survey_Urgency")]
        public int? SurveySurveyUrgency { get; set; }

        [JsonProperty("Survey_Delivery_Method")]
        public int? SurveyDeliveryMethod { get; set; }

        [JsonProperty("Survey_Is_Published")]
        public int? SurveyIsPublished { get; set; }

        [JsonProperty("Survey_Show_Previous")]
        public int? SurveyShowPrevious { get; set; }

        [JsonProperty("Survey_Show_Export")]
        public int? SurveyShowExport { get; set; }

        [JsonProperty("Survey_Allow_Completed_Recall")]
        public int? SurveyAllowCompletedRecall { get; set; }

        [JsonProperty("Survey_Require_Verification")]
        public int? SurveyRequireVerification { get; set; }

        [JsonProperty("Survey_Randomize_Questions")]
        public int? SurveyRandomizeQuestions { get; set; }

        [JsonProperty("Survey_Show_Correct_Answer")]
        public int? SurveyShowCorrectAnswer { get; set; }

        [JsonProperty("Survey_Acceptable_Score")]
        public int? SurveyAcceptableScore { get; set; }

        [JsonProperty("Survey_Parent_Survey_ID")]
        public int? SurveyParentSurveyId { get; set; }
    }
}
