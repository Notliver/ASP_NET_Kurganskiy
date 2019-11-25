using ASP_NET_Kurganskiy.Domain.Entities.Base;
using ASP_NET_Kurganskiy.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP_NET_Kurganskiy.Domain.Entities
{
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get ; set ; }

        public int SectionId { get; set; }
        
        public int? BrandId { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }


    }

    public class ProductFilter
    {
        public int? SectionId { get; set; }

        public int? BrandId { get; set; }
    }
}
