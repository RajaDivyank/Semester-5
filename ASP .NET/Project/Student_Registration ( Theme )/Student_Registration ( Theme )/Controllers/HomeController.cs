using Microsoft.AspNetCore.Mvc;
using Student_Registration___Theme__.Models;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace Student_Registration___Theme__.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;*/
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       /* public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            String connectionStr = this._configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.Open();
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Dashboord_Count";
            SqlDataReader objDataReader = objCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(objDataReader);
            conn.Close();
            return View("Index", dt);
        }
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}