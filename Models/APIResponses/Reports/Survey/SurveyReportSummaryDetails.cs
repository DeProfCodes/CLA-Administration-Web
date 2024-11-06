using CLA_Administration_Web.Helpers.Reporting;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Survey
{
    public class SurveyReportSummaryDetails
    {
        [DisplayName("Domain")]
        [JsonProperty("Domain")]
        public string? Domain { get; set; }

        [DisplayName("User ID")]
        [JsonProperty("User_ID")]
        public string? UserId { get; set; }

        [DisplayName("User Name")]
        [JsonProperty("User_Name")]
        public string? UserName { get; set; }

        [DisplayName("Machine ID")]
        [JsonProperty("Machine_ID")]
        public string? MachineId { get; set; }

        [DisplayName("Machine Name")]
        [JsonProperty("Machine_Name")]
        public string? MachineName { get; set; }

        [DisplayName("Last Sync DT User")]
        [JsonProperty("Last_Update_DT_User")]
        public DateTime? LastUpdateDtUser { get; set; }

        [DisplayName("Last Sync DT Machine")]
        [JsonProperty("Last_Update_DT_Machine")]
        public DateTime? LastUpdateDtMachine { get; set; }

        [SkipProperty]
        [DisplayName("")]
        public DateTime? LastSyncDate { get; set; }

        [SkipProperty]
        [DisplayName("")]
        [JsonProperty("Is_Complete")]
        public int? IsComplete { get; set; }

        [SkipProperty]
        [DisplayName("")]
        [JsonProperty("Opt_In")]
        public int? OptIn { get; set; }

        [SkipProperty]
        [DisplayName("")]
        [JsonProperty("Opt_Out")]
        public int? OptOut { get; set; }

        [SkipProperty]
        [DisplayName("")]
        [JsonProperty("Duration_Seconds")]
        public int? DurationSeconds { get; set; }
    }
}
