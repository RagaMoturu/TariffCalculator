@echo off

REM Clean previous builds
echo Cleaning previous builds...
dotnet clean

REM Build the application
echo Building the .NET application...
dotnet build
if %errorlevel% neq 0 (
    echo Build failed. Please fix errors and try again.
    pause
    exit /b %errorlevel%
)

REM Run the application in the background
start /b dotnet run --project .\TariffCalculator\TariffCalculator.csproj

REM Wait a few seconds to ensure the server has started
timeout /t 15 /nobreak >nul

REM Open the browser (change URL if necessary)
start http://localhost:5000

REM Keep Command Prompt open
pause
