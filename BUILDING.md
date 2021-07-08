## Building

### Prerequisites

Before building the libraries and samples in this repository, you will need to install [.NET Core](https://dotnet.microsoft.com/download) and the [Cake .NET Core Tool](http://cakebuild.net):

```sh
dotnet tool install -g cake.tool
dotnet tool install -g xamarin.androidbinderator.tool
dotnet tool install -g xamarin.androidx.migration.tool
```

> NOTE: If you previously installed any of these tools, be sure to update them to the latest versions.

For API diffs install `api-tools`

```
dotnet tool install -g api-tools
```

### Compiling

You can now build all the packages by running:

```sh
dotnet cake
```

If you are going to make changes to the `config.json`, then you can run the `packages` target to re-generate all the necessary files:

```sh
dotnet cake --target=packages
```
