using APIDemo.BAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [ApiController]
    /*[Route("api/[Controller]")]*/
    [Route("api/[Controller]")]
    public class PersonController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            Person_Base person = new Person_Base();
            List<PersonModel> list = person.API_PERSON_SELECTALL();
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            if (list.Count > 0 && list != null)
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
        [HttpDelete("{PersonId}")]
        public IActionResult DeleteById(int PersonId)
        {
            Person_Base person = new Person_Base();
            bool IsSuccess = person.API_PERSON_DELETEBYID(PersonId);
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                data.Add("status", true);
                data.Add("message", "Data Deleted Successfully");
                return Ok(data);
            }
            else
            {
                data.Add("status", false);
                data.Add("message", "Some error has been occured");
                return NotFound(data);
            }
        }
        [HttpPost]
        public IActionResult Add( PersonModel personModel)
        {
            Person_Base person = new Person_Base();
            bool IsSuccess = person.API_PERSON_Insert_Record(personModel);
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                data.Add("status", true);
                data.Add("message", "Data Inserted Successfully");
                return Ok(data);
            }
            else
            {
                data.Add("status", false);
                data.Add("message", "Some error has been occured");
                return NotFound(data);
            }
        }
        [HttpPut]
        public IActionResult Edit(PersonModel personModel)
        {
            Person_Base person = new Person_Base();
            bool IsSuccess = person.API_PERSON_UpdateByPERSONID(personModel.PersonId,personModel);
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                data.Add("status", true);
                data.Add("message", "Data Updated Successfully");
                return Ok(data);
            }
            else
            {
                data.Add("status", false);
                data.Add("message", "Some error has been occured");
                return NotFound(data);
            }
        }
    }
}
