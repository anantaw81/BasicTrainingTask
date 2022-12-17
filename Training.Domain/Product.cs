using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Domain
{
    public abstract class Product:RootId
    {
        public string Name;
        public string Description;
        public long Price;
        public bool IsActive;
        public string ProductType;
    }
}
