using System.Text.Json.Serialization;

namespace HireMe.Infrastructure.ApiClients.TaxJar.Entities
{
    public class LineItemTax
    {
        [JsonPropertyName("id")]
        string Id { get; set; }

        [JsonPropertyName("taxable_amount")]
        decimal TaxableAmount { get; set; }

        [JsonPropertyName("tax_collectable")]
        decimal TaxCollectable { get; set; }

        [JsonPropertyName("combined_tax_rate")]
        decimal CombinedTaxRate { get; set; }

        [JsonPropertyName("state_taxable_amount")]
        decimal StateTaxableAmount { get; set; }

        [JsonPropertyName("state_sales_tax_rate")]
        decimal StateSalesTaxRate { get; set; }

        [JsonPropertyName("state_amount")]
        decimal StateAmount { get; set; }

        [JsonPropertyName("county_taxable_amount")]
        decimal CountyTaxableAmount { get; set; }

        [JsonPropertyName("county_tax_rate")]
        decimal CountyTaxRate { get; set; }

        [JsonPropertyName("county_amount")]
        decimal CountyAmount { get; set; }

        [JsonPropertyName("city_taxable_amount")]
        decimal CityTaxableAmount { get; set; }

        [JsonPropertyName("city_tax_rate")]
        decimal CityTaxRate { get; set; }

        [JsonPropertyName("city_amount")]
        decimal CityAmount { get; set; }

        [JsonPropertyName("special_district_taxable_amount")]
        decimal SpecialDistrictTaxableAmount { get; set; }

        [JsonPropertyName("special_tax_rate")]
        decimal SpecialTaxRate { get; set; }

        [JsonPropertyName("special_district_amount")]
        decimal SpecialDistrictAmount { get; set; }

    }
}
