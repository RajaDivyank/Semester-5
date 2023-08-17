using Microsoft.AspNetCore.Mvc;

using Student_Registration.Areas.State.Models;
using System.Data;
using System.Data.SqlClient;

namespace Student_Registration.Areas.State.Controllers
{
    [Area("State")]
    public class LOC_StateController : Controller
    {
        private readonly IConfiguration _configuration;
        public LOC_StateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult StateList()
        {
            String connectionStr = this._configuration.GetConnectionString("myConnectionString");

            //Create Connection
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.Open();
            //Create Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectAll";
            SqlDataReader objDataReader = objCmd.ExecuteReader();
            //Create DataTable
            DataTable dt = new DataTable();
            dt.Load(objDataReader);
            conn.Close();
            return View("StateList", dt);
        }
    }
}
