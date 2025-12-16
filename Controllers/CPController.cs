using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SRMS_APIs.DTOs;

namespace SRMS_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPController(DbAccess _db) : ControllerBase
    {
        [HttpPut("acceptEvent/{id}")]
        public async Task<IActionResult> AcceptEvent(int id)
        {

            var events = await _db.SelectAsync("SELECT * FROM Society_Events WHERE Society_Events_Id = @Id",
            new SqlParameter("@Id", id));


            if (events.Count == 0)
                return NotFound();


            var rowsAffected = await _db.ExecuteAsync(
                "UPDATE Society_Events SET Status = 'Accepted' WHERE Society_Events_Id = @Id",
                new SqlParameter("@Id", id)
            );

            return Ok(new {Message = "Event Accepted"});

        }

        [HttpPut("rejectEvent/{id}")]
        public async Task<IActionResult> RejectEvent(int id)
        {

            var events = await _db.SelectAsync("SELECT * FROM Society_Events WHERE Society_Events_Id = @Id",
            new SqlParameter("@Id", id));


            if (events.Count == 0)
                return NotFound();


            var rowsAffected = await _db.ExecuteAsync(
                "UPDATE Society_Events SET Status = 'Rejected' WHERE Society_Events_Id = @Id",
                new SqlParameter("@Id", id)
            );

            return Ok(new { Message = "Event Rejected" });

        }
    }
}
