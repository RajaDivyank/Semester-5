using Microsoft.AspNetCore.Mvc;

namespace Areas_And_Validation.Areas.Country.Controllers
{
    public class LOC_CountryController : Controller
    {
        [Area("Country")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
