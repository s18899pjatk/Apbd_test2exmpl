using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2exmpl.Entities
{
    public class Confectionery
    {
        public int IdConfectionery { get; set; }
        public string Name { get; set; }
        public float PricePerItem { get; set; }
        public string Type { get; set; }
        public ICollection<ConfectioneryOrder> ConfectioneryOrders { get; set; }
    }
}
