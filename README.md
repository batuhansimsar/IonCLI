# IonCLI 🚀

**IonCLI** is a powerful CLI tool for scaffolding modern .NET 8/9 WebAPI solutions that adhere to Clean Architecture principles.

## 📦 Installation

Install the tool globally using the standard .NET CLI command:

```bash
dotnet tool install -g IonCLI
```

To update to the latest version:

```bash
dotnet tool update -g IonCLI
```

## 🚀 Usage

Once installed, you can use the `ion` command anywhere in your terminal.

**Interactive Mode:**
```bash
ion new <ProjectName>
```

**Example:**
```bash
ion new MyAwesomeApp
```

**Non-Interactive (Command flags):**
```bash
ion new QuickApp --defaults
ion new CustomApp --net net9.0 --db SQLite --docker false
```

## ❓ Troubleshooting

**"Command not found: ion"**
If you see this error after installation, it means the .NET tools folder is not in your system PATH.

*   **Mac/Linux**: Add `export PATH="$PATH:$HOME/.dotnet/tools"` to your `.zshrc` or `.bash_profile`.
*   **Windows**: The path `%USERPROFILE%\.dotnet\tools` is usually added automatically. If not, add it to your Environment Variables manually.

## ✨ Features
*   **Clean Architecture Scaffolding**
*   **Dynamic Templates** (.NET 8/9, Postgres, MSSQL, SQLite)
*   **Docker Support**

---
*Developed by Eşref Batuhan Simsar*
