using Spectre.Console;

AnsiConsole.MarkupLine("[blue]DBGEN Database Utility [/]");
AnsiConsole.MarkupLine("[blue]-----------------------[/]");
AnsiConsole.MarkupLine("[red]IMPORTANT: Make you have EF Core installed: `dotnet tool install --global dotnet-ef`[/]");
AnsiConsole.MarkupLine("\n");
var connectionString = AnsiConsole.Ask<string>("Enter connection string:");

var tableService = new TableService();
var tables = await tableService.GetTablesAsync(connectionString);
AnsiConsole.MarkupLine("[green]✔ Connected to database[/]");

var selectedTables = AnsiConsole.Prompt(
    new MultiSelectionPrompt<string>()
        .Title("Select tables")
        .NotRequired()
        .PageSize(10)
        .AddChoices(tables)
);

if (!selectedTables.Any())
{
    AnsiConsole.MarkupLine("[red]No tables selected[/]");
    return;
}

var scaffoldService = new ScaffoldService();
AnsiConsole.MarkupLine("[green]Generating entities...[/]");

try
{
    scaffoldService.Run(connectionString, selectedTables);
}
catch (Exception ex)
{
    AnsiConsole.MarkupLine($"[red]Error:[/] {ex.Message}");
}

AnsiConsole.MarkupLine("[green]Done. [/]");
AnsiConsole.MarkupLine("[blue]The C# Entities were created under ./Entities. [/]");