using FoddieDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace FoddieDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        [Route("AddToCart")]
        public ActionResult AddToCart(Cart cart)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.AddToCart(cart, connection);

            if (response.StatusCode == 200)
                return Ok(new { Cart = cart, Response = response });
            else
                return Ok(new { Response = response });

        }



        [HttpPost]
        [Route("RemoveToCart")]
        public ActionResult RemoveToCart(int cartId,string email)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.RemoveToCart(cartId,email, connection);
            if (response.StatusCode == 200)
                return Ok(new { Cart = cartId,email, Response = response });
            else
                return Ok(new { Response = response });


        }



        [HttpPost]
        [Route("PlaceOrder")]
        public ActionResult PlaceOrder(OrderRequest orderRequest)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.PlaceOrder(orderRequest, connection);

            if (response.StatusCode == 200)
                return Ok(new { OrderRequest = orderRequest, Response = response });
            else
                return Ok(new { Response = response });
        }


        [HttpGet]
        [Route("OrderList")]
        public ActionResult OrderList(string email,string type)
        
            {
                BAL bal = new BAL();
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
                Response response = bal.OrderList(email,type, connection);
                if (response.listOrders!= null && response.listOrders.Count > 0)
                    return Ok(new { Response = response });
                else
                    return NoContent();
            }
        }
}
