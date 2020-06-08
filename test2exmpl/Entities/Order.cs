using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2exmpl.Entities
{
    public class Order
    {
        public int idOrder { get; set; }
        public DateTime DataAccepted { get; set; }
        public DateTime? DataFinished { get; set; }
        public string Notes { get; set; }
        public int idClient { get; set; }
        public int idEmployee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public ICollection<ConfectioneryOrder> ConfectioneryOrders { get; set; }
    }
}
