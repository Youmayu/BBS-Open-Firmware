# Troubleshooting

## `make` or `sdcc` Is Not Found

Make sure both tools are installed and on the Windows `Path`.

Typical install paths:

```text
C:\Program Files (x86)\GnuWin32\bin
C:\Program Files\SDCC\bin
```

Check from PowerShell:

```powershell
where make
where sdcc
where packihx
```

If the commands are still not found after editing `Path`, fully close and reopen VS Code or your terminal.

## Wrong Firmware Target

The file `src/firmware/bbs-fw.hex` is overwritten by every build. If you build BBS02 after BBSHD, the generic file becomes BBS02 firmware.

Use target-specific saved copies when handling more than one controller:

```powershell
make -B all TARGET_CONTROLLER=BBSHD
copy bbs-fw.hex bbs-fw-BBSHD.hex

make -B all TARGET_CONTROLLER=BBS02
copy bbs-fw.hex bbs-fw-BBS02.hex
```

## 860C Forces ECO or Sport Mode

Some 860C displays continuously send a work-mode command. In upstream behavior, that can override a controller-side operation-mode toggle.

In this fork, display work-mode commands are ignored after checksum validation. Use the configuration tool's operation-mode toggle setting instead.

## Display Max Speed Setting Has No Effect

This is expected. The firmware ignores display speed-limit writes. Configure max speed and per-assist-level speed percentages in the BBS-FW configuration tool.

## Temperature Is Not Shown Where Expected

The firmware does not have a dedicated Bafang motor-temperature display field. It repurposes other display fields:

- The range field shows temperature by default on BBSHD and BBS02.
- Walk mode can show temperature in the speed field while walk assist is active.
- BBSHD reports the higher value of controller and motor temperature.
- BBS02 reports controller temperature only.

See [Display Behavior](Display-Behavior.md).

## Power Drops Near Lower Battery Voltage

Check the event log for low-voltage limiting and verify that battery voltage calibration is correct.

The firmware uses a filtered minimum loaded voltage for low-voltage limiting. The voltage shown on the display may not match the voltage being used internally during load because display voltage is often updated after motor power has been off for a short time.

If the configured low-voltage cutoff is too high, or if the pack sags heavily under load, current rampdown can begin earlier than expected.
