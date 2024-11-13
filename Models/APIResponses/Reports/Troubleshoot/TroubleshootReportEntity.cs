using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Troubleshoot
{
    public class TroubleshootReportEntity
    {
        [JsonProperty("NT_UserName")]
        public string? NTUserName { get; set; }

        [JsonProperty("NT_MachineName")]
        public string? NTMachineName { get; set; }
    }
}
