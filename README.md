# IonCLI ⚡

**IonCLI** is a minimal CLI tool for scaffolding .NET WebAPI solutions following Clean Architecture principles.

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

Create a new project:

```bash
ion new MyApp
```

With specific .NET version:

```bash
ion new MyApp --net net9.0
```

Use defaults (no prompts):

```bash
ion new MyApp --defaults
```

## ✨ Features

- **Clean Architecture** - Domain, Application, Infrastructure, and WebAPI layers
- **.NET 8 & 9 Support** - Choose your target framework
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

IonCLI generates a **minimal, opinionated** Clean Architecture structure. You configure your own:
- Database (EF Core, Dapper, MongoDB, etc.)
- Authentication (JWT, OAuth, etc.)
- Docker setup
- Additional services

This gives you complete control over your architecture.

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
