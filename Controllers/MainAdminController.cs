using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMS_APIs.Database;

namespace SRMS_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainAdminController(DB dBContext) : ControllerBase
    {
        [HttpGet("check-db")]
        public IActionResult CheckDatabase()
        {
            try
            {
                var admin = dBContext.Biit_Administration.ToList();
                return Ok($"Database connected successfully! Found {admin.Count} societies.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Database connection failed: {ex.Message}");
            }
        }


    }
}
