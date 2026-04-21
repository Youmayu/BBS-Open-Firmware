using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using BBSFW.ViewModel;

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
			MainTabs.SelectionChanged += MainTabs_SelectionChanged;
			ThemeManager.ThemeChanged += OnThemeChanged;
			LanguageManager.LanguageChanged += OnLanguageChanged;
		}

		protected override void OnClosed(EventArgs e)
		{
			ThemeManager.ThemeChanged -= OnThemeChanged;
			LanguageManager.LanguageChanged -= OnLanguageChanged;
			MainTabs.SelectionChanged -= MainTabs_SelectionChanged;
			base.OnClosed(e);
		}

		private void MainTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (!ReferenceEquals(e.Source, MainTabs) || MainTabs.SelectedContent is not FrameworkElement content)
			{
				return;
			}

			var motion = new TranslateTransform(0, 18);
			content.RenderTransform = motion;
			content.Opacity = 0;

			var ease = new CubicEase { EasingMode = EasingMode.EaseOut };
			content.BeginAnimation(
				OpacityProperty,
				new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(240)) { EasingFunction = ease });
			motion.BeginAnimation(
				TranslateTransform.YProperty,
				new DoubleAnimation(18, 0, TimeSpan.FromMilliseconds(280)) { EasingFunction = ease });
		}

		private void UseEasyMode_Click(object sender, RoutedEventArgs e)
		{
			if (DataContext is MainViewModel vm)
			{
				vm.IsEasyMode = true;
				EasySetupTab.IsSelected = true;
			}
		}

		private void UseProMode_Click(object sender, RoutedEventArgs e)
		{
			if (DataContext is MainViewModel vm)
			{
				vm.IsProMode = true;
				SystemTab.IsSelected = true;
			}
		}

		public void NavigateToConnection()
		{
			ConnectionTab.IsSelected = true;
		}

		public void NavigateToEasySetup()
		{
			if (DataContext is MainViewModel vm)
			{
				vm.IsEasyMode = true;
			}

			EasySetupTab.IsSelected = true;
		}

		public void NavigateToProSetup()
		{
			if (DataContext is MainViewModel vm)
			{
				vm.IsProMode = true;
			}

			SystemTab.IsSelected = true;
		}

		private void ToggleTheme_Click(object sender, RoutedEventArgs e)
		{
			ThemeManager.ToggleTheme();
		}

		private void PurpleThemeMenuItem_Click(object sender, RoutedEventArgs e)
		{
			ThemeManager.SetAccentTheme(ThemeManager.AccentTheme.Purple);
		}

		private void BlueThemeMenuItem_Click(object sender, RoutedEventArgs e)
		{
			ThemeManager.SetAccentTheme(ThemeManager.AccentTheme.Blue);
		}

		private void RedThemeMenuItem_Click(object sender, RoutedEventArgs e)
		{
			ThemeManager.SetAccentTheme(ThemeManager.AccentTheme.Red);
		}

		private void TealThemeMenuItem_Click(object sender, RoutedEventArgs e)
		{
			ThemeManager.SetAccentTheme(ThemeManager.AccentTheme.Teal);
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
			PurpleThemeMenuItem.IsChecked = ThemeManager.CurrentAccentTheme == ThemeManager.AccentTheme.Purple;
			BlueThemeMenuItem.IsChecked = ThemeManager.CurrentAccentTheme == ThemeManager.AccentTheme.Blue;
			RedThemeMenuItem.IsChecked = ThemeManager.CurrentAccentTheme == ThemeManager.AccentTheme.Red;
			TealThemeMenuItem.IsChecked = ThemeManager.CurrentAccentTheme == ThemeManager.AccentTheme.Teal;
			ThemeStatusText.Text = $"{(useDarkTheme ? LanguageManager.Get("Theme.DarkStatus") : LanguageManager.Get("Theme.LightStatus"))} | {ThemeManager.CurrentAccentTheme}";
		}

		private void UpdateLanguageControls()
		{
			EnglishMenuItem.IsChecked = LanguageManager.CurrentLanguage == AppLanguage.English;
			ChineseMenuItem.IsChecked = LanguageManager.CurrentLanguage == AppLanguage.Chinese;
			NorwegianMenuItem.IsChecked = LanguageManager.CurrentLanguage == AppLanguage.Norwegian;
		}
	}
}
