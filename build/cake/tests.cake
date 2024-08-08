// Contains tasks for running tests

// Runs 'AllPackagesTests' test suite without first building packages
Task ("all-packages-tests")
    .Does (() =>
{
    var settings = new DotNetTestSettings {
        Configuration = "Debug"    // We don't need to run linking
    };
        
    DotNetTest ("./tests/allpackages/AllPackagesTests.csproj", settings);
});

// Builds NuGet packages first and then runs 'AllPackagesTests' test suite
Task ("build-run-all-packages-tests")
    .IsDependentOn ("nuget")
    .IsDependentOn ("all-packages-tests");

// Deprecated alias for "all-packages-tests"
Task ("ci-samples")
    .IsDependentOn ("all-packages-tests");

// Deprecated alias for 'all-packages-tests'
Task ("samples-only-dotnet")
    .IsDependentOn ("all-packages-tests");

// Deprecated alias for 'build-run-all-packages-tests'
Task ("samples-dotnet")
    .IsDependentOn ("build-run-all-packages-tests");
