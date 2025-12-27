
using System.CommandLine;
using IonCLI.Domain;
using IonCLI.Services;
using Spectre.Console;

namespace IonCLI.Commands;

public class NewCommand : Command
{
    private readonly IInteractiveConsole _console;
    private readonly ITemplateGenerator _generator;

    public NewCommand(IInteractiveConsole console, ITemplateGenerator generator) 
        : base("new", "Scaffold a new Clean Architecture project")
    {
        _console = console;
        _generator = generator;

        var nameArg = new Argument<string>("name", "Name of the project (e.g. MyProject)");
        AddArgument(nameArg);

        var defaultsOption = new Option<bool>("--defaults", "Use default configuration");
        AddOption(defaultsOption);

        var netOption = new Option<string?>("--net", "Target .NET version (net8.0, net9.0)");
        AddOption(netOption);

        var dbOption = new Option<DatabaseType?>("--db", "Database type (PostgreSQL, MSSQL, SQLite, None)");
        AddOption(dbOption);

        var dockerOption = new Option<bool?>("--docker", "Include Docker support");
        AddOption(dockerOption);

        this.SetHandler(async (name, useDefaults, net, db, docker) =>
        {
            await HandleAsync(name, useDefaults, net, db, docker);
        }, nameArg, defaultsOption, netOption, dbOption, dockerOption);
    }

    private async Task HandleAsync(string name, bool useDefaults, string? net, DatabaseType? db, bool? docker)
    {
        // 1. Gather requirements
        var config = _console.AskQuestions(name, useDefaults, net, db, docker);

        // 2. Display summary
        AnsiConsole.MarkupLine("[bold]Configuration:[/]");
        AnsiConsole.MarkupLine($"[grey]- Name:[/] {config.Name}");
        AnsiConsole.MarkupLine($"[grey]- Database:[/] {config.Database}");
        AnsiConsole.MarkupLine($"[grey]- Auth:[/] {config.UseAuth}");
        AnsiConsole.MarkupLine($"[grey]- Docker:[/] {config.UseDocker}");

        // 3. Generate
        await AnsiConsole.Status()
            .StartAsync("Generating project...", async ctx =>
            {
                ctx.Status("Creating Template...");
                await _generator.GenerateAsync(config);
                ctx.Status("Done!");
            });

        AnsiConsole.MarkupLine("[green bold]Project created successfully![/]");
        AnsiConsole.MarkupLine($"cd {config.Name}");
    }
}
