using BBSFW.Properties;
using System;
using System.Windows;
using System.Windows.Media;

namespace BBSFW
{
	public static class ThemeManager
	{
		public static event EventHandler ThemeChanged;

		public static bool IsDarkTheme { get; private set; }

		public static void Initialize()
		{
			ApplyTheme(Settings.Default.UseDarkTheme, false);
		}

		public static void ToggleTheme()
		{
			ApplyTheme(!IsDarkTheme, true);
		}

		private static void ApplyTheme(bool useDarkTheme, bool save)
		{
			IsDarkTheme = useDarkTheme;

			if (useDarkTheme)
			{
				ApplyDarkTheme();
			}
			else
			{
				ApplyLightTheme();
			}

			if (save)
			{
				Settings.Default.UseDarkTheme = useDarkTheme;
				Settings.Default.Save();
			}

			ThemeChanged?.Invoke(null, EventArgs.Empty);
		}

		private static void ApplyLightTheme()
		{
			SetBrush("AppBackgroundBrush", "#F7F5FB");
			SetBrush("SurfaceBrush", "#FFFFFF");
			SetBrush("SurfaceAltBrush", "#EEEAF7");
			SetBrush("SurfaceElevatedBrush", "#FCFAFF");
			SetBrush("InputBrush", "#FFFFFF");
			SetBrush("TextBrush", "#1C1724");
			SetBrush("MutedTextBrush", "#6F667A");
			SetBrush("BorderBrush", "#D9D1E6");
			SetBrush("AccentBrush", "#7652E7");
			SetBrush("AccentHoverBrush", "#6541D2");
			SetBrush("AccentSoftBrush", "#ECE6FF");
			SetBrush("AccentStrongBrush", "#4E2DBD");
			SetBrush("LogoTextBrush", "#3C238F");
			SetBrush("HeaderTextBrush", "#FFFFFF");
			SetBrush("HeaderMutedTextBrush", "#EFE7FF");
			SetBrush("HeaderStrokeBrush", "#B79BFF");
			SetBrush("HeaderPillBrush", "#2D2545");
			SetBrush("NavBackgroundBrush", "#FFFFFF");
			SetBrush("NavSelectionBrush", "#EFE8FF");
			SetBrush("SuccessSoftBrush", "#DCFCE7");
			SetBrush("WarningSoftBrush", "#FFF1C7");
			SetBrush("ErrorSoftBrush", "#FFE1E1");
			SetBrush("DataGridAlternateBrush", "#FAF8FD");
			SetSystemBrushes("#ECE6FF", "#1C1724", "#FFFFFF", "#1C1724");

			SetGradient("HeaderGradientBrush", "#1E1735", "#5B35D5", "#B86FEA");
			SetGradient("LogoGradientBrush", "#FFFFFF", "#E8DEFF");
			SetGradient("SplashGradientBrush", "#1E1735", "#5B35D5", "#B86FEA");
		}

		private static void ApplyDarkTheme()
		{
			SetBrush("AppBackgroundBrush", "#111018");
			SetBrush("SurfaceBrush", "#191722");
			SetBrush("SurfaceAltBrush", "#252132");
			SetBrush("SurfaceElevatedBrush", "#211D2B");
			SetBrush("InputBrush", "#12101A");
			SetBrush("TextBrush", "#F4F0FF");
			SetBrush("MutedTextBrush", "#B2A8C6");
			SetBrush("BorderBrush", "#3E3852");
			SetBrush("AccentBrush", "#C59BFF");
			SetBrush("AccentHoverBrush", "#D5B6FF");
			SetBrush("AccentSoftBrush", "#34284A");
			SetBrush("AccentStrongBrush", "#E6D6FF");
			SetBrush("LogoTextBrush", "#281247");
			SetBrush("HeaderTextBrush", "#FFFFFF");
			SetBrush("HeaderMutedTextBrush", "#DED2F5");
			SetBrush("HeaderStrokeBrush", "#6D5A93");
			SetBrush("HeaderPillBrush", "#261F38");
			SetBrush("NavBackgroundBrush", "#15131D");
			SetBrush("NavSelectionBrush", "#332746");
			SetBrush("SuccessSoftBrush", "#163325");
			SetBrush("WarningSoftBrush", "#3A3118");
			SetBrush("ErrorSoftBrush", "#3A1D28");
			SetBrush("DataGridAlternateBrush", "#14121C");
			SetSystemBrushes("#34284A", "#F4F0FF", "#191722", "#F4F0FF");

			SetGradient("HeaderGradientBrush", "#171322", "#3A2C62", "#7B4DCD");
			SetGradient("LogoGradientBrush", "#FFFFFF", "#DCC9FF");
			SetGradient("SplashGradientBrush", "#171322", "#3A2C62", "#7B4DCD");
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

		private static Color ToColor(string color)
		{
			return (Color)ColorConverter.ConvertFromString(color);
		}
	}
}
