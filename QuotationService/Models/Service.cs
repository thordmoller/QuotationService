using System.Text.Json.Serialization;

namespace QuotationService
{
    public class Service
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]
        public int CityId { get; set; }
        [JsonIgnore]
        public City City { get; set; }
    }


}
