//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//using SRMS_APIs.DTOs;
//using SRMS_APIs.Models;
//using System.Data;

//namespace SRMS_APIs.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PresidentController(DB dbContext) : ControllerBase
//    {
//        [HttpGet("{id}")]
//        public IActionResult MyProfile(int id)
//        {
           
//            return Ok();
//        }



//        [HttpPut("editMyProfile{username}/{password}/{role}")]
//        public IActionResult editMyProfile(int id, Members President)
//        {
//            return Ok();
//        }

 
//        [HttpPost("CreateEvent")]
//        public async Task<IActionResult> CreateEvent([FromBody] SocietyEventsDTO EventDetails)
//        {
//           return Ok();
//        }


//    }
//}
