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

        [HttpGet("{username}/{password}/{role}")]
        public IActionResult Get(string username, string password, string role)
        {
            try
            {

                if (role == "president" || role == "cp")
                {
                    var user = dbContext.Members
                        .Select(a => a.Username == username && a.Password == password && a.Position == role);


                    if (user == null)
                    {
                        return BadRequest($"Invalid credentials for {role} role.");
                    }

                    else
                    {

                        Members member = new Members
                        {
                            Username = username,
                            Password = password,
                            Position = role,
                            Email = "",
                            Name = "",
                        };
                        return Ok(new { user });
                    }


                }
                else
                {

                    var user = dbContext.Biit_Administration
                        .Select(a => a.Username == username && a.Password == password && a.Role == role);


                    if (user == null)
                    {
                        return BadRequest($"Invalid credentials for {role} role.");
                    }

                    else
                    {

                        BiitAdministration member = new BiitAdministration
                        {
                            Username = username,
                            Password = password,
                            Role = role,
                            Email = "",
                            Name = "",
                        };
                        return Ok(new { user });
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
