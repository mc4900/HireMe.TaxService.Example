using System.Text.Json.Serialization;

namespace HireMe.Infrastructure.ApiClients.TaxJar.Entities
{
    public class Address
    {
        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;

        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("street")]
        public string Street { get; set; } = string.Empty;
    }
}
