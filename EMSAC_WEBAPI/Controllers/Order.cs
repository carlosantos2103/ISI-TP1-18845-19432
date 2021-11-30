/*
 * <copyright file="Order.cs" Company = "IPCA - Instituto Politecnico do Cavado e do Ave">
 *      Copyright IPCA-EST. All rights reserved.
 * </copyright>
 * <version>0.1</version>
 *  <user> Joao Ricardo / Carlos Santos </users>
 * <number> 18845 / 19432 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19432@alunos.ipca.pt<email>
 */

using EMSAC_WEBAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EMSAC_WEBAPI.Controllers
{
    [ApiController]
    [Route("orders")]
    [Authorize]
    public class OrdersController : Controller
    {
        static Orders o;

        public OrdersController()
        {
            if (o == null) o = new Orders();
        }

        [HttpGet]
        [AllowAnonymous] // Permite ser chamado sem autenticação
        [Route("get_team_orders/{id}")]
        //orders/get_team_orders/1
        public IEnumerable<Order> GetTeamOrders(int id)
        {
            return o.GetTeamOrders(id);
        }

        [HttpGet]
        [AllowAnonymous] // Permite ser chamado sem autenticação
        [Route("get_product_list")]
        //orders/get_product_list
        public IEnumerable<Product> GetProductList()
        {
            return o.GetProductList();
        }

        [HttpGet]
        [AllowAnonymous] // Permite ser chamado sem autenticação
        [Route("get_most_selled_products")]
        //orders/get_most_selled_products
        public IEnumerable<ProductSelled> GetProductsMostSelled()
        {
            return o.GetProductsMostSelled();
        }

        [HttpGet]
        [AllowAnonymous] // Permite ser chamado sem autenticação
        [Route("get_most_expensive_teams")]
        //orders/get_most_expensive_teams
        public IEnumerable<TeamCost> GetMostExpensiveTeams()
        {
            return o.GetMostExpensiveTeams();
        }

        [HttpGet]
        [AllowAnonymous] // Permite ser chamado sem autenticação
        [Route("get_average_infected")]
        //orders/get_average_infected
        public double GetAverageInfected()
        {
            return o.GetAverageInfected();
        }

        [HttpPost]
        [Route("create_new_order")]
        //orders/create_new_order
        public bool CreateNewOrder(Order or)
        {
            return o.CreateNewOrder(or);
        }

        [HttpPost]
        [Route("create_new_product")]
        //orders/create_new_product
        public bool CreateNewProduct(Product pro)
        {
            return o.CreateNewProduct(pro);
        }

        [HttpPost]
        [Route("deliver_order")]
        //orders/deliver_order
        public bool DeliverOrder(Delivery del)
        {
            return o.DeliverOrder(del);
        }

        [HttpDelete]
        [Route("delete_product/{id}")]
        //orders/delete_product/1
        public bool DeleteProduct(int id)
        {
            return o.DeleteProduct(id);
        }

        [HttpPut]
        [Route("edit_product")]
        //orders/edit_product
        public bool EditProduct(Product pr)
        {
            return o.EditProduct(pr);
        }

    }
}
