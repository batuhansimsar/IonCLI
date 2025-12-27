# IonCLI 🚀

**IonCLI** is a powerful CLI tool for scaffolding modern .NET 8/9 WebAPI solutions that adhere to Clean Architecture principles.

## 📦 How to Run (Source Code)

You don't need to install anything globally! Just clone the repository and run it directly.

1.  **Clone the Repository**:
    ```bash
    git clone https://github.com/batuhansimsar/IonCLI.git
    cd IonCLI
    ```

2.  **Run the Tool**:
    Run the tool using `dotnet run`. The extra `--` separator is used to pass arguments to the tool itself.

    ```bash
    dotnet run -- new <ProjectName>
    ```

    Example:
    ```bash
    dotnet run -- new MyAwesomeApp
    ```

    With options:
    ```bash
    dotnet run -- new QuickApp --defaults
    ```

## 🚀 Requirements
*   [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later.
*   Works on **Windows, macOS, and Linux**.

## ✨ Features
*   **Clean Architecture Scaffolding**
*   **Dynamic Templates** (.NET 8/9, Postgres, MSSQL, SQLServer, SQLite)
*   **Docker Support**

---
*Developed by Eşref Batuhan Simsar*
