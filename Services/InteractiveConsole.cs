
using Spectre.Console;
using IonCLI.Domain;

namespace IonCLI.Services;

public interface IInteractiveConsole
{
    ProjectConfig AskQuestions(string projectName, bool useDefaults = false, string? netVersion = null, DatabaseType? dbType = null, bool? useDocker = null);
}

public class InteractiveConsole : IInteractiveConsole
{
    public ProjectConfig AskQuestions(string projectName, bool useDefaults = false, string? netVersion = null, DatabaseType? dbType = null, bool? useDocker = null)
    {
        AnsiConsole.Write(
            new FigletText("IonCLI")
                .LeftJustified()
                .Color(Color.Cyan1));

        var config = new ProjectConfig 
        { 
            Name = projectName,
            OutputPath = Path.Combine(Directory.GetCurrentDirectory(), projectName),
            NetVersion = "net8.0" // Default/Placeholder
        };

        if (useDefaults)
        {
            config.NetVersion = "net8.0";
            config.Database = DatabaseType.PostgreSQL;
            config.UseAuth = false; 
            config.UseDocker = true;
            AnsiConsole.MarkupLine("[grey]Using default configuration: .NET 8.0, PostgreSQL, Docker[/]");
            return config;
        }

        // 1. .NET Version
        if (netVersion != null)
        {
             config.NetVersion = netVersion;
        }
        else
        {
            var selectedNet = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select [green].NET version[/]:")
                    .AddChoices("8.0 (LTS)", "9.0", "10.0 (preview)"));
            
            config.NetVersion = selectedNet switch
            {
                "8.0 (LTS)" => "net8.0",
                "9.0" => "net9.0",
                "10.0 (preview)" => "net10.0",
                _ => "net8.0"
            };
        }

        // 2. Database
        if (dbType.HasValue)
        {
            config.Database = dbType.Value;
        }
        else
        {
            config.Database = AnsiConsole.Prompt(
                new SelectionPrompt<DatabaseType>()
                    .Title("Select database:")
                    .PageSize(4)
                    .AddChoices(DatabaseType.SQLServer, DatabaseType.PostgreSQL, DatabaseType.SQLite, DatabaseType.None));
        }

        // 3. Docker Support
        if (useDocker.HasValue)
        {
             config.UseDocker = useDocker.Value;
        }
        else
        {
             config.UseDocker = AnsiConsole.Confirm("Include Docker support?", defaultValue: false);
        }
        
        // Default Auth to false since we aren't asking (or true? lets go with false to be minimal as requested)
        config.UseAuth = false; 

        return config;
    }
}
