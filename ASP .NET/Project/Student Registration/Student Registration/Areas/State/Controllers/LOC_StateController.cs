using Microsoft.AspNetCore.Mvc;

using Student_Registration.Areas.State.Models;
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
            return View();
        }
    }
}
