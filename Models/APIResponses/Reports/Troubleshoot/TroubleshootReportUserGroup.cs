using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Troubleshoot
{
    public class TroubleshootReportUserGroup
    {
        [JsonProperty("Group_ID")]
        public string? GroupID { get; set; }
    }
}
