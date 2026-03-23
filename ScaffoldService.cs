using System.Diagnostics;
using System.Text;

public class ScaffoldService
{
    public void Run(string connectionString, IEnumerable<string> tables)
    {
        var tableArgs = string.Join(" ", tables.Select(t => $"--table {t}"));

        var command = $"dotnet ef dbcontext scaffold \"{connectionString}\" Microsoft.EntityFrameworkCore.SqlServer {tableArgs} --output-dir Entities --no-onconfiguring --force";

        Execute(command);
    }

    private void Execute(string command)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c {command}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };

        using var process = Process.Start(psi);

        if (process == null)
        {
            throw new Exception("Process undefined");
        }

        process.OutputDataReceived += (_, e) => Console.WriteLine(e.Data);
        process.ErrorDataReceived += (_, e) => Console.WriteLine(e.Data);

        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        process.WaitForExit();
    }
}