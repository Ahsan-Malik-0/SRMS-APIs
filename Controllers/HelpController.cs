using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly DbAccess _db;

    public StudentController(DbAccess db)
    {
        _db = db;
    }

    // GET: api/students
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _db.SelectAsync("SELECT * FROM Student");
        return Ok(students);
    }

    // GET: api/students/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var students = await _db.SelectAsync("SELECT * FROM Student WHERE Id = @Id",
            new SqlParameter("@Id", id));

        if (students.Count == 0)
            return NotFound();

        return Ok(students[0]);
    }

    // POST: api/students
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Student student)
    {
        var rowsAffected = await _db.ExecuteAsync(
            "INSERT INTO Student (Name, Age, Email) VALUES (@Name, @Age, @Email)",
            new SqlParameter("@Name", student.Name),
            new SqlParameter("@Age", student.Age),
            new SqlParameter("@Email", student.Email)
        );

        return Ok(new { message = $"{rowsAffected} student inserted" });
    }

    // PUT: api/students/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Student student)
    {
        var rowsAffected = await _db.ExecuteAsync(
            "UPDATE Student SET Name = @Name, Age = @Age, Email = @Email WHERE Id = @Id",
            new SqlParameter("@Name", student.Name),
            new SqlParameter("@Age", student.Age),
            new SqlParameter("@Email", student.Email),
            new SqlParameter("@Id", id)
        );

        if (rowsAffected == 0)
            return NotFound();

        return Ok(new { message = $"{rowsAffected} student updated" });
    }

    // DELETE: api/students/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var rowsAffected = await _db.ExecuteAsync(
            "DELETE FROM Student WHERE Id = @Id",
            new SqlParameter("@Id", id)
        );

        if (rowsAffected == 0)
            return NotFound();

        return Ok(new { message = $"{rowsAffected} student deleted" });
    }
}
