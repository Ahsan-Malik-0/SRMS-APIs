using Microsoft.Data.SqlClient;

public class DbAccess
{
    private readonly string _connectionString;

    public string GetConnString()
    {
        return _connectionString;
    }
    public DbAccess(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Connection string cannot be null or empty", nameof(connectionString));

        _connectionString = connectionString;
    }

    // SELECT queries
    public async Task<List<Dictionary<string, object>>> SelectAsync(string sql, params SqlParameter[] parameters)
    {
        var result = new List<Dictionary<string, object>>();

        using (var conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[reader.GetName(i)] = reader.GetValue(i);
                        }
                        result.Add(row);
                    }
                }
            }
        }

        return result;
    }

    // INSERT / UPDATE / DELETE queries
    public async Task<int> ExecuteAsync(string sql, params SqlParameter[] parameters)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                return await cmd.ExecuteNonQueryAsync();
            }
        }
    }

 

}
