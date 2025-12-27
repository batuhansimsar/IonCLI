
using Spectre.Console;
using IonCLI.Domain;

namespace IonCLI.Services;

public interface IInteractiveConsole
{
    ProjectConfig AskQuestions(string projectName, bool useDefaults = false, string? netVersion = null);
}

public class InteractiveConsole : IInteractiveConsole
{
    public ProjectConfig AskQuestions(string projectName, bool useDefaults = false, string? netVersion = null)
    {
        AnsiConsole.Write(
            new FigletText("IonCLI")
                .LeftJustified()
                .Color(Color.Cyan1));

        var config = new ProjectConfig 
        { 
            Name = projectName,
            OutputPath = Path.Combine(Directory.GetCurrentDirectory(), projectName),
            NetVersion = "net8.0"
        };

        if (useDefaults)
        {
            config.NetVersion = "net8.0";
            config.UseAuth = false; 
            AnsiConsole.MarkupLine("[grey]Using default configuration: .NET 8.0[/]");
            return config;
        }

        // .NET Version
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
        
        config.UseAuth = false; 

        return config;
    }
}
