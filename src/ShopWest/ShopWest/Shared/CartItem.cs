using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWest.Shared
{
    public class CartItem
    {
        public string ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string PriceId { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}