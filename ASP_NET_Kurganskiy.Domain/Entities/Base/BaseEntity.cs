using ASP_NET_Kurganskiy.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP_NET_Kurganskiy.Domain.Entities.Base
{
    /// <summary>
    /// Сущность
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
