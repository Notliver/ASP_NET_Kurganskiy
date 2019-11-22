using ASP_NET_Kurganskiy.Domain.Entities.Base.Interfaces;

namespace ASP_NET_Kurganskiy.Domain.Entities.Base
{
    public abstract class NamedEntity : BaseEntity, INamedEntity
    {
        public string Name { get; set; }
    }
}
