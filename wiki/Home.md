# BBS-FW Wiki

This wiki is a cleaned local copy of the upstream BBS-FW documentation, updated against the current code in this repository.

## Start Here

- [Project Overview](Project-Overview.md)
- [Supported Hardware](Supported-Hardware.md)
- [Build from Source](Build-from-Source.md)
- [Flash Firmware](Flash-Firmware.md)
- [Upgrade Firmware Version](Upgrade-Firmware-Version.md)
- [Configuration Tool](Configuration-Tool.md)
- [Display Behavior](Display-Behavior.md)
- [Troubleshooting](Troubleshooting.md)

## Technical Reference

- [BBSHD Controller PCB](BBSHD-Controller-PCB.md)
- [NEC Motor Control Protocol](NEC-Motor-Control-Protocol.md)
- [Bafang Display Protocol](Bafang-Display-Protocol.md)

## Important Notes

- Do not flash or configure the controller while the e-bike battery is charging.
- Installing this firmware will void the controller warranty.
- Flashing firmware always carries a risk of bricking the controller. Read the hardware compatibility notes before flashing.
- The generated firmware file is target-specific. Build and save separate `.hex` files for BBSHD and BBS02.
