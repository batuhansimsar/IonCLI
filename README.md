# IonCLI 🚀

**IonCLI** is a powerful CLI tool for scaffolding modern .NET 8/9 WebAPI solutions that adhere to Clean Architecture principles in seconds.

## 📦 Installation

### Method 1: Automatic (Recommended for macOS/Linux)
Download and run the installation script to handle PATH configuration automatically:

```bash
curl -sSL https://raw.githubusercontent.com/batuhansimsar/IonCLI/main/install.sh | bash
```

### Method 2: Manual
Install globally via .NET CLI:

```bash
dotnet tool install -g IonCLI
```

If the command `ion` is not found after installation, you may need to add `.dotnet/tools` to your PATH manually.

To update to the latest version:

```bash
dotnet tool update -g IonCLI
```

## 🚀 Usage

To create a new project, navigate to your desired directory and run:

```bash
ion new <ProjectName>
```

Example:
```bash
ion new MyAwesomeApp
```

You will be prompted with the following options:
1.  **.NET Version**: .NET 8 (LTS) or .NET 9.0
2.  **Database**: PostgreSQL, SQL Server, SQLite, or None (InMemory)
3.  **Docker Support**: Whether to include Dockerfile and docker-compose files.

## ✨ Features

*   **Clean Architecture**: A structure fully compliant with Domain, Application, Infrastructure, and WebAPI layers.
*   **Dynamic Templates**: Code is automatically adjusted based on your selected database and .NET version.
*   **Production Ready**: Comes pre-configured with Entity Framework Core, MediatR, FluentValidation, and Swagger.
*   **Docker Ready**: Ready to launch with a single command (`docker-compose up`).
*   **Documentation**: Every generated project includes its own `ARCHITECTURE.md` file.

---
*Developed by Eşref Batuhan Simsar*
