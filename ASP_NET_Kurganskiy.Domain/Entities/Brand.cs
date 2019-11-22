using ASP_NET_Kurganskiy.Domain.Entities.Base;
using ASP_NET_Kurganskiy.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP_NET_Kurganskiy.Domain.Entities
{
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
