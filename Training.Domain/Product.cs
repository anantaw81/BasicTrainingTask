using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Domain
{
    public abstract class Product:RootId
    {
        public string? Name { set; get; }
        public string? Description { set; get; }
        public int Price { set; get; }
        public bool IsActive { set; get; }
        public string? ProductType { set; get; }
        public int Quantity { set; get; }
       
    }
}
