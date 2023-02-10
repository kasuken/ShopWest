using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWest.Shared
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
        public string ImageUrl { get; set; }
        
        public string PriceId { get; set; }
        
        public string Price { get; set; }
        
        public string Type { get; set; }
    }
}
