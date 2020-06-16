docker run --rm -it --name service_three -p 8003:8003 -v ${PWD}:/ServiceThree mcr.microsoft.com/dotnet/core/sdk:3.1 dotnet run -p /ServiceThree
