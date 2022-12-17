using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Domain
{
    public class Surfing: Activity
    {
        public int surfingTime;
        public string beachName;

        public Surfing(string Id, string Name, string Desc, int Price) : base(Id, Name, Desc, Price)
        {

        }
    }
}
