var target = Argument("target", "Zip");
var configuration = Argument("configuration", "Release");

string GetOsPlatform()
{
    var os = Environment.OSVersion;

    var runtime = string.Empty;
    switch (os.Platform)
    {
        case PlatformID.Win32NT:
            runtime = "win-x64";
            break;
        case PlatformID.Unix:
            runtime = "linux-x64";
            break;
        case PlatformID.MacOSX:
            runtime = "osx-x64";
            break;
    }

    return runtime;
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

        var runtime = GetOsPlatform();

        DotNetPublish("./src/Imager.Cli", new DotNetPublishSettings
        {
            Configuration = configuration,
            NoRestore = true,
            Runtime = runtime,
            OutputDirectory = "./build",
            SelfContained = true,
            Verbosity = DotNetVerbosity.Detailed
        });
    });

Task("Zip")
    .IsDependentOn("Build")
    .Does(() => 
    {
        var platform = GetOsPlatform();
        CreateDirectory("./publish");
        Zip("./build", $"./publish/imager-{platform}.zip");
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
