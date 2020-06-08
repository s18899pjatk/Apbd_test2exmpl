using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2exmpl.Models.Requests;
using test2exmpl.Models.Responces;

namespace test2exmpl.Services
{
    public interface IOrderServiceDb
    {
        public List<GetOrdersResponse> GetOrders(GetOrderRequest name);
        public AddOrderResponse AddOrder(int id, AddOrderRequest request);
    }
}
