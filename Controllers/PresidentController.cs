using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRMS_APIs.Database;
using SRMS_APIs.Models;

namespace SRMS_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresidentController(DB dbContext) : ControllerBase
    {
        [HttpGet]
        public IActionResult myProfile(int id)
        {
            var user = dbContext.Members.Find(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult editMyProfile(int id, Members President)
        {
            var user = dbContext.Members.Find(id);
            if (user == null)
            {
                return NoContent();
            }
            else
            {
                user.Name = President.Name;
                user.Email = President.Email;
                user.Username = President.Username;
                user.Password = President.Password;
                user.Picture = President.Picture;
                dbContext.SaveChanges();
                return Ok(user);    
            }
        }

        public IActionResult createEvent(String EventName, DateTime EventDate, SocieyEventsRequirements[] EventsRequirements)
        {


            return Ok();
        }

    }
}
