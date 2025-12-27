Write-Host "🚀 Installing IonCLI..." -ForegroundColor Cyan

# 1. Install or Update
$installed = dotnet tool list -g | Select-String "IonCLI"
if ($installed) {
    Write-Host "Updating IonCLI..." -ForegroundColor Yellow
    dotnet tool update -g IonCLI
}
else {
    Write-Host "Installing IonCLI..." -ForegroundColor Green
    dotnet tool install -g IonCLI
}

# 2. Check PATH
$dotnetToolsPath = [System.IO.Path]::Combine([System.Environment]::GetFolderPath("UserProfile"), ".dotnet", "tools")
$currentPath = [System.Environment]::GetEnvironmentVariable("Path", "User")

if ($currentPath -notlike "*$dotnetToolsPath*") {
    Write-Host "⚠️ .dotnet/tools is not in your PATH. Adding it now..." -ForegroundColor Yellow
    $newPath = "$currentPath;$dotnetToolsPath"
    [System.Environment]::SetEnvironmentVariable("Path", $newPath, "User")
    Write-Host "✅ Added to PATH. Please restart your terminal." -ForegroundColor Green
}
else {
    Write-Host "✅ PATH is already configured." -ForegroundColor Green
}

Write-Host "🎉 IonCLI is ready! Type 'ion new <ProjectName>' to start." -ForegroundColor Cyan
