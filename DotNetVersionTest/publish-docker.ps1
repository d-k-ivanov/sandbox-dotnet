docker run -it                              `
    -v ${PSScriptRoot}:c:\workdir           `
    -w c:\workdir                           `
    mcr.microsoft.com/dotnet/core/sdk:3.0   `
    dotnet publish -r win-x64 -c Release    `
        /p:PublishSingleFile=true           `
        /p:PublishTrimmed=true
