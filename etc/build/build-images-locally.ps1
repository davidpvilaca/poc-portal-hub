param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../../"
$appFolder = Join-Path $slnFolder "PortalHub"

$angularAppFolder = Join-Path $slnFolder "../angular"

Write-Host "********* BUILDING Angular Application *********" -ForegroundColor Green
Set-Location $angularAppFolder
yarn
npm run build:prod
docker build -f Dockerfile.local -t mycompanyname/portalhub-web:$version .

Write-Host "********* BUILDING Api.Host Application *********" -ForegroundColor Green
Set-Location $appFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/portalhub-api:$version .


### ALL COMPLETED
Write-Host "********* COMPLETED *********" -ForegroundColor Green
Set-Location $currentFolder