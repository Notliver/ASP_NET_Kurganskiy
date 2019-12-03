using System.Collections.Generic;
using System.Linq;

namespace ASP_NET_Kurganskiy.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public int ItemsCount => Items?.Sum(item => item.Quantity) ?? 0;

    }
}
