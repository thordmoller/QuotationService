﻿namespace QuotationService
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<City> Cities { get; set; }
    }


}
