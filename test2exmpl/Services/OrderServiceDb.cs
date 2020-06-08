using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2exmpl.Entities;
using test2exmpl.Models.Requests;
using test2exmpl.Models.Responces;

namespace test2exmpl.Services
{
    public class OrderServiceDb : IOrderServiceDb
    {
        public OrderDbContext _orderDbContext;

        public OrderServiceDb(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public AddOrderResponse AddOrder(int id, AddOrderRequest request)
        {
            var exists = _orderDbContext.Customers.Any(c => c.IdClient.Equals(id));
            if (!exists)
            {
                return null;
            }

            // taking random employee to perform the order
            Random rand = new Random();
            int num = rand.Next(0, _orderDbContext.Employees.Count() - 1);
            var order = new Order()
            {
                DataAccepted = request.DateAccepted,
                idClient = id,
                idEmployee = _orderDbContext.Employees.Skip(num).Take(1).First().idEmployee,
                Notes = request.Notes
            };
            _orderDbContext.Add(order);
            _orderDbContext.SaveChanges();


            // foreach in request
            var confExists = false;
            foreach (var cnf in request.Confectionery)
            {
                //checking if such product exists
                confExists = _orderDbContext.Confectioneries.Any(c => c.Name.Equals(cnf.Name));
                if (!confExists) return null;

                var confectioneryId = _orderDbContext.Confectioneries.Where(c => c.Name.Equals(cnf.Name))
                    .Select(c => c.IdConfectionery).FirstOrDefault();
                var conf_order = new ConfectioneryOrder()
                {
                    IdConfection = confectioneryId,
                    IdOrder = order.idOrder,
                    Notes = cnf.Notes,
                    Quantity = cnf.Quantity
                };
                _orderDbContext.Add(conf_order);
                _orderDbContext.SaveChanges();
            }


            return new AddOrderResponse
            {
                IdOrder = order.idOrder,
                Confectionery = request.Confectionery
            };
        }

        public List<GetOrdersResponse> GetOrders(GetOrderRequest request)
        {
            List<GetOrdersResponse> results = new List<GetOrdersResponse>();

            var exists = _orderDbContext.Customers.Any(c => c.Name.Equals(request.Name));

            if (!exists || request == null)
            {
                var orders = _orderDbContext.Orders.ToList();
                foreach (var row in orders)
                {
                    results.Add(new GetOrdersResponse
                    {
                        IdOrder = row.idOrder,
                        DateAccepted = row.DataAccepted,
                        DateFinished = row.DataFinished,
                        Notes = row.Notes
                    });
                }
                return results;
            }


            var orders1 = (from o in _orderDbContext.Orders
                           join c in _orderDbContext.Customers on
                           o.idClient equals c.IdClient
                           where c.Name == request.Name
                           select o).ToList();

            foreach (var row in orders1)
            {
                results.Add(new GetOrdersResponse
                {
                    IdOrder = row.idOrder,
                    DateAccepted = row.DataAccepted,
                    DateFinished = row.DataFinished,
                    Notes = row.Notes
                });
            }
            return results;
        }
    }
}
