# Build

Simple build (`ci` build done on CI Azure DevOps servers):

```
dotnet cake -t=ci
```

Clean `ci` build followed by nuget API diff and then several utility tqrgets:

On MacOSX (and Linux):

```bash
dotnet cake -t=clean && dotnet cake -t=ci && dotnet cake nuget-diff.cake && dotnet cake utilities.cake
```

## Build (`build.cake`)

*   `inject-variables`

*   `check-tools`

*   `tools-update`

*   `javadocs`

        Prepares javadocs for parameter names.

*   `binderate`

    Runs `binderator` on `config.json` data.

*   `binderate-config-verify`

    Verifies versions in `config.json`

*   `binderate-diff`

    Runs `diff` to see details of the update.

*   `binderate-fix`

*   `binderate-nuget-check`

*   `metadata-verify`

*   `libs`

    Builds projects (assemblies - libraries - libs)

*   `libs-native`

    Builds native maven projects with gradle.

*   `nuget`

    Generates (packaging) NuGet packages for projects.

*   `samples-generate-all-targets`

    Generates list of locally built packages which are tested during samples builds.

*   `samples`

    Builds samples

*   `samples-dotnet`

    Builds samples - `net6` target.

*   `api-diff`

*   `diff`

*   `clean`

    Cleans folders and files.

*   `packages`

*   `full-run`

*   `ci`

    Builds projects on CI (`libs`, `nuget`, `samples`).

## Nuget API diff (`nuget-diff.cake`)

## Utilities (`utilities.cake`)

*   `generate-component-governance`

    Generates Components Governance `cgmanifest.json`

*   `mappings-artifact-nuget`

    Generates mapping maven artifacts to nuget packages.

*   `list-artifacts`

    Generate list of the maven artifacts and its nuget package.

*   `spell-check`

    Spell checks namespaces and nuget packages.

*   `namespace-check`

    Verifies namespaces (names and casing)

*   `binderate-diff`

    Runs `diff` to see details of the update.

*   `target-sdk-version-check`

    Verification of TFMs.

*   `api-diff-markdown-info-pr`

    Generates Markdown about update info for PRs (weekly stable updates)

*   `api-diff-analysis`

    Generates Markdown about update info for PRs (weekly stable updates)

*   `nuget-structure-analysis`

    Unpacks nuget packages, so the structure can be verified.

*   `read-analysis-files`

    Opens analysis files (API diff, spell checking, etc) VS Code required.

*   `generate-markdown-publish-log`

    Generates MarkDown based on CI NuGet publish log.

*   `dependencies`

    WIP: dependency trees generation (Maven and Nuget)

*   `generate-namespace-file`

*   `verify-namespace-file`

*   `Default`

    Default target - `ci`
