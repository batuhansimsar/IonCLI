
namespace IonCLI.Domain;

public class ProjectConfig
{
    public required string Name { get; set; }
    public required string OutputPath { get; set; }
    public required string NetVersion { get; set; }
    public DatabaseType Database { get; set; }
    public bool UseAuth { get; set; }
    public bool UseDocker { get; set; }
}

public enum DatabaseType
{
    SQLServer,
    PostgreSQL,
    SQLite,
    None
}
