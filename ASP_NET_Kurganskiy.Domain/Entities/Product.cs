using ASP_NET_Kurganskiy.Domain.Entities.Base;
using ASP_NET_Kurganskiy.Domain.Entities.Base.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ASP_NET_Kurganskiy.Domain.Entities
{
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public int SectionId { get; set; }

        [ForeignKey(nameof(SectionId))]
        public virtual Section Section { get; set; }

        public int? BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }  // автоматически генерируемый внешний ключ - Brand_id

        public string ImageUrl { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        //[Column(name:"TestValueColumn")]
        //public string TestValue { get; set; }

        //[NotMapped]
        //public int NotMappedProperty { get; set; }
    }
}
