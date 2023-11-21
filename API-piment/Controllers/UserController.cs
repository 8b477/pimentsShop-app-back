using Dapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_piment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region DI
        private readonly SqlConnection? _conn = null;
        private readonly string str = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Db-piments;Integrated Security=True;";

        public UserController()
        {
            _conn = new SqlConnection(str);
        }
        #endregion


        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post ([FromBody] Models.UserRegisterDTO model)
        {

            if(model is not null)
            {
                Models.User user = new() 
                {
                  Name = model.Name,
                  Email = model.Email ,
                  Password = model.Password,
                  Role = "Register"
                };

                string sql = "INSERT INTO [User] (Name, Email, Password, Role) VALUES (@Name, @Email, @Password, @Role)";

                var paramFromModel = new { Name = user.Name, Email = user.Email, Password = user.Password, Role = user.Role };

                var rowAffected = _conn.Execute(sql, paramFromModel);

                if (rowAffected > 0)
                    return CreatedAtAction(nameof(Post),user);

            }

            return BadRequest();
        }

        // GET: api/<PimentsController>
        [HttpGet]
        public ActionResult<IEnumerable<Models.User>> Get()
        {
            string sql = "SELECT * FROM [User]";

            IEnumerable<Models.User>? items = _conn?.Query<Models.User>(sql).ToList();

            if (items is not null)
                return Ok(items);

            return NoContent();
        }
    }
}
