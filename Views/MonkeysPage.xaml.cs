namespace MonkeysMVVM.Views;
using MonkeysMVVM.ViewModels;

public partial class MonkeysPage : ContentPage
{
	public MonkeysPage(MonkeysPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}