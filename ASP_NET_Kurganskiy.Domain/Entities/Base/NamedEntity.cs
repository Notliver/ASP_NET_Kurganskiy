using ASP_NET_Kurganskiy.Domain.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations;


namespace ASP_NET_Kurganskiy.Domain.Entities.Base
{
    public abstract class NamedEntity : BaseEntity, INamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
