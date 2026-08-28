param([string]$msbuilddir)

Write-Output "Build env: $Env:SFDX_ENV"
$env = $Env:SFDX_ENV

if (-not ([string]::IsNullOrEmpty($env))) {
    Write-Output "Post build: $Env:SFDX_ENV"
    ((Get-Content -path $msbuilddir\Utilities\PreBuildConstants.cs) -replace $env.ToLower(), "PREBUILD_ENV_VALUE") | Set-Content -Path $msbuilddir\Utilities\PreBuildConstants.cs
}