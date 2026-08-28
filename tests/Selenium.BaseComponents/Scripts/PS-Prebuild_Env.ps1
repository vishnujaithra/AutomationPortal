param([string]$msbuilddir)

Write-Output "Build env: $Env:SFDX_ENV"
$env = $Env:SFDX_ENV

if (-not ([string]::IsNullOrEmpty($env))) {
    Write-Output "Pre build: $Env:SFDX_ENV"
    ((Get-Content -path $msbuilddir\Utilities\PreBuildConstants.cs) -replace 'PREBUILD_ENV_VALUE', $env.ToLower()) | Set-Content -Path $msbuilddir\Utilities\PreBuildConstants.cs
}