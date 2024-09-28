using FoddieDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace FoddieDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("UserList")]
        public ActionResult UserList()
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.UserList(connection);

            if (response.listUsers.Count > 0)
                return Ok(new { Response = response });
            else
                return NoContent();
        }



        [HttpPost]
        [Route("AddUpdateProduct")]
        public ActionResult AddUpdateProduct(Products products)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.AddUpdateProduct(products, connection);

            if (response.StatusCode == 200)
                return Ok(new { Products = products, Response = response });
            else
                return Ok(new { Response = response });
        }



        [HttpPost]
        [Route("PaymentProcess")]
        public ActionResult PaymentProcess(Payment payment)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.PaymentProcess(payment, connection);

            if (response.StatusCode == 200)
                return Ok(new { Payment = payment, Response = response });
            else
                return Ok(new { Response = response });
        }



        [HttpGet]
        [Route("CartList")]
        public ActionResult CartList(string email)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.CartList(email, connection);
            if (response.listCart != null && response.listCart.Count > 0)
                return Ok(new { Response = response });
            else
                return NoContent();
        }



        [HttpPost]
        [Route("UpdateOrderStatus")]
        public ActionResult UpdateOrderStatus(Orders order)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.UpdateOrderStatus(order, connection);

            if (response.StatusCode == 200)
                return Ok(new { Orders = order, Response = response });
            else
                return Ok(new { Response = response });
        }



        [HttpGet]
        [Route("ProductList")]
        public ActionResult ProductList()
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.ProductList(connection);

            if (response.listProducts.Count > 0)
                return Ok(new { Response = response });
            else
                return NoContent();

        }


        

    }
}
