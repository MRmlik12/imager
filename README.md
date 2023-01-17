# imager

[![Test](https://github.com/MRmlik12/imager/actions/workflows/app.yml/badge.svg?branch=main)](https://github.com/MRmlik12/imager/actions/workflows/app.yml)
[![Release](https://github.com/MRmlik12/imager/actions/workflows/release.yml/badge.svg)](https://github.com/MRmlik12/imager/actions/workflows/release.yml)
[![Chocolatey](https://img.shields.io/badge/Chocolatey-imager-80B5E3.svg?style=flat&logo=Chocolatey&logoColor=white)](https://community.chocolatey.org/packages/imager/0.1.0)
[![Discord](https://discord.com/api/guilds/833257104646733844/widget.png?style=shield)](https://discord.gg/djrjH4Sppt)

pretty simple tool to manipulate image in CLI

## Usage

### Suppoted image formats
JPEG, TIFF, PNG, WebP, FITS, Matlab, OpenEXR, PDF, SVG, HDR, PPM, CSV, GIF, Analyze, NIfTI, DeepZoom, OpenSlide

1. Resize an image
```bash
$ imager resize -p path/to/img -s (width)x(height) -o output/path
```

2. Convert image to specific format
```bash
$ imager -p path/to/img -o output/path/file.[convert_extension] -q (image_quality 0 up to 100)
```

3. Adjust contrast of image
```bash
$ imager -p path/to/img -o output/path -c (0.5, 0.7, 1.3)
```

## Install

### Windows

* Via Chocolatey

```powershell
> choco install imager
> imager
```

* Via Github Release

```powershell
> Expand-Archive imager-{version}-win-x64.zip -DestinationPath imager
> cd .\imager
> .\imager
```

### Linux & MacOS

* Via Github Release

```bash
$ unzip imager-{version}-{platform}.zip -d imager
$ cd imager
$ chmod +x imager
$ ./imager
```

## Build

* Install [.NET](https://dotnet.microsoft.com/en-us/download) >= 7.0.100
* Install [Cake](https://cakebuild.net/docs/getting-started/setting-up-a-new-scripting-project) tool
* Run following command

```bash
$ dotnet cake
```

* produced build is on `publish` folder, enjoy :)

## Used dependencies

* [NetVips](https://github.com/kleisauke/net-vip)
* [Spectre.Console](https://github.com/spectreconsole/spectre.console)