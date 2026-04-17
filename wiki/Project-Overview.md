# Project Overview

BBS-FW is open source replacement firmware for Bafang BBSHD and BBS02 motor controllers. This fork is focused on Bafang BBSHD and BBS02B controllers.

The firmware implements most original Bafang firmware behavior and adds extra configuration options that are not supported by the standard Bafang configuration tool. Use the BBS-FW configuration tool instead.

## Highlights

- Higher current limits without hardware modification, up to the firmware and controller limit.
- Configurable low-voltage cutoff for different battery voltages.
- Smooth throttle and pedal-assist override behavior.
- Two operation mode pages, normally used as standard and sport assist profiles.
- Per-assist-level road speed limits.
- Per-assist-level cadence limits.
- Cruise assist levels, where motor power can stay active without pedal or throttle input after engagement.
- Gradual thermal current limiting.
- Gradual low-voltage current limiting.
- Battery voltage calibration for more accurate low-voltage cutoff and low-voltage rampdown.
- Temperature display on compatible Bafang display fields.
- Optional speed sensor use.
- Optional shift sensor support on BBSHD and BBS02.
- Optional drivetrain pretension.
- Configurable external lights behavior.

## Compatibility Summary

Only displays that use the Bafang display protocol can work. The controller must also be a supported Bafang BBSHD or BBS02B controller. Some kits sold by shops use custom controllers and are not compatible.

For BBSHD, the current code supports controller revisions with the STC15W4K56S4 or IAP15W4K61S4 MCU. For BBS02B, newer controllers are expected to work, but older BBS02 controllers have reported compatibility issues.

## Legal and Safety

- Installing this firmware voids your warranty.
- Use this firmware at your own risk.
- Incorrect flashing or incompatible hardware can brick the controller.
- Incorrect configuration can make the bike behave unexpectedly. Test changes carefully in a safe area.
