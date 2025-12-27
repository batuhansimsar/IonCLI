
using System.Reflection;
using IonCLI.Domain;

namespace IonCLI.Services;

public interface ITemplateGenerator
{
    Task GenerateAsync(ProjectConfig config);
}

public class TemplateGenerator : ITemplateGenerator
{
    private static readonly Dictionary<string, string> _templates = new()
    {
        // Solution
        { "IonCLI.Templates.Solution.ARCHITECTURE.md.txt", "ARCHITECTURE.md" },
        { "IonCLI.Templates.Solution.gitignore.txt", ".gitignore" },
        
        // Domain
        { "IonCLI.Templates.Domain.Domain.csproj.txt", "src/{{ProjectName}}.Domain/{{ProjectName}}.Domain.csproj" },
        { "IonCLI.Templates.Domain.Common.BaseEntity.csharp", "src/{{ProjectName}}.Domain/Common/BaseEntity.cs" },

        // Application
        { "IonCLI.Templates.Application.Application.csproj.txt", "src/{{ProjectName}}.Application/{{ProjectName}}.Application.csproj" },
        { "IonCLI.Templates.Application.DependencyInjection.csharp", "src/{{ProjectName}}.Application/DependencyInjection.cs" },

        // Infrastructure
        { "IonCLI.Templates.Infrastructure.Infrastructure.csproj.txt", "src/{{ProjectName}}.Infrastructure/{{ProjectName}}.Infrastructure.csproj" },
        { "IonCLI.Templates.Infrastructure.DependencyInjection.csharp", "src/{{ProjectName}}.Infrastructure/DependencyInjection.cs" },

        // WebAPI
        { "IonCLI.Templates.WebAPI.WebAPI.csproj.txt", "src/{{ProjectName}}.WebAPI/{{ProjectName}}.WebAPI.csproj" },
        { "IonCLI.Templates.WebAPI.Program.csharp", "src/{{ProjectName}}.WebAPI/Program.cs" },
        { "IonCLI.Templates.WebAPI.appsettings.json.txt", "src/{{ProjectName}}.WebAPI/appsettings.json" }
    };

    public async Task GenerateAsync(ProjectConfig config)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        foreach (var template in _templates)
        {
            var resourceKey = template.Key;
            var relativePath = template.Value.Replace("{{ProjectName}}", config.Name);
            var finalPath = Path.Combine(config.OutputPath, relativePath);

            using var stream = assembly.GetManifestResourceStream(resourceKey);
            if (stream == null)
            {
                Console.WriteLine($"Warning: Resource {resourceKey} not found.");
                continue;
            }

            using var reader = new StreamReader(stream);
            var content = await reader.ReadToEndAsync();

            // Token replacement
            var finalContent = content
                .Replace("{{ProjectName}}", config.Name)
                .Replace("{{NetVersion}}", config.NetVersion);

            // Ensure directory exists
            var dir = Path.GetDirectoryName(finalPath);
            if (!string.IsNullOrEmpty(dir))
            {
                Directory.CreateDirectory(dir);
            }

            await File.WriteAllTextAsync(finalPath, finalContent);
        }
        
        // Create empty solution items or test folders if needed
        Directory.CreateDirectory(Path.Combine(config.OutputPath, "tests"));
    }
}
