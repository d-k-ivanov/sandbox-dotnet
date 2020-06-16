
Stop-Process -Name dotnet

Start-Process -NoNewWindow  dotnet.exe -ArgumentList "run","-p",".\ServiceOne\"
Start-Process -NoNewWindow  dotnet.exe -ArgumentList "run","-p",".\ServiceTwo\"
Start-Process -NoNewWindow  dotnet.exe -ArgumentList "run","-p",".\ServiceThree\"
Start-Process -NoNewWindow  dotnet.exe -ArgumentList "run","-p",".\ServiceFour\"
Start-Process -NoNewWindow  dotnet.exe -ArgumentList "run","-p",".\ServiceFive\"
