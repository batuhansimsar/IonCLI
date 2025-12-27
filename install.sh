#!/bin/bash

echo "🚀 Installing IonCLI..."

# 1. Install or Update the Tool
if dotnet tool list -g | grep -q "ioncli"; then
    echo "Updating IonCLI..."
    dotnet tool update -g IonCLI
else
    echo "Installing IonCLI..."
    dotnet tool install -g IonCLI
fi

# 2. Detect Shell Profile
PROFILE_FILE=""
case "$SHELL" in
  */zsh)
    PROFILE_FILE="$HOME/.zprofile"
    ;;
  */bash)
    PROFILE_FILE="$HOME/.bash_profile"
    ;;
  *)
    PROFILE_FILE="$HOME/.profile"
    ;;
esac

# 3. Add to PATH if missing
TOOLS_PATH="$HOME/.dotnet/tools"

if [[ ":$PATH:" != *":$TOOLS_PATH:"* ]]; then
    echo "⚠️  .dotnet/tools is not in your PATH. Configuring $PROFILE_FILE..."
    
    echo "" >> "$PROFILE_FILE"
    echo "# .NET Core SDK Tools" >> "$PROFILE_FILE"
    echo "export PATH=\"\$PATH:$TOOLS_PATH\"" >> "$PROFILE_FILE"
    
    echo "✅ Added to PATH."
    echo "👉 IMPORTANT: Run 'source $PROFILE_FILE' or restart your terminal to use 'ion' command."
else
    echo "✅ .dotnet/tools is already in your PATH."
fi

echo ""
echo "🎉 IonCLI is ready! Type 'ion new <ProjectName>' to start."
