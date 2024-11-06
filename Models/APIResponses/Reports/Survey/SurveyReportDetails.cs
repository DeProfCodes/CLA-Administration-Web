using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Survey
{
    public class SurveyReportDetails
    {
        [JsonProperty("User_ID")]
        public string UserId { get; set; }

        [JsonProperty("Machine_ID")]
        public string MachineId { get; set; }

        [JsonProperty("Is_Complete")]
        public int IsComplete { get; set; }

        [JsonProperty("Opt_In")]
        public int OptIn { get; set; }

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

        [JsonProperty("Opt_Out")]
        public int OptOut { get; set; }

        [JsonProperty("Duration_Seconds")]
        public int DurationSeconds { get; set; }
    }
}
