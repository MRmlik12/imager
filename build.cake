var target = Argument("target", "Zip");
var configuration = Argument("configuration", "Release");

string GetOsPlatform()
{
    return Environment.OSVersion.Platform switch
    {
        PlatformID.Win32NT => "win-x64",
        PlatformID.Unix => "linux-x64",
        PlatformID.MacOSX => "osx-x64"
    };
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
            PublishSingleFile = true,
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
