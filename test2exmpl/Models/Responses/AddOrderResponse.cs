using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2exmpl.Models.Requests;

namespace test2exmpl.Models.Responces
{
    public class AddOrderResponse
    {
        public int IdOrder { get; set; }
        public List<ConfectioneryRequest> Confectionery { get; set; }
    }
}
