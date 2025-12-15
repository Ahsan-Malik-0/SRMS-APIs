using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SRMS_APIs.DTOs;
using SRMS_APIs.Models;
using System.Reflection;
using static SRMS_APIs.Models.Biit_Administration;

namespace SRMS_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(DbAccess _db): Controller
    {

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                if (dto == null) {
                    return BadRequest("Invalid client request");
                }

                if (dto.Role == "president" || dto.Role == "chairperson")
                {

                    var member = await _db.SelectAsync("SELECT * FROM Members WHERE Username = @Username and Password = @Password",
                        new SqlParameter("@Username", dto.Username),
                        new SqlParameter("@Password", dto.Password));

                    if (member.Count == 0)
                    {
                        return Unauthorized(new { Message = "Invalid credentials" });
                    }

                    Members dbMember = new Members
                    {
                        Members_Id = (int)member[0]["Members_Id"],
                        Username = (string)member[0]["Username"],
                        Password = (string)member[0]["Password"],
                        Position = (string)member[0]["Position"],
                        Name = (string)member[0]["Name"],
                        Email = (string)member[0]["Email"],
                        Societies_Id = (int)member[0]["Societies_Id"],
                        //Picture = member[0]["Picture"] == null ? null : (string)member[0]["Picture"]
                        Picture = member[0]["Picture"] == DBNull.Value ? null : member[0]["Picture"].ToString()

                    };
                    return Ok(new
                    {
                        success = true,
                        message = "Login successful",
                        dbMember

                    });

                }
                else
                {
                    var admin = await _db.SelectAsync("SELECT * FROM Biit_Administration WHERE Username = @Username and Password = @Password",
                        new SqlParameter("@Username", dto.Username),
                        new SqlParameter("@Password", dto.Password));

                    if (admin.Count == 0)
                    {
                        return Unauthorized(new { Message = "Invalid credentials" });
                    }

                    BiitAdministration biitAdministration = new BiitAdministration
                    {
                        Administration_Id = (int)admin[0]["Administration_Id"],
                        Username = (string)admin[0]["Username"],
                        Password = (string)admin[0]["Password"],
                        Role = (string)admin[0]["Role"],
                        Name = (string)admin[0]["Name"],
                        Email = (string)admin[0]["Email"],
                        //Picture = admin[0]["Picture"] == null ? null : (string)admin[0]["Picture"]
                        Picture = admin[0]["Picture"] == DBNull.Value ? null : admin[0]["Picture"].ToString()
                    };
                    return Ok(new
                    {
                        success = true,
                        message = "Login successful",
                        biitAdministration
                    });
                }



            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = $"Login failed: {ex.Message}"
                });
            }

            return Ok();
        }

    }
}
