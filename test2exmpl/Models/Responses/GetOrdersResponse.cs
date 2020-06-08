using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2exmpl.Models.Responces
{
    public class GetOrdersResponse
    {
        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime? DateFinished { get; set; }
        public string Notes { get; set; }
    }
}
