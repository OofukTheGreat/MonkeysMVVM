namespace MonkeysMVVM.Views;
using MonkeysMVVM.ViewModels;

public partial class MonkeysPage : ContentPage
{
	public MonkeysPage()
	{
		InitializeComponent();
		this.BindingContext = new MonkeysPageViewModel();
	}
}