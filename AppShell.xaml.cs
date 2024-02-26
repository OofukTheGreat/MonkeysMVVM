namespace MonkeysMVVM;
using MonkeysMVVM.Views;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("MonkeyList", typeof(MonkeysPage));
		Routing.RegisterRoute("ShowMonkey", typeof(ShowMonkeyView));
	}
}
