namespace QuotationService.DTOs
{
    public class QuoteDTO
    {
        public int CityId { get; set; }
        public int SquareMeters { get; set; }
        public List<ServiceDTO> services { get; set; }
    }
}
