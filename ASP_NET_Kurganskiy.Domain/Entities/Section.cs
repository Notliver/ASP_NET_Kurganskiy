using ASP_NET_Kurganskiy.Domain.Entities.Base;
using ASP_NET_Kurganskiy.Domain.Entities.Base.Interfaces;

namespace ASP_NET_Kurganskiy.Domain.Entities
{
    public class Section : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public int? OarentId { get; set; }
    }
}
