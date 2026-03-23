using Microsoft.Data.SqlClient;

public class TableService
{
    public async Task<List<string>> GetTablesAsync(string connectionString)
    {
        var tables = new List<string>();

        using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();

        var query = @"
            SELECT TABLE_SCHEMA + '.' + TABLE_NAME
            FROM INFORMATION_SCHEMA.TABLES
            WHERE TABLE_TYPE = 'BASE TABLE'
            ORDER BY TABLE_SCHEMA, TABLE_NAME";

        using var cmd = new SqlCommand(query, conn);
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            tables.Add(reader.GetString(0));
        }

        return tables;
    }
}