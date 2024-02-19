using MonkeysMVVM.Views;

namespace MonkeysMVVM;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
