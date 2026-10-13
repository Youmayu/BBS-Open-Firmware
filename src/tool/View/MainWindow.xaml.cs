using System;
using System.Windows;

namespace BBSFW
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			UpdateThemeControls();
			UpdateLanguageControls();
			ThemeManager.ThemeChanged += OnThemeChanged;
			LanguageManager.LanguageChanged += OnLanguageChanged;
		}

		protected override void OnClosed(EventArgs e)
		{
			ThemeManager.ThemeChanged -= OnThemeChanged;
			LanguageManager.LanguageChanged -= OnLanguageChanged;
			base.OnClosed(e);
		}

		private void ToggleTheme_Click(object sender, RoutedEventArgs e)
		{
			ThemeManager.ToggleTheme();
		}

		private void OnThemeChanged(object sender, EventArgs e)
		{
			UpdateThemeControls();
		}

		private void OnLanguageChanged(object sender, EventArgs e)
		{
			UpdateThemeControls();
			UpdateLanguageControls();
		}

		private void EnglishMenuItem_Click(object sender, RoutedEventArgs e)
		{
			LanguageManager.SetLanguage(AppLanguage.English);
		}

		private void ChineseMenuItem_Click(object sender, RoutedEventArgs e)
		{
			LanguageManager.SetLanguage(AppLanguage.Chinese);
		}

		private void NorwegianMenuItem_Click(object sender, RoutedEventArgs e)
		{
			LanguageManager.SetLanguage(AppLanguage.Norwegian);
		}

		private void UpdateThemeControls()
		{
			var useDarkTheme = ThemeManager.IsDarkTheme;

			ThemeToggleButton.Content = useDarkTheme ? LanguageManager.Get("Theme.LightMode") : LanguageManager.Get("Theme.DarkMode");
			DarkModeMenuItem.IsChecked = useDarkTheme;
			ThemeStatusText.Text = useDarkTheme ? LanguageManager.Get("Theme.DarkStatus") : LanguageManager.Get("Theme.LightStatus");
		}

		private void UpdateLanguageControls()
		{
			EnglishMenuItem.IsChecked = LanguageManager.CurrentLanguage == AppLanguage.English;
			ChineseMenuItem.IsChecked = LanguageManager.CurrentLanguage == AppLanguage.Chinese;
			NorwegianMenuItem.IsChecked = LanguageManager.CurrentLanguage == AppLanguage.Norwegian;
		}
	}
}
