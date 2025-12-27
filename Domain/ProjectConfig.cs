
namespace IonCLI.Domain;

public class ProjectConfig
{
    public required string Name { get; set; }
    public required string OutputPath { get; set; }
    public required string NetVersion { get; set; }
    public bool UseAuth { get; set; }
}
