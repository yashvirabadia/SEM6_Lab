using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;


namespace FirstAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IConfiguration configuration;
        public DepartmentController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        [HttpGet]
        public IActionResult GetAllDepartment()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("PR_DEPT_Department_Selectall", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                    }
                }
            }

            string jsonData = JsonConvert.SerializeObject(dt);

            return Ok(jsonData);

        }
    }
}
