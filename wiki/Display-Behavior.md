# Display Behavior

This firmware is intended to work with displays that use the Bafang display protocol. Some display fields are repurposed because the standard Bafang protocol does not provide dedicated fields for every firmware value.

## Display Selection

The configuration tool includes display-specific selections:

- `Other displays`: standard Bafang display work-mode handling.
- `P850C`: standard Bafang display work-mode handling.
- `860C`: ignores display work-mode requests so the controller controls ECO/Sport mode.

P850C uses the same firmware behavior as `Other displays`. Only 860C enables special work-mode handling.

## 860C Work Mode

Some 860C displays continuously send their configured work mode, such as ECO or Sport. That can override a controller-side operation-mode selection, for example PAS 0 plus the lights button.

In this fork, the firmware validates and consumes the display work-mode packet but does not apply the requested ECO/Sport mode. Operation mode is controlled by the firmware configuration instead.

## Range Field

The display range field is not used for range estimation.

By default, the current firmware uses the range field for temperature on BBSHD and BBS02 because those targets have at least one temperature sensor.

Behavior from `fwconfig.h`:

- `DISPLAY_RANGE_FIELD_TEMPERATURE`: show the maximum of controller temperature and motor temperature.
- `DISPLAY_RANGE_FIELD_POWER`: show requested current with lights off and actual battery current with lights on.
- `DISPLAY_RANGE_FIELD_ZERO`: show zero.

The default is:

- BBSHD: temperature, maximum of controller and motor temperature.
- BBS02/BBS02B: temperature, controller temperature only.

The range-field option is a compile-time firmware option. It is not exposed in the configuration tool.

## Calories Field

The display calories field is repurposed to show battery voltage.

The firmware sends battery voltage x10 in response to the display calories request. If a display shows a calories page or calories value, it may actually be showing battery voltage data from this firmware.

## Walk Mode Data Display

The configuration tool can change what appears in the display speed field while walk assist is active.

Options:

- `Speed`: show normal road speed.
- `Temperature (C)`: show the maximum of controller and motor temperature in Celsius.
- `Requested Power (%)`: show firmware target current percentage.
- `Battery Level (%)`: show firmware-computed battery level percentage.

Temperature is kept in Celsius for the walk-mode speed-field display even if the display uses imperial units, because the speed field is limited.

## Display Speed Limit

The firmware ignores the display's speed-limit write command. Use the firmware configuration tool to set the global max speed and assist-level speed percentages.

## Lights Button and Operation Mode

The lights button can be used as an operation-mode toggle depending on the `Operation Mode Toggle` configuration.

Available options include:

- `Lights Button`: lights button toggles operation mode.
- `PAS 0 + Lights Button` through `PAS 9 + Lights Button`: lights button toggles operation mode only at the selected PAS level.

If the operation-mode toggle does not match the current assist level, the lights button controls external lights according to `Lights Mode`.

Disable automatic display lights if you use a lights-button operation-mode toggle. Otherwise the display can switch operation mode automatically.

## Temperature Sensor Differences

BBSHD has a controller temperature sensor and a motor temperature sensor. Temperature display uses the higher of the two.

BBS02/BBS02B has a controller temperature sensor in this firmware. It does not report a separate motor temperature.
