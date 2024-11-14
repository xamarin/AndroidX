// Contains tasks for updating/modifying the config.json used by binderator

// Updates config.json to the latest versions found in Maven
Task ("update-config")
    .Does (() =>
{
    var args = new ProcessArgumentBuilder ()
        .Append ("update")
        .Append ("--config-file")
        .Append ("config.json");
    
    DotNetRun (binderator_project, args);
});

// Increments the NuGet patch version of all packages in config.json
Task ("bump-config")
    .Does (() =>
{
    var args = new ProcessArgumentBuilder ()
        .Append ("bump")
        .Append ("--config-file")
        .Append ("config.json");
    
    DotNetRun (binderator_project, args);
});

// Sorts config.json file using the canonical sort
Task ("sort-config")
    .Does (() =>
{
    var args = new ProcessArgumentBuilder ()
        .Append ("sort")
        .Append ("--config-file")
        .Append ("config.json");
    
    DotNetRun (binderator_project, args);
});

// Shows which NuGet package versions in config.json have been published to NuGet.org
Task ("published-config")
    .Does (() =>
{
    var args = new ProcessArgumentBuilder ()
        .Append ("published")
        .Append ("--config-file")
        .Append ("config.json");
    
    DotNetRun (binderator_project, args);
});
