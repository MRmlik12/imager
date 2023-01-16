$ErrorActionPreference = 'Stop';
$toolsDir   = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
$unzipLocation = $toolsDir + "\bin"

$packageArgs = @{
  packageName   = 'imager'
  unzipLocation = $unzipLocation
  file          = Get-Item $toolsDir\*.zip
}

Get-ChocolateyUnzip @packageArgs
Remove-Item $toolsDir\*.zip