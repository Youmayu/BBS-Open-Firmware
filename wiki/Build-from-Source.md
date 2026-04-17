# Build from Source

## Requirements

- Make for Windows, Cygwin, MSYS2, or another compatible `make`.
- SDCC 4.2.
- Visual Studio 2022 with the .NET desktop development workload if you want to build the configuration tool.

The firmware build does not require Visual Studio. Visual Studio is only needed for the Windows configuration tool in `src/tool`.

## Build Firmware

Open a terminal in:

```text
src/firmware
```

Build BBSHD firmware:

```powershell
make -B all TARGET_CONTROLLER=BBSHD
```

Build BBS02 firmware:

```powershell
make -B all TARGET_CONTROLLER=BBS02
```

Build TSDZ2 firmware:

```powershell
make -B all TARGET_CONTROLLER=TSDZ2
```

The generated firmware file is:

```text
src/firmware/bbs-fw.hex
```

This file is overwritten by each build. If you need firmware for more than one controller, build and save each target separately:

```powershell
make -B all TARGET_CONTROLLER=BBSHD
copy bbs-fw.hex bbs-fw-BBSHD.hex

make -B all TARGET_CONTROLLER=BBS02
copy bbs-fw.hex bbs-fw-BBS02.hex
```

## Build Configuration Tool

Open this solution in Visual Studio 2022:

```text
src/tool/bbs-fw-tool.sln
```

Then build the solution from Visual Studio.

Visual Studio Community is enough for personal and open source use. A paid Visual Studio subscription is not required for that use case.
