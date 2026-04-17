# Supported Hardware

## BBSHD

| Revision | MCU          | Released | Comment |
| -------- | ------------ | -------- | ------- |
| V1.4     | STC15W4K56S4 | ~2017    | V1.3 printed on PCB, sticker with 1.4. |
| V1.5     | IAP15W4K61S4 | ~2019    | V1.4 printed on PCB, sticker with 1.5. |

Do not flash other BBSHD controller revisions unless you are prepared for the possibility of bricking the controller.

## BBS02B

There are reported compatibility issues with some BBS02 controllers. Newer BBS02B controllers are more likely to work. Older controllers may not be safe to flash.

| Revision | MCU          | Released | Comment |
| -------- | ------------ | -------- | ------- |
| V1.?     | STC15F2K60S2 | Unknown  | Supported from BBS-FW version 1.1. |
| V1.?     | IAP15F2K61S2 | Unknown  | Supported from BBS-FW version 1.1. |

BBS02A is not tested and is not recommended unless the controller is already bricked and you accept the risk.

## TSDZ2

TSDZ2A/B controllers using the STM microcontroller are supported. This is most TSDZ2 controllers. A custom cable is required to interface with Bafang-compatible displays.

## Displays

Only Bafang display protocol displays can work. Display compatibility also depends on how closely the display follows that protocol.

Known display behavior is documented in [Display Behavior](Display-Behavior.md).
