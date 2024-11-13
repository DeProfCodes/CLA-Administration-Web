using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Troubleshoot
{
    public class TroubleshootReportTargeting
    {
        [JsonProperty("Destination")]
        public string? Destination { get; set; }

        [JsonProperty("CNT")]
        public int? CNT { get; set; }
    }
}
