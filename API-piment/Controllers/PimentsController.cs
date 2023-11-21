using Dapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace API_piment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PimentsController : ControllerBase
    {

        #region DI
        private readonly SqlConnection? _conn = null;
        private readonly string str = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Db-piments;Integrated Security=True;";

        public PimentsController()
        {
            _conn = new SqlConnection(str);
        } 
        #endregion

        // GET: api/<PimentsController>
        [HttpGet]
        public ActionResult<IEnumerable<Models.Piments>> Get()
        {
            string sql = "SELECT * FROM [Piments]";

            IEnumerable<Models.Piments>? items = _conn?.Query<Models.Piments>(sql).ToList();

            if(items is not null)
                return Ok(items);

            return NoContent();
        }

        // GET api/<PimentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Models.Piments>? Get(int id) // Anticipée/géré l'execption null
        {
            try
            {
                string sql = "SELECT * FROM Piments WHERE Id = @idP";
                Models.Piments? item = _conn?.QuerySingle<Models.Piments>(sql, new { idP = id });

                if (item is not null)
                    return Ok(item);
            }

            catch (InvalidOperationException ex)
            {
                throw ex;
            }

            return NoContent();
        }

        
    }
}
