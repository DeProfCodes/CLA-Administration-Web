using Newtonsoft.Json;
using System.ComponentModel;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Survey
{
    public class SurveyReportAllData
    {
        [DisplayName("DOMAIN")]
        [JsonProperty("Domain")]
        public string? Domain { get; set; }

        [DisplayName("SURVEY ID")]
        [JsonProperty("Survey_ID")]
        public int? SurveyId { get; set; }

        [DisplayName("SURVEY TITLE")]
        [JsonProperty("Survey_Title")]
        public string? SurveyTitle { get; set; }

        [DisplayName("QUESTION ID")]
        [JsonProperty("Question_ID")]
        public int? QuestionId { get; set; }

        [DisplayName("QUESTION POSITION")]
        [JsonProperty("Question_Position")]
        public int? QuestionPosition { get; set; }

        [DisplayName("QUESTION TITLE")]
        [JsonProperty("Question_Title")]
        public string? QuestionTitle { get; set; }

        [DisplayName("QUESTION TITLE")]
        [JsonProperty("Question_Text")]
        public string? QuestionText { get; set; }

        [DisplayName("USER ID")]
        [JsonProperty("User_ID")]
        public string? UserId { get; set; }

        [DisplayName("USER NAME")]
        [JsonProperty("User_Name")]
        public string? UserName { get; set; }

        [DisplayName("MACHINE ID")]
        [JsonProperty("Machine_ID")]
        public string? MachineId { get; set; }

        [DisplayName("MACHINE NAME")]
        [JsonProperty("Machine_Name")]
        public string? MachineName { get; set; }

        [DisplayName("EFF FROM")]
        [JsonProperty("Eff_From")]
        public DateTime? EffFrom { get; set; }

        [DisplayName("EFF TO")]
        [JsonProperty("Eff_To")]
        public DateTime? EffTo { get; set; }

        [DisplayName("TIMESLOT FROM")]
        [JsonProperty("Timeslot")]
        public string? Timeslot { get; set; }

        [DisplayName("TIMESLOT TO")]
        public string? TimeslotTo { get; set; }

        [DisplayName("IS SCORED")]
        [JsonProperty("Is_Scored")]
        public int? IsScored { get; set; }

        [DisplayName("QUESTION TYPE")]
        [JsonProperty("Question_Type")]
        public int? QuestionType { get; set; }

        [DisplayName("RESPONSE ID")]
        [JsonProperty("Response_ID")]
        public int? ResponseId { get; set; }

        [DisplayName("RESPONSE")]
        [JsonProperty("Response")]
        public string? Response { get; set; }

        [DisplayName("RESPONSE WEIGHTING")]
        [JsonProperty("Response_Weighting")]
        public int? ResponseWeighting { get; set; }

        [DisplayName("RESPONSE DATE")]
        [JsonProperty("Response_DT")]
        public DateTime? ResponseDt { get; set; }

        [DisplayName("MARK")]
        [JsonProperty("Mark")]
        public string? Mark { get; set; }

        [DisplayName("USE MACHINE ID")]
        [JsonProperty("UseMachineID")]
        public int? UseMachineId { get; set; }

        [DisplayName("OPT IN")]
        [JsonProperty("Opt_In")]
        public int? OptIn { get; set; }

        [DisplayName("IS COMPLETE")]
        [JsonProperty("Is_Complete")]
        public int? IsComplete { get; set; }

        [DisplayName("OPT OUT")]
        [JsonProperty("Opt_Out")]
        public int? OptOut { get; set; }

        [DisplayName("DURATION SECONDS")]
        [JsonProperty("Duration_Seconds")]
        public int? DurationSeconds { get; set; }

        [DisplayName("LAST UPDATE DATE USER")]
        [JsonProperty("Last_Update_DT_User")]
        public DateTime? LastUpdateDtUser { get; set; }

        [DisplayName("LAST UPDATE DATE MACHINE")]
        [JsonProperty("Last_Update_DT_Machine")]
        public DateTime? LastUpdateDtMachine { get; set; }
    }
}
