using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SRMS_APIs.DTOs;

namespace SRMS_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController(DbAccess _db) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> ViewProfile(LogedinDTO dto)
        {

            try
            {

                if (dto.Role == "President" || dto.Role == "Chairperson")
                {

                    string sql = @"SELECT * FROM Members WHERE Members_Id = @Id";

                    var result = await _db.SelectAsync(
                        sql,
                        new SqlParameter("@Id", dto.Id)
                    );

                    if (result.Count == 0)
                        return NotFound($"{dto.Role} not found");

                    var row = result[0];

                    var profile = new ProfileDTO
                    {
                        Name = row["Name"].ToString()!,
                        Email = row["Email"].ToString()!,
                        Username = row["Username"].ToString()!,
                        Password = row["Password"].ToString()!,
                        Position = row["Position"].ToString()!,
                        Picture = row["Picture"] as string,
                    };

                    return Ok(profile);
                }
                else if (dto.Role == "SA" || dto.Role == "DDF" || dto.Role == "DDA")
                {
                    string sql = @"SELECT * FROM Biit_Administration WHERE Administration_Id = @Id";

                    var result = await _db.SelectAsync(
                        sql,
                        new SqlParameter("@Id", dto.Id)
                    );

                    if (result.Count == 0)
                        return NotFound($"{dto.Role} not found");

                    var row = result[0];

                    var profile = new ProfileDTO
                    {
                        Name = row["Name"].ToString()!,
                        Email = row["Email"].ToString()!,
                        Username = row["Username"].ToString()!,
                        Password = row["Password"].ToString()!,
                        Position = row["Role"].ToString()!,
                        Picture = row["Picture"] as string,
                    };

                    return Ok(profile);
                }

                return BadRequest();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = $"Error : {ex.Message}"
                });
            }


        }
        [HttpPut]
        public async Task<IActionResult> EditProfile([FromQuery] LogedinDTO dto, [FromBody] ProfileDTO newProfile)
        {

            try
            {
                if (dto.Role == "President" || dto.Role == "Chairperson")
                {
                    string sql = @"
                UPDATE Members
                SET 
                    Name = @Name,
                    Email = @Email,
                    Username = @Username,
                    Password = @Password,
                    Picture = @Picture
                WHERE Members_Id = @Id
                ";

                    int rowsAffected = await _db.ExecuteAsync(
                        sql,
                        new SqlParameter("@Name", newProfile.Name),
                        new SqlParameter("@Email", newProfile.Email),
                        new SqlParameter("@Username", newProfile.Username),
                        new SqlParameter("@Password", newProfile.Password),
                        new SqlParameter("@Picture", (object?)newProfile.Picture ?? DBNull.Value),
                        new SqlParameter("@Id", dto.Id)
                    );

                    if (rowsAffected == 0)
                        return NotFound($"{dto.Role} not found");

                    return Ok("Profile updated successfully");
                }
                else if (dto.Role == "SA" || dto.Role == "DDF" || dto.Role == "DDA")
                {
                        string sql = @"
                    UPDATE Biit_Administration
                    SET 
                        Name = @Name,
                        Email = @Email,
                        Username = @Username,
                        Password = @Password,
                        Picture = @Picture
                    WHERE Administration_Id = @Id
                    ";

                    int rowsAffected = await _db.ExecuteAsync(
                        sql,
                        new SqlParameter("@Name", newProfile.Name),
                        new SqlParameter("@Email", newProfile.Email),
                        new SqlParameter("@Username", newProfile.Username),
                        new SqlParameter("@Password", newProfile.Password),
                        new SqlParameter("@Picture", (object?)newProfile.Picture ?? DBNull.Value),
                        new SqlParameter("@Id", dto.Id)
                    );

                    if (rowsAffected == 0)
                        return NotFound($"{dto.Role} not found");

                    return Ok("Profile updated successfully");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = $"Error : {ex.Message}"
                });
            };

        }

    }
}
