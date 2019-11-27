
$supportConfigUrl = "https://raw.githubusercontent.com/xamarin/AndroidSupportComponents/master/config.json"

$mappingCsvPath = "androidx-mapping.csv"
$nugetCsvPath = "androidx-assemblies.csv"

$supportJson = (Invoke-WebRequest $supportConfigUrl | ConvertFrom-Json)[0]
$androidxJson = (Get-Content "../config.json" | ConvertFrom-Json)[0]

$assembliesContent = @(
    "Support .NET assembly,AndroidX .NET assembly,Support NuGet,AndroidX NuGet,AndroidX NuGet Version"
)

$csv = (Get-Content $mappingCsvPath |
    ConvertFrom-Csv |
    Where-Object { $_."Support .NET assembly" -ne "" } |
    Sort-Object { $_."Support .NET assembly" } |
    Select-Object -Property "Support .NET assembly","AndroidX .NET assembly" -Uniq)

foreach ($mapping in $csv) {
    $supportNuGet = ($mapping."Support .NET assembly")
    foreach ($artifact in ($supportJson[0]."artifacts")) {
        $name = ($artifact."assemblyName")
        if (-not $name) {
            $name = ($artifact."nugetId")
        }
        if (($name) -eq ($mapping."Support .NET assembly")) {
            $supportNuGet = ($artifact."nugetId")
            break
        }
    }
    $androidxNuGet = ($mapping."AndroidX .NET assembly")
    $androidxVersion = ""
    foreach ($artifact in ($androidxJson[0]."artifacts")) {
        $name = ($artifact."assemblyName")
        if (-not $name) {
            $name = ($artifact."nugetId")
        }
        if (($name) -eq ($mapping."AndroidX .NET assembly")) {
            $androidxNuGet = ($artifact."nugetId")
            $androidxVersion = ($artifact."nugetVersion")
            break
        }
    }
    $assembliesContent +=
        $mapping."Support .NET assembly" + "," +
        $mapping."AndroidX .NET assembly" + "," +
        $supportNuGet + "," +
        $androidxNuGet + "," +
        $androidxVersion
}

$assembliesContent | Set-Content $nugetCsvPath
