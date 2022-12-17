using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Domain
{
    public class SalesOrder: RootId
    {
        private string _id;
        public string Id
        {
            get
            {
                return _id;
            } set
            {
                _id = $"SalesOrder-{value}";

            }}
        public List<Product>? CartOrder { get; set; }
        public string? Status { get; set; }
        public int TotalPrice { get; set; }
    }
}
