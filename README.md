# PlaywrightTestsWithDotNet

Training project was created to try work of Pyawright with .NET

![Test Example](/Images/TestExample.png)

## Build

### Command line

- Type "dotnet build"

![CMD build](/Images/cmd_build.png)

### Visual Studio Build

- Open project/solution in VIsual Studio
- Open context menu for the Project or Solution and choose "Build"

![Visual Studio build](/Images/VS_build.png)

## Test Run

### VIsual Studio

-  Select .runsettings file from Test --> Configure Run Settings
- In Test Explorer --> Select test/s you want to run

### Command line

- In CMD, type "dotnet test - settings:chromium.runsettings"