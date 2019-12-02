using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_Kurganskiy.ViewModels
{
    public class CartViewModel
    {
        public Dictionary<ProductViewModel ,int> Items { get; set; } = new Dictionary<ProductViewModel, int>();

        public int ItemsCount => Items?.Sum(Item => Item.Value) ?? 0;
    }
}
