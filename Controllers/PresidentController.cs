using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SRMS_APIs.DTOs;



[ApiController]
[Route("api/president")]
public class PresidentController : ControllerBase
{
    private readonly DbAccess _db;


    public PresidentController(DbAccess db)
    {
        _db = db;
    }


    [HttpGet("society/{societyId}/pending-events")]
    public async Task<IActionResult> GetPendingEvents(int societyId)
    {
        string sql = @"
        SELECT * FROM Society_Events WHERE Societies_Id = @SocietyId AND Status = 'Pending' ORDER BY Event_Date ASC";

        var result = await _db.SelectAsync(
            sql,
            new SqlParameter("@SocietyId", societyId)
        );

        if (!result.Any())
        {
            return NotFound("Society not found");
        }

        var events = result.Select(row => new PendingEventDto
        {
            Society_Events_Id = (int)row["Society_Events_Id"],
            Event_Date = (DateTime)row["Event_Date"],
            Event_Name = row["Event_Name"].ToString()!,
            Status = row["Status"].ToString()!
        }).ToList();

        return Ok(events);
    }

    [HttpGet("society/{societyId}/history-events")]
    public async Task<IActionResult> GetAllEvents(int societyId)
    {
        string sql = @"
        SELECT * FROM Society_Events WHERE Societies_Id = @SocietyId AND Status = 'Accepted' ORDER BY Event_Date ASC";

        var result = await _db.SelectAsync(
            sql,
            new SqlParameter("@SocietyId", societyId)
        );

        if (!result.Any())
        {
            return NotFound("Society not found");
        }

        var events = result.Select(row => new PendingEventDto
        {
            Society_Events_Id = (int)row["Society_Events_Id"],
            Event_Date = (DateTime)row["Event_Date"],
            Event_Name = row["Event_Name"].ToString()!,
            Status = row["Status"].ToString()!
        }).ToList();

        return Ok(events);
    }






}
