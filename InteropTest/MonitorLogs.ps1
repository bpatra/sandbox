#Make sure you have powershell 3.0 to use this script
$path = Join-Path -Path $env:APPDATA -Child "..\Local\InteropTest\Logs\InteropTest.log"
Get-Content -Wait -Tail 100 $path
