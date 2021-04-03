using System.Text.Json.Serialization;

namespace HireMe.Infrastructure.ApiClients.TaxJar.Entities
{
    public class NexusAdress : Address
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
