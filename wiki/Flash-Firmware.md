# Flash Firmware

## Warning

Proceed with caution. Keep a copy of the original firmware if you may want to roll back later.

Do not flash or configure the controller while the e-bike battery is charging.

## BBSHD Notes

If your BBSHD controller is not revision 1.4 or 1.5, do not proceed unless you accept the risk of bricking the controller.

If you have an older revision, run `Check MCU` in the STC ISP tool first and compare the reported MCU with the supported hardware list.

## BBS02 Notes

There are reported compatibility issues with some BBS02 controllers. Newer BBS02B controllers are more likely to work. Older controllers may not be safe to flash.

## Requirements

- STC ISP Programming Software.
- Bafang programming cable.
- Correct `.hex` firmware file for your controller target.

Use the correct firmware target:

- BBSHD: build with `TARGET_CONTROLLER=BBSHD`.
- BBS02/BBS02B: build with `TARGET_CONTROLLER=BBS02`.

## Flash Procedure

1. Download and start the STC ISP Programming Tool. The upstream wiki recommended v6.88 and advised not updating it.
2. Download or build the firmware `.hex` file for your controller type.
3. Connect your controller to the computer using the programming cable.
4. Select the correct COM port in the STC ISP tool.
5. Power off the controller.
6. Click `Check MCU`, then power on the controller.
7. Verify that the log says `Complete!` and that the printed MCU type matches a supported controller.
8. Set the flashing parameters carefully. Set the input IRC frequency to 20 MHz.
9. Click `Open Code File` and select the correct firmware `.hex` file.
10. Power off the controller again.
11. Click `Download/Program`, then power on the controller.
12. Wait for flashing to complete.

If flashing fails, power cycle and try again. The process can be unstable.

## Linux

On Linux, `stcgal` may work for flashing STC controllers:

```text
https://github.com/grigorig/stcgal
```
