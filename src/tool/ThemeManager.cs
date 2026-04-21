using BBSFW.Properties;
using System;
using System.Windows;
using System.Windows.Media;

namespace BBSFW
{
	public static class ThemeManager
	{
		public enum AccentTheme
		{
			Purple,
			Blue,
			Red,
			Teal
		}

		public static event EventHandler ThemeChanged;

		public static bool IsDarkTheme { get; private set; }

		public static AccentTheme CurrentAccentTheme { get; private set; }

		public static void Initialize()
		{
			ApplyTheme(Settings.Default.UseDarkTheme, ParseAccentTheme(Settings.Default.AccentTheme), false);
		}

		public static void ToggleTheme()
		{
			ApplyTheme(!IsDarkTheme, CurrentAccentTheme, true);
		}

		public static void SetAccentTheme(AccentTheme accentTheme)
		{
			ApplyTheme(IsDarkTheme, accentTheme, true);
		}

		private static void ApplyTheme(bool useDarkTheme, AccentTheme accentTheme, bool save)
		{
			IsDarkTheme = useDarkTheme;
			CurrentAccentTheme = accentTheme;

			ApplyBaseTheme(useDarkTheme);
			ApplyAccentTheme(useDarkTheme, accentTheme);

			if (save)
			{
				Settings.Default.UseDarkTheme = useDarkTheme;
				Settings.Default.AccentTheme = ToSetting(accentTheme);
				Settings.Default.Save();
			}

			ThemeChanged?.Invoke(null, EventArgs.Empty);
		}

		private static void ApplyBaseTheme(bool darkTheme)
		{
			if (darkTheme)
			{
				SetBrush("AppBackgroundBrush", "#111018");
				SetBrush("SurfaceBrush", "#171620");
				SetBrush("SurfaceAltBrush", "#201E2C");
				SetBrush("SurfaceElevatedBrush", "#1A1825");
				SetBrush("InputBrush", "#101018");
				SetBrush("TextBrush", "#F3F0FF");
				SetBrush("MutedTextBrush", "#B8B1C8");
				SetBrush("BorderBrush", "#3B3750");
				SetBrush("SuccessSoftBrush", "#183325");
				SetBrush("WarningSoftBrush", "#3B3117");
				SetBrush("ErrorSoftBrush", "#3F1D29");
				SetBrush("DataGridAlternateBrush", "#15131D");
				return;
			}

			SetBrush("AppBackgroundBrush", "#F6F3FB");
			SetBrush("SurfaceBrush", "#FFFFFF");
			SetBrush("SurfaceAltBrush", "#F0ECFA");
			SetBrush("SurfaceElevatedBrush", "#FCFBFF");
			SetBrush("InputBrush", "#FFFFFF");
			SetBrush("TextBrush", "#181421");
			SetBrush("MutedTextBrush", "#5F5870");
			SetBrush("BorderBrush", "#D9D1EA");
			SetBrush("SuccessSoftBrush", "#DCFCE7");
			SetBrush("WarningSoftBrush", "#FFF1C7");
			SetBrush("ErrorSoftBrush", "#FFE1E1");
			SetBrush("DataGridAlternateBrush", "#FAF8FD");
		}

		private static void ApplyAccentTheme(bool darkTheme, AccentTheme accentTheme)
		{
			switch (accentTheme)
			{
				case AccentTheme.Blue:
					ApplyBlueTheme(darkTheme);
					break;
				case AccentTheme.Red:
					ApplyRedTheme(darkTheme);
					break;
				case AccentTheme.Teal:
					ApplyTealTheme(darkTheme);
					break;
				default:
					ApplyPurpleTheme(darkTheme);
					break;
			}
		}

		private static void ApplyPurpleTheme(bool darkTheme)
		{
			if (darkTheme)
			{
				SetAccentPalette(
					accent: "#C4B5FD",
					hover: "#DDD6FE",
					soft: "#31254D",
					strong: "#F0EBFF",
					logoText: "#2C1B5C",
					headerText: "#FFFFFF",
					headerMuted: "#E7DFFF",
					headerStroke: "#6D5A93",
					headerPill: "#261F38",
					navSelection: "#31254D",
					headerStart: "#171322",
					headerMid: "#3A2C62",
					headerEnd: "#7B4DCD",
					logoEnd: "#DCC9FF");
				return;
			}

			SetAccentPalette(
				accent: "#6D4CDB",
				hover: "#5B3CC8",
				soft: "#ECE6FF",
				strong: "#4B30B2",
				logoText: "#472D95",
				headerText: "#FFFFFF",
				headerMuted: "#EEE8FF",
				headerStroke: "#A78BFA",
				headerPill: "#2A2341",
				navSelection: "#ECE6FF",
				headerStart: "#17132C",
				headerMid: "#5331C6",
				headerEnd: "#8E4BE8",
				logoEnd: "#EEE6FF");
		}

		private static void ApplyBlueTheme(bool darkTheme)
		{
			if (darkTheme)
			{
				SetAccentPalette(
					accent: "#93C5FD",
					hover: "#BFDBFE",
					soft: "#1E3A5F",
					strong: "#DBEAFE",
					logoText: "#1E3A8A",
					headerText: "#FFFFFF",
					headerMuted: "#DBEAFE",
					headerStroke: "#3B82F6",
					headerPill: "#172554",
					navSelection: "#1E3A5F",
					headerStart: "#0F172A",
					headerMid: "#1D4ED8",
					headerEnd: "#0EA5E9",
					logoEnd: "#DBEAFE");
				return;
			}

			SetAccentPalette(
				accent: "#2563EB",
				hover: "#1D4ED8",
				soft: "#E0ECFF",
				strong: "#1E40AF",
				logoText: "#1D4ED8",
				headerText: "#FFFFFF",
				headerMuted: "#DBEAFE",
				headerStroke: "#60A5FA",
				headerPill: "#1E3A8A",
				navSelection: "#E0ECFF",
				headerStart: "#0F172A",
				headerMid: "#1D4ED8",
				headerEnd: "#38BDF8",
				logoEnd: "#E0ECFF");
		}

		private static void ApplyRedTheme(bool darkTheme)
		{
			if (darkTheme)
			{
				SetAccentPalette(
					accent: "#FDA4AF",
					hover: "#FECDD3",
					soft: "#4A1E28",
					strong: "#FFE4E6",
					logoText: "#881337",
					headerText: "#FFFFFF",
					headerMuted: "#FFE4E6",
					headerStroke: "#FB7185",
					headerPill: "#4A1D28",
					navSelection: "#4A1E28",
					headerStart: "#2A0F16",
					headerMid: "#BE123C",
					headerEnd: "#DC2626",
					logoEnd: "#FFE4E6");
				return;
			}

			SetAccentPalette(
				accent: "#DC2626",
				hover: "#B91C1C",
				soft: "#FDE8E8",
				strong: "#991B1B",
				logoText: "#991B1B",
				headerText: "#FFFFFF",
				headerMuted: "#FEE2E2",
				headerStroke: "#F87171",
				headerPill: "#7F1D1D",
				navSelection: "#FDE8E8",
				headerStart: "#331316",
				headerMid: "#B91C1C",
				headerEnd: "#E11D48",
				logoEnd: "#FDE8E8");
		}

		private static void ApplyTealTheme(bool darkTheme)
		{
			if (darkTheme)
			{
				SetAccentPalette(
					accent: "#5EEAD4",
					hover: "#99F6E4",
					soft: "#133C3A",
					strong: "#C5FFF7",
					logoText: "#0B4F49",
					headerText: "#FFFFFF",
					headerMuted: "#CBEDE8",
					headerStroke: "#1D7C73",
					headerPill: "#132A2B",
					navSelection: "#163E3C",
					headerStart: "#0F1720",
					headerMid: "#0E4D53",
					headerEnd: "#0F766E",
					logoEnd: "#D9F7F1");
				return;
			}

			SetAccentPalette(
				accent: "#0F766E",
				hover: "#0C625C",
				soft: "#E2F4F1",
				strong: "#0B4F49",
				logoText: "#0B4F49",
				headerText: "#FFFFFF",
				headerMuted: "#D8F3EF",
				headerStroke: "#2A9388",
				headerPill: "#183331",
				navSelection: "#E2F4F1",
				headerStart: "#111827",
				headerMid: "#0F5C63",
				headerEnd: "#0F766E",
				logoEnd: "#E2F4F1");
		}

		private static void SetAccentPalette(
			string accent,
			string hover,
			string soft,
			string strong,
			string logoText,
			string headerText,
			string headerMuted,
			string headerStroke,
			string headerPill,
			string navSelection,
			string headerStart,
			string headerMid,
			string headerEnd,
			string logoEnd)
		{
			SetBrush("AccentBrush", accent);
			SetBrush("AccentHoverBrush", hover);
			SetBrush("AccentSoftBrush", soft);
			SetBrush("AccentStrongBrush", strong);
			SetBrush("LogoTextBrush", logoText);
			SetBrush("HeaderTextBrush", headerText);
			SetBrush("HeaderMutedTextBrush", headerMuted);
			SetBrush("HeaderStrokeBrush", headerStroke);
			SetBrush("HeaderPillBrush", headerPill);
			if (Application.Current.Resources["SurfaceBrush"] is SolidColorBrush navBackground)
			{
				Application.Current.Resources["NavBackgroundBrush"] = new SolidColorBrush(navBackground.Color);
			}

			SetBrush("NavSelectionBrush", navSelection);
			SetSystemBrushes(
				soft,
				Application.Current.Resources["TextBrush"] is SolidColorBrush text ? text.Color.ToString() : "#181421",
				Application.Current.Resources["SurfaceBrush"] is SolidColorBrush menuBackground ? menuBackground.Color.ToString() : "#FFFFFF",
				Application.Current.Resources["TextBrush"] is SolidColorBrush menuText ? menuText.Color.ToString() : "#181421");

			SetGradient("HeaderGradientBrush", headerStart, headerMid, headerEnd);
			SetGradient("LogoGradientBrush", "#FFFFFF", logoEnd);
			SetGradient("SplashGradientBrush", headerStart, headerMid, headerEnd);
		}

		private static void SetBrush(string key, string color)
		{
			Application.Current.Resources[key] = new SolidColorBrush(ToColor(color));
		}

		private static void SetBrush(object key, string color)
		{
			Application.Current.Resources[key] = new SolidColorBrush(ToColor(color));
		}

		private static void SetSystemBrushes(string highlight, string highlightText, string menu, string menuText)
		{
			SetBrush(SystemColors.HighlightBrushKey, highlight);
			SetBrush(SystemColors.HighlightTextBrushKey, highlightText);
			SetBrush(SystemColors.ControlBrushKey, highlight);
			SetBrush(SystemColors.MenuBrushKey, menu);
			SetBrush(SystemColors.MenuTextBrushKey, menuText);
		}

		private static void SetGradient(string key, params string[] colors)
		{
			if (colors.Length == 2)
			{
				Application.Current.Resources[key] = new LinearGradientBrush(
					ToColor(colors[0]),
					ToColor(colors[1]),
					new Point(0, 0),
					new Point(1, 1));
				return;
			}

			if (colors.Length == 3)
			{
				Application.Current.Resources[key] = new LinearGradientBrush
				{
					StartPoint = new Point(0, 0),
					EndPoint = new Point(1, 1),
					GradientStops =
					{
						new GradientStop(ToColor(colors[0]), 0),
						new GradientStop(ToColor(colors[1]), 0.6),
						new GradientStop(ToColor(colors[2]), 1)
					}
				};
			}
		}

		private static AccentTheme ParseAccentTheme(string value)
		{
			return value?.ToLowerInvariant() switch
			{
				"blue" => AccentTheme.Blue,
				"red" => AccentTheme.Red,
				"teal" => AccentTheme.Teal,
				_ => AccentTheme.Purple
			};
		}

		private static string ToSetting(AccentTheme accentTheme)
		{
			return accentTheme switch
			{
				AccentTheme.Blue => "blue",
				AccentTheme.Red => "red",
				AccentTheme.Teal => "teal",
				_ => "purple"
			};
		}

		private static Color ToColor(string color)
		{
			return (Color)ColorConverter.ConvertFromString(color);
		}
	}
}
