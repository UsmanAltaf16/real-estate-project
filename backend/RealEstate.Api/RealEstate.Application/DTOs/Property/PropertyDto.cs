using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.DTOs.Property
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Address { get; set; } = default!;
        public decimal Price { get; set; }
        public string ListingType { get; set; } = "";
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int CarSpots { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string> ImageUrls { get; set; } = new();
    }
}
