using ASP_NET_Kurganskiy.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_Kurganskiy.ViewModels
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public string Name { get  ; set ; }
        public int Id { get  ; set ; }
        public int Order { get ; set ; }
    }
}
