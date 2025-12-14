using Microsoft.AspNetCore.Mvc;

namespace SRMS_APIs.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
