
using System.Reflection;
using System.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using IonCLI.Commands;
using IonCLI.Services;

var services = new ServiceCollection();

// Register Services
services.AddSingleton<IInteractiveConsole, InteractiveConsole>();
services.AddSingleton<ITemplateGenerator, TemplateGenerator>();
services.AddSingleton<NewCommand>();

var serviceProvider = services.BuildServiceProvider();

// Setup Command Line
var rootCommand = new RootCommand("IonCLI - Lightning fast .NET generator");

// Add subcommand resolved from DI
var newCommand = serviceProvider.GetRequiredService<NewCommand>();
rootCommand.AddCommand(newCommand);

// Execute
await rootCommand.InvokeAsync(args);
