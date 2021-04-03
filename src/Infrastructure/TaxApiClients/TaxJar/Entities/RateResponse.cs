using System.Text.Json.Serialization;


namespace HireMe.Infrastructure.ApiClients.TaxJar.Entities
{
    public class RateResponse
    {
        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("country_rate")]
        public decimal? ContryRate { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("state_rate")]
        public decimal StateRate { get; set; }

        [JsonPropertyName("county")]
        public string County { get; set; }

        [JsonPropertyName("County_rate")]
        public decimal CountyRate { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("city_rate")]
        public decimal CityRate { get; set; }

        [JsonPropertyName("combined_district_rate")]
        public decimal CombinedDistrictRate { get; set; }

        [JsonPropertyName("combined_rate")]
        public decimal CombinedRate { get; set; }

        [JsonPropertyName("freight_taxable")]
        public decimal FreightTaxable { get; set; }


    }
}
