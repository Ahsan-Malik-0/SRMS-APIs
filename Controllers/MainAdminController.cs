//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;


//namespace SRMS_APIs.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MainAdminController(DbAccess dBContext) : ControllerBase
//    {
//        [HttpGet("check-db")]
//        public IActionResult CheckDatabase()
//        {
//            try
//            {
//                var admin = dBContext.Biit_Administration.ToList();
//                return Ok($"Database connected successfully! Found {admin.Count} admin.");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"Database connection failed: {ex.Message}");
//            }
//        }


//    }
//}
