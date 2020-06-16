if ( Get-Process -Name "dotnet" -ErrorAction SilentlyContinue )
{
    Stop-Process -Name dotnet
}
