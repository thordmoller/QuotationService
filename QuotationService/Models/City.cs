﻿namespace QuotationService
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Rate { get; set; }
        public List<Service> Services { get; set; }
    }

}