using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Policy
{
    public class PolicyReportSummary
    {
        [JsonProperty("TargetedType")]
        public string? TargetedType { get; set; }

        [JsonProperty("Targeted")]
        public int? Targeted { get; set; }

        [JsonProperty("Completed")]
        public int? Completed { get; set; }

        [JsonProperty("Outstanding")]
        public int? Outstanding { get; set; }

        [JsonProperty("Eff_From")]
        public DateTime? EffectiveFrom { get; set; }

        [JsonProperty("Eff_To")]
        public DateTime? EffectiveTo { get; set; }
    }
}
