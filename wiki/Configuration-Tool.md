# Configuration Tool

Use the BBS-FW configuration tool instead of the standard Bafang configuration tool. The firmware uses a different set of supported parameters.

## Connect

1. Power off the controller.
2. Connect the controller to the computer using the Bafang programming cable.
3. Select the COM port for the controller in the list on the left.
4. Click `Connect`.
5. Power on the controller.

If the connection works, the tool should show `Connected: Yes` and report the current firmware version.

Useful menu actions:

- Read configuration from flash: `Menu -> Flash -> Read`.
- Write configuration to flash: `Menu -> Flash -> Write`.
- Reset configuration in flash to defaults: `Menu -> Flash -> Reset`.
- Save configuration to a file: `Menu -> File -> Save As`.
- Load configuration from a file: `Menu -> File -> Open`.

## System Parameters

### Global

**Max Current (A)**

Maximum current to draw from the battery. The current limit is also constrained by the controller hardware and the secondary motor-control MCU.

Current defaults in this repo:

- BBSHD: `30 A`.
- BBS02: `25 A`.
- TSDZ2: `20 A`.

Be careful with high current on BBS02. The upstream wiki warns that high current on BBS02 can trigger hard overcurrent protection or damage the motor.

**Current Ramp (A/s)**

Current ramp-up in amps per second when engaging PAS or cruise. Lower values give slower acceleration. This does not apply to throttle in the same way.

Default in the current code: `10`.

**Max Battery Voltage (V)**

Maximum battery voltage used for battery state-of-charge calculation.

Default: `54.6`.

**Low Voltage Cutoff (V)**

Low-voltage detection threshold used to protect the battery.

Default: `42`.

**Max Speed**

Maximum road speed if the speed sensor is enabled. Units can be changed from the tool's unit options. The display's own max-speed setting is ignored by the firmware.

Default: `100 km/h`.

### Features

**Speed Sensor**

Disable this if you do not use the speed sensor. If disabled, configured max speed has no effect. If the speed sensor malfunctions, the motor can still work even when this option is enabled.

Default: enabled.

**Shift Sensor**

Supported on BBSHD and BBS02. When enabled, the firmware can reduce or cut motor current while shifting.

**Walk Mode**

Enables display walk assist. Using walk mode without a speed sensor is not ideal. If walk mode is disabled in configuration but activated from the display, the previously selected assist level continues to be used.

Default: enabled.

**Temperature Sensor**

Select which temperature sensors are used for thermal limiting. BBSHD has controller and motor temperature sensors. BBS02 has a controller temperature sensor only.

Normally this should be set to `All`. If a sensor is broken, disable that sensor so the controller can still be used.

Default: all available sensors.

**Lights Mode**

Controls external light output:

- `Default`: controlled by the display.
- `Disabled`: light output disabled.
- `Always On`: light output always on.
- `Brake Light`: light output enabled while braking.

**Pretension Chain**

Applies 1% of max current above a configured road speed to pretension the drivetrain. This can make aggressive PAS or throttle settings feel smoother by reducing drivetrain slack before power engagement.

This requires the speed sensor.

### Throttle

**Start Voltage (mV)**

Throttle signal voltage where throttle output begins. Setting this below the throttle's real minimum signal can cause a throttle error.

Default in the current code: `1000`.

**End Voltage (mV)**

Throttle signal voltage where maximum throttle output is reached. Setting this above the throttle's real maximum signal can make it impossible to reach full power.

Default: `3600`.

**Start Current (%)**

Minimum current applied at the lowest valid throttle input. For example, `10%` maps the throttle range to `10-100%` output.

Default: `1`.

**Global Speed Limit Options**

Controls a separate throttle-only speed limit for legal compliance:

- `Disabled`: no global throttle speed limit.
- `Enabled`: global throttle speed limit applies to all assist levels while using throttle and not pedaling.
- `Standard Levels`: global throttle speed limit applies to standard assist levels only.

Throttle must still be enabled on each assist level.

**Global Speed Limit (%)**

Speed limit as a percentage of configured max speed when global throttle speed limiting is enabled.

Default: `100`.

### Pedal Assist

**Start Delay**

Pedal rotation delay before PAS engages. The tool shows this in degrees.

Default: `75 degrees`.

**Stop Delay (ms)**

Delay before PAS disengages after pedaling stops.

Default: `200`.

**Keep Current (%)**

Motor current percentage to keep after cadence reaches the keep-current cadence threshold. This affects cadence-based PAS. It does not affect torque-based PAS.

Default: `60`.

**Keep Current Cadence (rpm)**

Cadence threshold where the keep-current ramp starts. Above this cadence, current decreases toward the configured keep-current percentage.

Default: `40`.

### Speed Sensor

**Wheel Size**

Wheel size in inches for speed calculations. If you use a display, set this to match the display wheel-size setting.

Default: `28`.

**Signals**

Number of speed sensor signals per wheel rotation. Set this to the number of evenly spaced magnets on the wheel.

Default: `1`.

### Shift Sensor

**Shift Interrupt Duration (ms)**

Duration of the power interrupt when the shift sensor triggers.

Default: `600`.

**Shift Current Threshold (%)**

Maximum motor current during a shift, as a percentage of `Max Current (A)`. If current is already below this threshold, no power cut happens. If current is above this threshold, it is reduced to this threshold during the shift.

Default: `10`.

### Miscellaneous

**Walk Mode Data Display**

Overrides what is shown in the display speed field while walk assist is engaged:

- `Speed`: normal road speed.
- `Temperature (C)`: maximum of motor/controller temperature in Celsius.
- `Requested Power (%)`: firmware target current percentage.
- `Battery Level (%)`: firmware-computed battery level percentage.

Default: `Speed`.

See [Display Behavior](Display-Behavior.md) for more display-field behavior that is not shown in the configuration tool.

## Assist Levels

The firmware supports two assist-level pages: `Standard` and `Sport`. You can configure each page separately in the tool.

The controller starts in standard operation mode when powered on unless a configured startup toggle condition selects sport mode.

### Assist Level Types

**Motor Disabled**

Disables motor power for that assist level.

**PAS**

Pedal assist. Variants:

- `Cadence`: cadence-based pedal assist.
- `Torque`: torque-based pedal assist, only available on controllers with a torque sensor such as TSDZ2.
- `Variable`: pedal assist mode where the throttle controls assist power, but only while pedaling.

**Throttle**

Throttle-only assist level. PAS is disabled for that level.

**Cruise**

Cruise allows motor power after a deliberate engagement sequence even when neither throttle nor PAS is active.

Use cruise with caution. A throttle is required to engage cruise mode.

To engage cruise:

1. Switch to a cruise assist level.
2. Apply more than 50% throttle.
3. Pedal forward until motor power engages.
4. Release throttle and stop pedaling if desired.

To disengage cruise, pedal backward, touch the throttle, or brake if brake sensors are installed.

### Assist Level Parameters

**Max Current (%)**

Target current percentage for the assist level. For variable PAS, this is the maximum current at full throttle.

**Max Cadence (%)**

Cadence limit as a percentage of maximum cadence. This was called `speed` in the original Bafang firmware.

Approximate maximum cadence:

- BBSHD: about 168 rpm in the current code.
- BBS02: about 150 rpm in the current code.

**Max Speed (%)**

Road-speed limit as a percentage of configured global max speed.

Example: if global max speed is `100 km/h` and assist-level max speed is `25%`, the assist-level speed limit is `25 km/h`.

**Torque Amplification**

Only for torque PAS on controllers with torque sensors. This is the power amplification factor for the assist level.

Example: 100 W human input with a torque amplification factor of 2 targets about 200 W motor output.

**Enable Throttle**

Allows throttle use in this assist level.

**Throttle Overrides: Cadence**

Overrides the assist-level cadence limit to 100% when throttle-requested power exceeds PAS-requested power.

**Throttle Overrides: Speed**

Overrides the assist-level speed limit to the configured global speed limit when throttle-requested power exceeds PAS-requested power.

**Max Throttle Current (%)**

Maximum current percentage when full throttle is applied in this assist level.

### Operation Mode Toggle

Controls how the controller switches between the `Standard` and `Sport` assist pages.

Current tool/code options:

- `Off`: do not toggle; use standard mode.
- `Sport Button`: use a display sport-mode command if supported by the display.
- `Lights Button`: use the display lights button as the operation-mode toggle.
- `Brakes @ Power On`: start in sport mode when the brake is held during power-on.
- `PAS 0 + Lights Button` through `PAS 9 + Lights Button`: use the lights button as the mode toggle only when the selected PAS level matches the configured PAS level. Otherwise, the lights button controls external lights.

If your display has an automatic light sensor, disable it in display settings before using a lights-button operation-mode toggle. Otherwise the display may switch operation modes automatically.

In this fork, display work-mode writes are ignored so displays such as the 860C cannot continuously force ECO or Sport mode.

**Startup Assist Level**

Assist level used from the standard operation page when no display is connected.

Default: `3`.

This is useful as a limp-home mode if the display fails while riding.

## Event Log

The event log is useful for troubleshooting and initialization diagnostics.

To capture the full controller initialization log:

1. Power off the controller.
2. Connect the configuration tool.
3. Power on the controller.
