using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SRMS_APIs.DTOs;
using System.Collections.Generic;

namespace SRMS_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(DbAccess _db) : ControllerBase
    {

        [HttpPost("create-event")]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto dto)
        {

            using var conn = new SqlConnection(_db.GetConnString());
            await conn.OpenAsync();

            using var transaction = conn.BeginTransaction();

            try
            {

                string insertEventSql = @"
                INSERT INTO Society_Events (Event_Date, Event_Name, Societies_Id, Status) VALUES (@Event_Date, @Event_Name, @Societies_Id, 'Pending');
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int createdEventId;
                using (var cmd = new SqlCommand(insertEventSql, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@Event_Date", dto.Event_Date);
                    cmd.Parameters.AddWithValue("@Event_Name", dto.Event_Name);
                    cmd.Parameters.AddWithValue("@Societies_Id", dto.Societies_Id);

                    createdEventId = (int)await cmd.ExecuteScalarAsync();
                }

                string insertReqSql = @"
                INSERT INTO Society_Events_Requirements (Item_Type, Item_Name, Estimated_Price, Quantity, Society_Events_Id) VALUES
                (@Item_Type, @Item_Name, @Estimated_Price, @Quantity, @Society_Events_Id);";

                foreach (var req in dto.Requirements)
                {
                    using var cmd = new SqlCommand(insertReqSql, conn, transaction);
                    cmd.Parameters.AddWithValue("@Item_Type", req.Item_Type);
                    cmd.Parameters.AddWithValue("@Item_Name", req.Item_Name);
                    cmd.Parameters.AddWithValue("@Estimated_Price", req.Estimated_Price);
                    cmd.Parameters.AddWithValue("@Quantity", req.Quantity);
                    cmd.Parameters.AddWithValue("@Society_Events_Id", createdEventId);

                    await cmd.ExecuteNonQueryAsync();
                }

                transaction.Commit();

                return Ok(new
                {
                    Message = "Event created successfully",
                    Society_Events_Id = createdEventId
                });
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var rowsAffected = await _db.ExecuteAsync(
                "DELETE FROM Society_Events WHERE Society_Events_Id = @Id",
                new SqlParameter("@Id", id)
            );

            if (rowsAffected == 0)
                return NotFound();

            return Ok(new { message = $"Event deleted" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditEvent(int id, [FromBody] UpdateEventDto dto)
        {

            var events = await _db.SelectAsync("SELECT * FROM Society_Events WHERE Society_Events_Id = @Id",
            new SqlParameter("@Id", id));


            if (events.Count == 0)
                return NotFound();


            var rowsAffected = await _db.ExecuteAsync(
                "UPDATE Society_Events SET Event_Name = @Event_Name, Event_Date = @Event_Date WHERE Society_Events_Id = @Id",
                new SqlParameter("@Event_Name", dto.Event_Name),
                new SqlParameter("@Event_Date", dto.Event_Date),
                new SqlParameter("@Id", id)
            );


            var eventRequitrments = await _db.SelectAsync("SELECT * FROM Society_Events_Requirements WHERE Society_Events_Id = @Id",
            new SqlParameter("@Id", id));

            var rowsAffected1 = await _db.ExecuteAsync(
                "DELETE FROM Society_Events_Requirements WHERE Society_Events_Id = @Id",
                new SqlParameter("@Id", id)
            );

            string insertReqSql = @"
            INSERT INTO Society_Events_Requirements (Item_Type, Item_Name, Estimated_Price, Quantity, Society_Events_Id) VALUES
            (@Item_Type, @Item_Name, @Estimated_Price, @Quantity, @Society_Events_Id);";


            foreach (var req in dto.Requirements)
            {

                var rowsAffected2 = await _db.ExecuteAsync(
                    insertReqSql,

                      new SqlParameter("@Item_Type", req.Item_Type),
                      new SqlParameter("@Item_Name", req.Item_Name),
                      new SqlParameter("@Estimated_Price", req.Estimated_Price),
                      new SqlParameter("@Quantity", req.Quantity),
                      new SqlParameter("@Society_Events_Id", id)
                );
            }


            //foreach (var req in dto.Requirements)
            //{
            //    var rowsAffected2 = await _db.ExecuteAsync(
            //      "UPDATE Society_Events_Requirements SET Name = @Item_Type, @Item_Name, @Estimated_Price, @Quantity WHERE Society_Events_Requirements_Id = @Id",
            //      new SqlParameter("@Item_Type", req.Item_Type),
            //      new SqlParameter("@Item_Name", req.Item_Name),
            //      new SqlParameter("@Estimated_Price", req.Estimated_Price),
            //      new SqlParameter("@Quantity", req.Quantity),
            //      new SqlParameter("@Society_Events_Requirements_Id", req.)
            //    );


            //}

            return Ok(new { message = $"Event updated" });
        }
    }
}
