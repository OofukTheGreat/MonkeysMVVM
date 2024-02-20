using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MonkeysMVVM.Models;
using MonkeysMVVM.Services;

namespace MonkeysMVVM.ViewModels
{
    class MonkeysPageViewModel : ViewModel
    {
        private bool isRefreshing;
        private string entry;
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public string Entry { get { return entry; } set { entry = value; OnPropertyChanged(); } }
        public Monkey Monkey { get; set; }
        public Monkey SelectedMonkey { get; set; }
        public ICommand AddMonkeysCommand { get; private set; }
        public ICommand LoadMonkeysCommand { get; private set; }
        public ICommand ClearMonkeysCommand { get; private set; }
        public ICommand NavigateShowMonkeyCommand { get; private set; }
        public ICommand DeleteMonkeysCommand { get; private set; }
        public ObservableCollection<Monkey> Monkeys { get; set; }
        public MonkeysPageViewModel()
        {
            Monkeys = new ObservableCollection<Monkey>();
            LoadMonkeysCommand = new Command(async () => await LoadMonkeys());
            AddMonkeysCommand = new Command(() => AddMonkeys());
            ClearMonkeysCommand = new Command(ClearMonkeys, () => Monkeys.Count > 0);
            DeleteMonkeysCommand = new Command((Object obj) => { Monkey mk = (Monkey)obj; Monkeys.Remove(mk); });
            NavigateShowMonkeyCommand = new Command(async () => await NavShowMonkeys());
            LoadMonkeys();
        }
        private async Task NavShowMonkeys()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Monkey", SelectedMonkey);
            await AppShell.Current.GoToAsync("ShowMonkey", data);
        }
        private void AddMonkeys()
        {

        }
        private void ClearMonkeys()
        {
            Monkeys.Clear();
            ((Command)ClearMonkeysCommand).ChangeCanExecute();
        }
        private async Task LoadMonkeys()
        {
            IsRefreshing = true;
            MonkeysService service = new MonkeysService();
            var list = await service.GetMonkeys();
            Monkeys.Clear();
            foreach (var item in list)
            {
                Monkeys.Add(item);
            }
            IsRefreshing = false;
        }
    }
}
