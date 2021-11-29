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

        //public IActionResult Index()
        //{
        //    return View();
        //}

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
        public bool CreateNewOrder(Order or)
        {
            return o.CreateNewOrder(or);
        }

        [HttpPost]
        [Route("createnewproduct")]
        public bool CreateNewProduct(Product pro)
        {
            return o.CreateNewProduct(pro);
        }

        [HttpPost]
        [Route("deliverorder")]
        public bool DeliverOrder(Delivery del)
        {
            return o.DeliverOrder(del);
        }

        [HttpGet]
        [Route("getmostselledproducts")]
        public IEnumerable<ProductSelled> GetProductsMostSelled()
        {
            return o.GetProductsMostSelled();
        }

        [HttpGet]
        [Route("getmostexpensiveteams")]
        public IEnumerable<TeamCost> GetMostExpensiveTeams()
        {
            return o.GetMostExpensiveTeams();
        }

        [HttpGet]
        [Route("getaverageinfected")]
        public double GetAverageInfected()
        {
            return o.GetAverageInfected();
        }

    }
}
