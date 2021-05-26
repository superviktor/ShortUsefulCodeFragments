using System;

namespace Api
{
    public class PriceDto
    {
        public decimal Value { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}
