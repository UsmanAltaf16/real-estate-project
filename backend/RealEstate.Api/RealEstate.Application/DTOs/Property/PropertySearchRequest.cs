﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.DTOs.Property
{
    public class PropertySearchRequest
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public string? Suburb { get; set; }       
        public string? ListingType { get; set; }  
        public string? Q { get; set; }           

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 12;
    }
}
