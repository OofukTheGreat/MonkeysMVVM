using MonkeysMVVM.ViewModels;

namespace MonkeysMVVM.Views;

public partial class ShowMonkeyView : ContentPage
{
	public ShowMonkeyView(ShowMonkeyViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}