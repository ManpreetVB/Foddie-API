using FoddieDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace FoddieDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("AddCategory")]
        public ActionResult AddCategory(Categories category)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.AddCategory(category, connection);

            if (response.StatusCode == 200)
                return Ok(new { Categories = category, Response = response });
            else
                return Ok(new { Response = response });


        }
    }
}
