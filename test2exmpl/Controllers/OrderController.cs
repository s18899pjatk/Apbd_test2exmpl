using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test2exmpl.Models.Requests;
using test2exmpl.Services;

namespace test2exmpl.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceDb _orderServiceDb;
        public OrderController(IOrderServiceDb orderService)
        {
            _orderServiceDb = orderService;
        }

        [HttpGet]
        public IActionResult GetOrders(GetOrderRequest request)
        {
            var res = _orderServiceDb.GetOrders(request);
            if (res == null)
            {
                return BadRequest();
            }
            return Ok(res);
        }


        [HttpPost("{id}")]
        public IActionResult AddOrder(int id, AddOrderRequest request)
        {
            var res = _orderServiceDb.AddOrder(id, request);
            if (res == null)
            {
                return BadRequest("Such customer or product does not exists");
            }
            else return Ok(res);
        }
    }
}
