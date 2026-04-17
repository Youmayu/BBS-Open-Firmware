# BBSHD Controller PCB

## Hardware Revisions

| Revision | MCU          | Released | Comment |
| -------- | ------------ | -------- | ------- |
| V1.4     | STC15W4K56S4 | ~2017    | V1.3 printed on PCB, sticker with 1.4. |
| V1.5     | IAP15W4K61S4 | ~2019    | V1.4 printed on PCB, sticker with 1.5. |

The PCB revisions appear to be pin-compatible for the supported MCU variants.

## STC Microcontroller

Runs at 5.0 V.

| Pin  | Type  | Function               | Comment |
| ---- | ----- | ---------------------- | ------- |
| P0.6 | IN    | Hall W                 | Hall effect sensor signal W. |
| P1.0 | UART2 | RX                     | UART RX line for communication with NEC MCU. |
| P1.1 | UART2 | TX                     | UART TX line for communication with NEC MCU. |
| P1.3 | ADC3  | Throttle input         | 0-5 V, 9K external pulldown. |
| P1.6 | ADC6  | Battery voltage        | Battery voltage reading. |
| P1.7 | ADC7  | Controller temperature | Controller temperature reading. |
| P2.0 | OUT   | Motor power enable     | Signal to NEC MCU to enable motor power. |
| P2.1 | OUT   | Motor control enable   | Signal to NEC MCU to enable motor control; should be kept high. |
| P2.2 | IN    | Speed sensor           | 5 V speed sensor signal. |
| P2.3 | OUT   | External lights        | Controls external lights, active low. |
| P2.4 | IN    | Brake                  | 5 V, active low. Also connected directly to NEC MCU. |
| P2.6 | IN    | Gear sensor            | 5 V, active low. |
| P3.0 | UART1 | RX                     | 5 V external UART RX line for display communication. |
| P3.1 | UART1 | TX                     | 5 V external UART TX line for display communication. |
| P3.4 | IN    | Hall V                 | Hall effect sensor signal V. |
| P4.4 | OUT   | Motor control enable   | Signal to NEC MCU to enable motor control; should be kept high. |
| P4.5 | IN    | PAS 1                  | Pedal assist sensor signal 1. |
| P4.6 | IN    | PAS 2                  | Pedal assist sensor signal 2. |
| P5.0 | IN    | Hall U                 | Hall effect sensor signal U. |
| P5.1 | OUT   | External lights enable | Controls the transistor applying power to the external lights PCB. |

## NEC Microcontroller

Runs at 5.0 V.

| Pin  | Type | Function               | Comment |
| ---- | ---- | ---------------------- | ------- |
| P22  | IN   | Motor control enable   | Signal from STC MCU to enable motor control; should be kept high. |
| P23  | IN   | Motor control enable   | Signal from STC MCU to enable motor control; should be kept high. |
| P25  | ADC  | Current sense          | Via shunt resistors and LM358 op amp. |
| P70  | OUT  | Status LED             | Blinks during normal operation. |
| P73  | UART | TX                     | Connected to RX UART2 on STC P1.0. |
| P74  | UART | RX                     | Connected to TX UART2 on STC P1.1. |
| P120 | IN   | Hall U                 | Hall effect sensor signal U. |
| P121 | IN   | Hall W                 | Hall effect sensor signal W. |
| P122 | IN   | Hall V                 | Hall effect sensor signal V. |
| P150 | IN   | Motor power enable     | Signal from STC MCU to enable motor power. |
| P151 | IN   | Battery voltage        | Also connected to STC MCU. |

The upstream wiki includes annotated PCB photos in its wiki repository. Those images are not copied into this local wiki folder.
