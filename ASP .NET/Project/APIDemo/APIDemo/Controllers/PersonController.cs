using APIDemo.BAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [ApiController]
    /*[Route("api/[Controller]")]*/
    [Route("api/[Controller]/{PersonId}")]
    public class PersonController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            Person_Base person = new Person_Base();
            List<PersonModel> list = person.API_PERSON_SELECTALL();
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            if (list.Count > 0 && list!=null)
            {
                data.Add("status", true);
                data.Add("message", "Data Found");
                data.Add("data", list);
                return Ok(data);
            }
            else
            {
                data.Add("status", false);
                data.Add("message", "Data not found");
                data.Add("data", null);
                return NotFound(data);
            }
        }
        [HttpGet("{PersonId}")]
        public IActionResult GetById(int PersonId) {
            Person_Base person = new Person_Base();
            PersonModel list = person.API_PERSON_SELECTById(PersonId);
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            if (list.PersonId != 0)
            {
                data.Add("status", true);
                data.Add("message", "Data Found");
                data.Add("data", list);
                return Ok(data);
            }
            else
            {
                data.Add("status", false);
                data.Add("message", "Data not found");
                data.Add("data", null);
                return NotFound(data);
            }
        }
    }
}
