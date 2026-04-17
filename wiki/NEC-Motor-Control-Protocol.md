# NEC Motor Control Protocol

The BBS-FW firmware replaces the firmware on the main STC microcontroller. The firmware on the additional NEC 79F9211 motor-control microcontroller is not replaced.

The NEC MCU implements BLDC motor control and exposes a simplified serial control interface to the STC MCU.

## Serial Protocol

The two microcontrollers communicate directly using an asynchronous serial line.

- Baud rate: 4800.
- All messages start with `0xAA`.
- The final byte is the checksum.
- The checksum is the sum of all previous bytes excluding `0xAA`, truncated to 8 bits.
- The STC MCU sends requests.
- The NEC MCU responds.
- The NEC MCU does not send messages without a request.

## Initialization

The STC MCU repeatedly sends the first initialization command until the NEC MCU responds. This can take a few attempts. During initialization, the requests are echoed as responses.

The leading `AA` header and trailing checksum are omitted from the table.

| Request    | Response   | Interpretation |
| ---------- | ---------- | -------------- |
| `67 00`    | `67 00`    | Probably a hello message. |
| `68 5A`    | `68 5A`    | Set unknown parameter to `0x5A`. |
| `69 11`    | `69 11`    | Set unknown parameter to `0x11`. |
| `6A 78`    | `6A 78`    | Set unknown parameter to `0x78`. |
| `6B 64`    | `6B 64`    | Set unknown parameter to `0x64`. |
| `6C 50`    | `6C 50`    | Set unknown parameter to `0x50`. |
| `6D 46`    | `6D 46`    | Set unknown parameter to `0x46`. |
| `6E 0C`    | `6E 0C`    | Set unknown parameter to `0x0C`. |
| `60 02 56` | `60 02 56` | Set low-voltage cutoff limit. |
| `61 CF`    | `61 CF`    | Set battery max current limit. |

The unknown initialization values are hardcoded in the standard firmware. They may be FOC parameters, motor parameters, or current ramp parameters, but this has not been confirmed.

Known target differences:

- `0x68` is set to `0x5F` on BBS02 instead of `0x5A` on BBSHD.
- `0x60` uses a different range on BBS02: 15.1 steps per volt instead of 14.6 on BBSHD.
- `0x61` uses a different range on BBS02: 5.6 steps per amp instead of 6.9 on BBSHD.

## Commands

The leading `AA` header and trailing checksum are omitted from the table.

| Request | Response | Interpretation |
| ------- | -------- | -------------- |
| `63 XX` | `63 XX` | Target speed, `0-250`, not `255`. |
| `64 XX` | `64 XX` | Target current percentage, `0-100` percent of max current. |

## Status

Status requests are sent frequently by the STC MCU.

The leading `AA` header and trailing checksum are omitted from the table.

| Request | Response   | Interpretation |
| ------- | ---------- | -------------- |
| `40`    | `40 XX XX` | Status and error flags. |
| `41`    | `41 XX`    | ADC battery current. |
| `42`    | `42 XX XX` | ADC battery voltage. |

## Status Flags

| Bit      | Description |
| -------- | ----------- |
| `0x0001` | Unknown. |
| `0x0002` | Unknown. |
| `0x0004` | Current sense resistor fault. |
| `0x0008` | Unknown. |
| `0x0010` | Unknown. |
| `0x0020` | Possible overcurrent fault observed on BBS02. |
| `0x0040` | Unknown. |
| `0x0080` | Unknown; observed when current sensor error is present on boot, cleared when motor power is applied. |
| `0x0100` | Braking. |
| `0x0200` | Unknown. |
| `0x0400` | Motor control disabled. |
| `0x0800` | Low-voltage protection. |
| `0x1000` | Unknown. |
| `0x2000` | Hall sensor fault. |
| `0x4000` | Unknown. |
| `0x8000` | Unknown. |

The Bafang display error list has a motor phase error code, but it has not been identified in this protocol. It may not exist on the BBS line, or the fault detection may be implemented in the STC microcontroller.
