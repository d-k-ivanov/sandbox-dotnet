docker run --rm -it --name service_one -p 8001:8001 -v ${PWD}:/ServiceOne mcr.microsoft.com/dotnet/core/sdk:3.1 dotnet run -p /ServiceOne
