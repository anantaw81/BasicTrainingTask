using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Domain
{
    public class Activity: Product
    {
        public Activity(string Id, string Name, string Desc, int Price)
        {
            this.Id = $"Activity-{Id}";
            this.Name = Name;
            this.Description = Desc;
            this.Price = Price;
        }
    }
}
