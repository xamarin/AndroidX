
$supportConfigUrl = "https://raw.githubusercontent.com/xamarin/AndroidSupportComponents/master/config.json"

$mappingCsvPath = "androidx-mapping.csv"
$nugetCsvPath = "androidx-assemblies.csv"

$supportJson = (Invoke-WebRequest $supportConfigUrl | ConvertFrom-Json)[0]
$androidxJson = (Get-Content "../config.json" | ConvertFrom-Json)[0]

$assembliesContent = @(
    "Support .NET assembly,AndroidX .NET assembly,Support NuGet,AndroidX NuGet"
)

$csv = (Get-Content $mappingCsvPath |
    ConvertFrom-Csv |
    Where-Object { $_."Support .NET assembly" -ne "" } |
    Select-Object -Property "Support .NET assembly","AndroidX .NET assembly" -Uniq)

foreach ($mapping in $csv) {
    $supportNuGet = ($mapping."Support .NET assembly")
    foreach ($artifact in ($supportJson[0]."artifacts")) {
        if (($artifact."assemblyName") -eq ($mapping."Support .NET assembly")) {
            $supportNuGet = ($artifact."nugetId")
            break
        }
    }
    $androidxNuGet = ($mapping."AndroidX .NET assembly")
    foreach ($artifact in ($androidxJson[0]."artifacts")) {
        if (($artifact."assemblyName") -eq ($mapping."AndroidX .NET assembly")) {
            $androidxNuGet = ($artifact."nugetId")
            break
        }
    }
    $assembliesContent +=
        $mapping."Support .NET assembly" + "," +
        $mapping."AndroidX .NET assembly" + "," +
        $supportNuGet + "," +
        $androidxNuGet
}

$assembliesContent | Set-Content $nugetCsvPath
