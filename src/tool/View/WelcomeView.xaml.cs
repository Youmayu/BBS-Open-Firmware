using System.Windows;
using System.Windows.Controls;
using BBSFW.ViewModel;

namespace BBSFW.View
{
	/// <summary>
	/// Interaction logic for WelcomeView.xaml
	/// </summary>
	public partial class WelcomeView : UserControl
	{
		public WelcomeView()
		{
			InitializeComponent();
		}

		private void ContinueEasy_Click(object sender, RoutedEventArgs e)
		{
			if (DataContext is MainViewModel vm)
			{
				vm.IsEasyMode = true;
			}

			if (Window.GetWindow(this) is MainWindow window)
			{
				window.NavigateToEasySetup();
			}
		}

		private void ContinuePro_Click(object sender, RoutedEventArgs e)
		{
			if (DataContext is MainViewModel vm)
			{
				vm.IsProMode = true;
			}

			if (Window.GetWindow(this) is MainWindow window)
			{
				window.NavigateToProSetup();
			}
		}

		private void OpenConnection_Click(object sender, RoutedEventArgs e)
		{
			if (Window.GetWindow(this) is MainWindow window)
			{
				window.NavigateToConnection();
			}
		}
	}
}
