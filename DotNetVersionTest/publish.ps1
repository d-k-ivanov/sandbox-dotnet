dotnet restore
dotnet build -c release
# dotnet publish -c release --self-contained
# dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true
dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true
