namespace QuotationService
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Rate { get; set; }
        public List<Service> Services { get; set; }
    }

}
