using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2exmpl.Entities;

namespace test2exmpl.Models.Requests
{
    public class AddOrderRequest
    {
        public DateTime DateAccepted { get; set; }
        public string Notes { get; set; }
        public List<ConfectioneryRequest> Confectionery { get; set; }
    }
}
