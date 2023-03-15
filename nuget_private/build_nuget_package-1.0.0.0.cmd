@echo off
dotnet build --configuration Release /p:Version=1.0.0.0 ..\SecurityHardening.sln
dotnet pack --configuration Release /p:Version=1.0.0.0 --no-build ..\SecurityHardening.sln
move ..\src\Mits.SecurityHardening.Core\bin\Release\Mits.SecurityHardening.Core.1.0.0.nupkg .