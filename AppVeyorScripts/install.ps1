$source = "https://download.unity3d.com/download_unity/292b93d75a2c/Windows64EditorInstaller/UnitySetup64.exe"
$destination = ".\UnitySetup64.exe"
Invoke-WebRequest $source -OutFile $destination
Start-Process -FilePath ".\UnitySetup64.exe" -Wait -ArgumentList ('/S', '/Q')
Write-Host "$(date) UnitySetup64-2019.1 Installed"-ForegroundColor green