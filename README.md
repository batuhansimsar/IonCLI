# IonCLI ⚡

**IonCLI** is a minimal CLI tool for scaffolding .NET 8/9 WebAPI solutions following Clean Architecture principles.

> **Note:** This tool generates a **template structure only**. You configure your own database, authentication, Docker, and other infrastructure.

## 📦 Installation

Install globally via NuGet:

```bash
dotnet tool install -g IonCLI
```

Update to the latest version:

```bash
dotnet tool update -g IonCLI
```

## 🚀 Quick Start

Create a new project with **.NET 8** (default):

```bash
ion new MyApp
```

Create a new project with **.NET 9**:

```bash
ion new MyApp --net net9.0
```

Use defaults (no prompts):

```bash
ion new MyApp --defaults
```

## ✨ Features

- **Clean Architecture Template** - Domain, Application, Infrastructure, and WebAPI layers
- **.NET 8 & 9 Support Only** - Choose `net8.0` or `net9.0`
- **Minimal Setup** - No pre-configured database or Docker, you add what you need
- **Interactive & Non-Interactive Modes** - Flexible project generation

## 📁 Generated Project Structure

```
MyApp/
├── src/
│   ├── MyApp.Domain/
│   ├── MyApp.Application/
│   ├── MyApp.Infrastructure/
│   └── MyApp.WebAPI/
├── tests/
├── ARCHITECTURE.md
└── .gitignore
```

## 🛠️ What's Included

- **Domain Layer** - Entities and common base classes
- **Application Layer** - Business logic and interfaces
- **Infrastructure Layer** - Empty placeholder for your data access, external services, etc.
- **WebAPI Layer** - ASP.NET Core Web API with Swagger

## 💡 Philosophy

IonCLI generates a **minimal, opinionated** Clean Architecture template. You configure your own:
- Database (EF Core, Dapper, MongoDB, etc.)
- Authentication (JWT, OAuth, etc.)
- Docker setup
- Additional services

This gives you complete control over your architecture.

## 📝 Examples

**.NET 8 Project:**
```bash
ion new MyNet8App --net net8.0
```

**.NET 9 Project:**
```bash
ion new MyNet9App --net net9.0
```

**Quick Start (defaults to .NET 8):**
```bash
ion new QuickApp --defaults
```

## ❓ Troubleshooting

**"Command not found: ion"**

The .NET tools folder is not in your PATH.

- **macOS/Linux**: Add to `.zshrc` or `.bash_profile`:
  ```bash
  export PATH="$PATH:$HOME/.dotnet/tools"
  ```
- **Windows**: Add `%USERPROFILE%\.dotnet\tools` to your Environment Variables.

Then restart your terminal.

## 📝 License

MIT

---

**Developed by Eşref Batuhan Simsar**
