docker run --rm -it --name service_five -p 8005:8005 -v ${PWD}:/ServiceFive mcr.microsoft.com/dotnet/core/sdk:3.1 dotnet run -p /ServiceFive
