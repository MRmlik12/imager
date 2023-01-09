#addin nuget:?package=Cake.Git&version=2.0.0
var target = Argument("target", "Build");
var configuration = Argument("configuration", "Release");

string[] GetOsPlatform()
{
    return Environment.OSVersion.Platform switch
    {
        PlatformID.Win32NT => new [] { "win-x64" },
        PlatformID.Unix => new [] { "linux-x64", "linux-arm64" },
        PlatformID.MacOSX => new [] { "osx-arm64", "osx-x64" }
    };
}

void ZipDevRelease(string platform)
{
    var lastCommit = GitLogTip(".");
    Zip($"./build/{platform}", $"./publish/imager-{platform}-{lastCommit.Sha}.zip");
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

            ZipDevRelease(runtime);
        }
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
