using MonkeysMVVM.ViewModels;

namespace MonkeysMVVM.Views;

public partial class FindMonkeyByLocationPage : ContentPage
{
	public FindMonkeyByLocationPage(FindMonkeyByLocationPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}