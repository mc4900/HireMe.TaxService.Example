using System.Text.Json.Serialization;

namespace HireMe.Infrastructure.ApiClients.TaxJar.Entities
{
    public class Breakdown
    {
        [JsonPropertyName("taxable_amount")]
        public decimal TaxableAmount { get; set; }

        [JsonPropertyName("tax_collectable")]
        public decimal TaxCollectable { get; set; }

        [JsonPropertyName("combined_tax_rate")]
        public decimal CombinedTaxRate { get; set; }

        [JsonPropertyName("state_taxable_amount")]
        public decimal StateTaxableAmount { get; set; }

        [JsonPropertyName("state_tax_rate")]
        public decimal StateTaxRate { get; set; }

        [JsonPropertyName("state_tax_collectable")]
        public decimal StateTaxCollectable { get; set; }

        [JsonPropertyName("county_taxable_amount")]
        public decimal CountyTaxableAmount { get; set; }

        [JsonPropertyName("county_tax_rate")]
        public decimal CountyTaxRate { get; set; }

        [JsonPropertyName("county_tax_collectable")]
        public decimal CountyTaxCollectable { get; set; }

        [JsonPropertyName("city_taxable_amount")]
        public decimal CityTaxableAmount { get; set; }

        [JsonPropertyName("city_tax_rate")]
        public decimal CityTaxRate { get; set; }

        [JsonPropertyName("city_tax_collectable")]
        public decimal CityTaxCollectable { get; set; }

        [JsonPropertyName("special_district_taxable_amount")]
        public decimal SpecialDistrictTaxableAmount { get; set; }

        [JsonPropertyName("special_tax_rate")]
        public decimal SpecialTaxRate { get; set; }

        [JsonPropertyName("special_district_tax_collectable")]
        public decimal SpecialDistrictTaxCollectable { get; set; }

        [JsonPropertyName("line_items")]
        public LineItem LineItem { get; set; }


    }
}
