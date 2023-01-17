var target = Argument("target", "Build");
var configuration = Argument("configuration", "Release");
var version = Argument("tag", "");

string[] GetOsPlatform()
{
    if (OperatingSystem.IsMacOS())
    {
        return new [] { "osx-arm64", "osx-x64" };
    } else if (OperatingSystem.IsWindows()) {
        return new [] { "win-x64" };
    }
    
    return new [] { "linux-x64", "linux-arm64" };
}

void ZipBuild(string platform, string version = "")
{
    string fileName;
    if (string.IsNullOrEmpty(version))
        fileName = $"./publish/imager-{platform}.zip";
    else
        fileName = $"./publish/imager-{version}-{platform}.zip";

    Zip($"./build/{platform}", fileName);
}

Task("Setup")
    .Does(() => 
    {
        DotNetRestore(new DotNetRestoreSettings
        {
            Verbosity = DotNetVerbosity.Detailed
        });
    });

Task("Build")
    .IsDependentOn("Setup")
    .Does(() => 
    {
        var os = Environment.OSVersion;
        var runtimes = GetOsPlatform();

        CreateDirectory("./publish");

        foreach (var runtime in runtimes)
        {
            DotNetPublish("./src/Imager.Cli", new DotNetPublishSettings
            {
                Configuration = configuration,
                NoRestore = true,
                Runtime = runtime,
                OutputDirectory = $"./build/{runtime}",
                SelfContained = true,
                PublishSingleFile = true,
                Verbosity = DotNetVerbosity.Detailed
            });

            if (version == "")
                ZipBuild(runtime);
            else
                ZipBuild(runtime, version);
        }
    }); 

Task("BuildChocolateyPackage")
    .Does(() =>
    {
        if (!OperatingSystem.IsWindows()) {
            Error("Chocolatey package build only works on Windows platform");
            return;
        }

        if (string.IsNullOrEmpty(version))
            CopyFile("./publish/imager-win-x64.zip", "./deploy/chocolatey/tools/imager-win-x64.zip");
        else
            CopyFile($"./publish/imager-{version}-win-x64.zip", $"./deploy/chocolatey/tools/imager-{version}-win-x64.zip");

        ChocolateyPack("./deploy/chocolatey/imager.nuspec", new ChocolateyPackSettings
        {
            Verbose = true
        });
    });

Task("Clean")
    .Does(() => 
    {
        var directories = new DirectoryPath[]
        {
            Directory("build"),
            Directory("publish")
        };

        DeleteDirectories(directories, new DeleteDirectorySettings
        {
            Force = true,
            Recursive = true
        });
    });

RunTarget(target);
