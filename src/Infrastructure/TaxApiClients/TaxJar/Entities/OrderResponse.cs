using System.Text.Json.Serialization;


namespace HireMe.Infrastructure.ApiClients.TaxJar.Entities
{
    public class OrderResponse
    {
        [JsonPropertyName("tax")]
        public TaxDetail Tax { get; set; }

        [JsonPropertyName("Breakdown")]
        public Breakdown Breakdown { get; set; }
    }
}
