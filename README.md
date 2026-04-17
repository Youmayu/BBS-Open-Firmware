# BBSHD/BBS02B Open Source Firmware

![GitHub all releases](https://img.shields.io/github/downloads/Youmayu/BBS-Open-Firmware/total?style=for-the-badge)
![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/Youmayu/BBS-Open-Firmware?include_prereleases&style=for-the-badge)
![GitHub](https://img.shields.io/github/license/Youmayu/BBS-Open-Firmware?style=for-the-badge)

This firmware is intended to replace the original Bafang firmware on the BBSHD/BBS02 motor controller. Almost all functionality of the original firmware has been implemented and additional features have been added.

This project is based on the original [danielnilsson9/bbs-fw](https://github.com/danielnilsson9/bbs-fw) firmware by Daniel Nilsson. This 2.0 fork is continued by He You Ma and adds updated documentation, configuration tool improvements, display compatibility options, and firmware changes for displays such as the 860C.

This fork is focused on Bafang BBSHD and BBS02B controllers. It is compatible with displays that use the Bafang display protocol. Some displays behave differently even when they use the same protocol, so this fork adds display-specific configuration where needed. If your display is not listed in the configuration tool, use the "Other displays" option.

Warning: The firmware should NOT be flashed or configured while the e-bike battery is charging!

**Download**  
https://github.com/Youmayu/BBS-Open-Firmware/releases

**Install**  
https://github.com/Youmayu/BBS-Open-Firmware/wiki/Flash-Firmware

**Configure**  
https://github.com/Youmayu/BBS-Open-Firmware/wiki/Configuration-Tool

**Build from Source**  
https://github.com/Youmayu/BBS-Open-Firmware/wiki/Build-from-Source

## Known Issues

* BBS02 controllers have reported compatibility issues. Newer BBS02B controllers are more likely to work, but flashing is still at your own risk.
* BBS02A is not tested and is not recommended unless the controller is already bricked and you accept the risk.
* Some displays implement the Bafang protocol differently. Use the display selection option in the configuration tool when available.

## Highlights

* A bit more power without hardware modifications.
* No upper voltage limit in software, can by default run up to 63V, which is the maximum rating of the components.
* Support lower voltage cutoff for use with e.g. a 36V battery.
* Smooth Throttle/PAS override.
* Optional separate set of street legal and offroad assist levels which can be toggled by a key combination.
* Support setting road speed limit per assist level.
* Support setting cadence limit per assist level.
* Support cruise assist levels, i.e. motor power without pedal or throttle input.
* Thermal limiting gradual ramp down.
* Low voltage gradual ramp down.
* Voltage calibration for accurate LVC and low voltage ramp down.
* Display motor/controller temperature on compatible standard display fields.
* Use of speed sensor is optional.
* Optional shift sensor support.
* Optional drivetrain pretension.
* Configurable external lights behavior.
* Configurable display behavior, including 860C work-mode handling.
* Updated configuration tool with modern UI, dark mode, and language selection.

![Config Tool](https://github.com/user-attachments/assets/1534c303-b25f-4fa4-8b37-5b74ade4a800)

## Supported Hardware

### BBSHD

Revision | MCU          | Released    | Comment
-------- | ------------ | ----------- | --------------------
V1.4     | STC15W4K56S4 | ~2017       | V1.3 printed on PCB, sticker with 1.4.
V1.5     | IAP15W4K61S4 | ~2019       | V1.4 printed on PCB, sticker with 1.5.

Do not flash other BBSHD controller revisions unless you accept the risk of bricking the controller.

### BBS02B

There are compatibility issues reported, and this firmware may be incompatible with older BBS02 controllers.

If you have a newer BBS02B you are probably fine, but if you have an older controller it might not be a good idea to flash this firmware.

Revision | MCU          | Released    | Comment
-------- | ------------ | ----------- | --------------------
V1.?     | STC15F2K60S2 | Unknown     | Supported from BBS-FW version 1.1.
V1.?     | IAP15F2K61S2 | Unknown     | Supported from BBS-FW version 1.1.

BBS02A - No idea, not tested, not recommended to try unless you have an already bricked controller.

## Displays and Controller

Only displays with the Bafang display protocol can work.

The controller must be a supported Bafang BBSHD or BBS02B controller.

Some shops sell kits with their own controller. Those controllers are not guaranteed to work.

### Display Selection

The configuration tool includes a display selection option:

* **Other displays** - Uses the standard Bafang display work-mode handling.
* **860C** - Ignores display work-mode requests so the controller controls ECO/Sport mode.

The 860C can continuously send its configured work mode to the controller. If the display is set to ECO mode, it can force the controller back to ECO and prevent the usual controller-side ECO/Sport toggle from working. Selecting 860C makes the motor ignore that display work-mode command after validating the packet checksum.

### Display Data Fields

The firmware also reuses some standard Bafang display fields:

* The range field can show temperature on BBSHD/BBS02.
* The calories field can show battery voltage.
* Walk mode can show speed, temperature, requested power, or battery level depending on configuration.
* Display speed-limit writes are ignored. Configure speed limits in the BBS-FW configuration tool.

More information is available in the wiki:

https://github.com/Youmayu/BBS-Open-Firmware/wiki/Display-Behavior

## Build from Source

### Requirements

* Make for Windows, Cygwin, MSYS2, or another compatible `make`.
* SDCC 4.2.
* Visual Studio 2022 with .NET desktop development workload, if you want to build the configuration tool.

### Build Firmware

Open a command window inside `src/firmware` and run:

```cmd
make
```

The built firmware file is named:

```text
bbs-fw.hex
```

The firmware build output is overwritten each time. If you build for several controllers, build one target, save the generated hex file, then build the next target.

Example:

```cmd
make -B all TARGET_CONTROLLER=BBSHD
copy bbs-fw.hex bbs-fw-BBSHD.hex

make -B all TARGET_CONTROLLER=BBS02
copy bbs-fw.hex bbs-fw-BBS02.hex
```

### Build Configuration Tool

Open the solution file in Visual Studio:

```text
src/tool/bbs-fw-tool.sln
```

Then build the solution. The configuration tool is version 2.0.0.

## Documentation

The GitHub wiki contains the main user documentation:

* Flash Firmware
* Configuration Tool
* Build from Source
* Display Behavior
* Troubleshooting

The local `wiki/` folder contains draft wiki pages that can be published to the GitHub wiki.

## Legal

* Installing this firmware will void your warranty.
* I cannot be held responsible for any injuries caused by the use of this firmware, use at your own risk.
* Incorrect flashing or incompatible hardware can brick the controller.
* Incorrect configuration can make the bike behave unexpectedly. Test changes carefully in a safe area.
