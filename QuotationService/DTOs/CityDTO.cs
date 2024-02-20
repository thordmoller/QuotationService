namespace QuotationService
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public List<ServiceDTO> Services { get; set; }
    }

}
