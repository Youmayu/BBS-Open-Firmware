# Upgrade Firmware Version

Use this procedure when upgrading BBS-FW from one firmware version to another.

1. Download or build the new firmware and matching configuration tool.
2. Connect your controller to the computer using the programming cable.
3. Start the configuration tool for the new firmware version.
4. Connect to the controller.
5. Read the current configuration from flash with `Menu -> Flash -> Read`.
6. Save the current configuration to a file with `Menu -> File -> Save As`.
7. Disconnect from the controller in the configuration tool, but leave the tool open.
8. Flash the new firmware using [Flash Firmware](Flash-Firmware.md).
9. Connect to the controller again with the configuration tool.
10. Write the saved configuration back with `Menu -> Flash -> Write`.

If writing fails, correct the reported configuration errors and try again.
