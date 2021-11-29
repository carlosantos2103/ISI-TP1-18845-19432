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
        [Route("get_team_orders/{id}")]
        //orders/getteamorders/1
        public IEnumerable<Order> GetTeamOrders(int id)
        {
            return o.GetTeamOrders(id);
        }

        [HttpGet]
        [Route("get_product_list")]
        //Orders/getproductlist
        public IEnumerable<Product> GetProductList()
        {
            return o.GetProductList();
        }

        [HttpGet]
        [Route("get_most_selled_products")]
        public IEnumerable<ProductSelled> GetProductsMostSelled()
        {
            return o.GetProductsMostSelled();
        }

        [HttpGet]
        [Route("get_most_expensive_teams")]
        public IEnumerable<TeamCost> GetMostExpensiveTeams()
        {
            return o.GetMostExpensiveTeams();
        }

        [HttpGet]
        [Route("get_average_infected")]
        public double GetAverageInfected()
        {
            return o.GetAverageInfected();
        }

        [HttpPost]
        [Route("create_new_order")]
        public bool CreateNewOrder(Order or)
        {
            return o.CreateNewOrder(or);
        }

        [HttpPost]
        [Route("create_new_product")]
        public bool CreateNewProduct(Product pro)
        {
            return o.CreateNewProduct(pro);
        }

        [HttpPost]
        [Route("deliver_order")]
        public bool DeliverOrder(Delivery del)
        {
            return o.DeliverOrder(del);
        }

        [HttpDelete]
        [Route("delete_product/{id}")]
        public bool DeleteProduct(int id)
        {
            return o.DeleteProduct(id);
        }

        [HttpPut]
        [Route("edit_product")]
        public bool EditProduct(Product pr)
        {
            return o.EditProduct(pr);
        }

    }
}
