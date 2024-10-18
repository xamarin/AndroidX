// Clean up the output directories
Task ("clean")
    .Does (() =>
{
    if (DirectoryExists ("./externals"))
        DeleteDirectory ("./externals", new DeleteDirectorySettings { Recursive = true, Force = true });

    if (DirectoryExists ("./generated"))
        DeleteDirectory ("./generated", new DeleteDirectorySettings { Recursive = true, Force = true });

    CleanDirectories ("./**/packages");
});
