docker run --rm -it --name service_two -p 8002:8002 -v ${PWD}:/ServiceTwo mcr.microsoft.com/dotnet/core/sdk:3.1 dotnet run -p /ServiceTwo
