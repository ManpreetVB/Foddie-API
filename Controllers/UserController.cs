using FoddieDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace FoddieDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
            private readonly IConfiguration _configuration;
            public UserController(IConfiguration configuration)
            {
                _configuration = configuration;
            }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(Login users)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.Login(users, connection);

            if (response.StatusCode == 200)
                return Ok(new { Users = users, Response = response });
            else
                return Ok(new { Response = response });
        }


        [HttpPost]
        [Route("Registration")]
        public ActionResult Registration(Users users)
        {
            BAL bal = new BAL();

            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.Registration(users, connection);
            if (response.StatusCode == 200)
                return Ok(new { Users = users, Response = response });
            else
                return Ok(new { Response = response });

        }

        [HttpGet]
        [Route("ViewUser")]
        public ActionResult UserProfile(string email)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.UserProfile(email, connection);
            if (response != null)
                return Ok(new { Response = response });
            else
                return NoContent();
        }


        [HttpPut]
        [Route("UpdateUserProfile")]
        public ActionResult UpdateUserProfile(Users users)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.UpdateUserProfile(users, connection);

            if (response.StatusCode == 200)
                return Ok(new { Users = users, Response = response });
            else
                return Ok(new { Response = response });

        }


        [HttpDelete]
        [Route("DeleteUser")]
        public ActionResult DeleteUser(int userId)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.DeleteUser(userId, connection);

            if (response.StatusCode == 200)
                return Ok(new { Users = userId, Response = response });
            else
                return Ok(new { Response = response });
        }


    }
}
