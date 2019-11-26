using ASP_NET_Kurganskiy.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_NET_Kurganskiy.Domain.Entities.Base
{
    /// <summary>
    /// Сущность
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ограничение уникальности значений в столбце
        public int Id { get; set; }
    }
}
