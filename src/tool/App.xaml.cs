using System.Windows;

namespace BBSFW
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override async void OnStartup(StartupEventArgs e)
		{
			try
			{
				base.OnStartup(e);

				ThemeManager.Initialize();
				LanguageManager.Initialize();
				ShutdownMode = ShutdownMode.OnExplicitShutdown;

				var splash = new View.SplashWindow();
				splash.Show();

				await System.Threading.Tasks.Task.Delay(900);

				var mainWindow = new MainWindow();
				MainWindow = mainWindow;
				ShutdownMode = ShutdownMode.OnMainWindowClose;
				mainWindow.Show();

				splash.Close();
			}
			catch (System.Exception ex)
			{
				System.IO.File.WriteAllText("BBSFWTool.startup.log", ex.ToString());
				MessageBox.Show(ex.Message, "BBS-FW Tool startup error", MessageBoxButton.OK, MessageBoxImage.Error);
				Shutdown(-1);
			}
		}
	}
}
