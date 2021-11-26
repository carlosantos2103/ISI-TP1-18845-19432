using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMSAC_WEBAPI.Model;

namespace EMSAC_WEBAPI.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : Controller
    {
        static Orders o;

        public OrdersController()
        {
            if (o == null) o = new Orders();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("getteamorders/{id}")]
        //orders/getteamorders/1
        public IEnumerable<Order> GetTeamOrders(int id)
        {
            return o.GetTeamOrders(id);
        }

        [HttpGet]
        [Route("getproductlist")]
        //Orders/getproductlist
        public IEnumerable<Product> GetProductList()
        {
            return o.GetProductList();
        }

        [HttpPost]
        [Route("createneworder")]
        //Orders/getproductlist
        public bool CreateNewOrder(Order or)
        {
            return o.CreateNewOrder(or);
        }


    }
}
