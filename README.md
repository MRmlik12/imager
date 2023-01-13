# imager
[![Test](https://github.com/MRmlik12/imager/actions/workflows/app.yml/badge.svg?branch=main)](https://github.com/MRmlik12/imager/actions/workflows/app.yml)

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

* Download from Github release
* Extract zip
* Run from extracted directory
```bash
$ chmod +x imager
$ ./imager
```

or

* Set global ENV to imager folder

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