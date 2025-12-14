using Microsoft.AspNetCore.Mvc;
using SRMS_APIs.Database;
using SRMS_APIs.DTOs;
using SRMS_APIs.Models;
using System.Reflection;
using static SRMS_APIs.Models.Biit_Administration;

namespace SRMS_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(DB dbContext) : Controller
    {

        [HttpGet("Login")]
        public IActionResult Login(LoginDTO login)
        {
            try
            {

                if (login.Role == "president" || login.Role == "cp")
                {
                    var user = dbContext.Members
                        .Select(a => a.Username == login.Username && a.Password == login.Password && a.Position == login.Role);


                    if (user == null)
                    {
                        return BadRequest($"Invalid credentials for {login.Role} role.");
                    }

                    else
                    {

                        Members member = new Members
                        {
                            Username = login.Username,
                            Password = login.Password,
                            Position = login.Role,
                            Email = "",
                            Name = "",
                        };
                        return Ok(new { member });
                    }


                }
                else
                {

                    var user = dbContext.Biit_Administration
                        .Select(a => a.Username == login.Username && a.Password == login.Password && a.Role == login.Role);


                    if (user == null)
                    {
                        return BadRequest($"Invalid credentials for {login.Role} role.");
                    }

                    else
                    {

                        BiitAdministration member = new BiitAdministration
                        {
                            Username = login.Username,
                            Password = login.Password,
                            Role = login.Role,
                            Email = "",
                            Name = "",
                        };
                        return Ok(new { member });
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Login failed: {ex.Message}");
            }
        }

    }
}
