using Microsoft.AspNetCore.Mvc;

namespace SRMS_APIs.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            try
            {
                return Ok("Login successful!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Login failed: {ex.Message}");
            }
        }

    }
}
