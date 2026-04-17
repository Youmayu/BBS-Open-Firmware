# Bafang Display Protocol

The Bafang display protocol is a request/response protocol. The display sends requests and the controller responds.

The protocol uses a trailing checksum in most packets, but it is inconsistent.

## Serial Protocol

- Read requests start with `0x11`.
- Write requests start with `0x16`.
- The next byte is the opcode.
- When a checksum is present, it is usually the sum of the data bytes after the request type and opcode, truncated to 8 bits.

## Read Requests

### Read Status

Request:

```text
11 08
```

Response:

```text
XX
```

`XX` is a Bafang-compatible status code.

Common status values in this firmware:

| Code | Meaning |
| ---- | ------- |
| `0x01` | Normal. |
| `0x03` | Braking. |
| `0x04` | Throttle high. |
| `0x05` | Throttle fault. |
| `0x06` | Low-voltage cutoff, currently disabled for display reporting in code. |
| `0x08` | Hall sensor fault. |
| `0x09` | Phase-line or power-reset related fault. |
| `0x10` | Controller over temperature. |
| `0x11` | Motor over temperature. |
| `0x12` | Current sense fault. |
| `0x25` | Torque sensor fault. |

### Read Current

Request:

```text
11 0A
```

Response:

```text
XX CC
```

`XX` is battery current in amps times 2. `CC` is the checksum and equals `XX`.

### Read Battery

Request:

```text
11 11
```

Response:

```text
XX CC
```

`XX` is the firmware battery percentage after optional display-specific mapping. `CC` equals `XX`.

### Read Speed

Request:

```text
11 20
```

Response:

```text
HH LL CC
```

Normally this returns road speed based on the speed sensor.

If walk assist is active and `Walk Mode Data Display` is not set to speed, the firmware uses this response to show the configured walk-mode debug value in the display speed field.

### Read Range

Request:

```text
11 22
```

Response:

```text
HH LL CC
```

The firmware does not calculate range. The range field is repurposed. See [Display Behavior](Display-Behavior.md).

### Read Calories

Request:

```text
11 24
```

Response:

```text
HH LL CC
```

The firmware sends battery voltage x10 in this field. See [Display Behavior](Display-Behavior.md).

### Read Moving

Request:

```text
11 31
```

Response:

```text
XX XX
```

Returns `0x31` when the speed sensor reports movement and `0x30` when not moving.

## Write Requests

### Write PAS Level

Opcode:

```text
16 0B
```

The display PAS-level values are mapped to firmware assist levels 0 through 9 and push/walk assist.

### Write Work Mode

Opcode:

```text
16 0C
```

Upstream behavior mapped display ECO/Sport values to firmware operation modes. In this fork, the packet is checksum-validated and consumed, but the requested mode is ignored. This prevents displays such as the 860C from continuously forcing ECO or Sport mode.

### Write Lights

Opcode:

```text
16 1A
```

The display lights command either controls external lights or toggles operation mode, depending on configuration. See [Configuration Tool](Configuration-Tool.md) and [Display Behavior](Display-Behavior.md).

### Write Speed Limit

Opcode:

```text
16 1F
```

The firmware consumes this message but ignores the display-requested speed limit. Configure speed limits in the BBS-FW configuration tool instead.
