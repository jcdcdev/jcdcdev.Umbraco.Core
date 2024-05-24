$versions = @(10, 12, 13, 14)
$outputPath = (Get-Item -Path ".").FullName + "\artifacts";

if ((Test-Path $outputPath)) {
    Remove-Item -Recurse -Force $outputPath
}

New-Item -ItemType Directory -Path $outputPath

echo "Output path: $outputPath"
foreach ($version in $versions) {
    dotnet build  ./jcdcdev.Umbraco.Core/jcdcdev.Umbraco.Core.csproj /p:UmbracoVersion=$version /p:Configuration=Debug /p:PackageOutputPath="$outputPath" --source https://api.nuget.org/v3/index.json
}
