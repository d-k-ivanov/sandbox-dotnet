docker run --rm -it --name service_four -p 8004:8004 -v ${PWD}:/ServiceFour mcr.microsoft.com/dotnet/core/sdk:3.1 dotnet run -p /ServiceFour
