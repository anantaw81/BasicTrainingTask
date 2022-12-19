using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Domain
{
    public class Cart : RootId
    {
        public Product ProductData { get; set; }
        public Cart(int id, Product _product) {
            this.Id = $"Cart-{id}" ;
            this.ProductData = _product;
        }
    }
}
