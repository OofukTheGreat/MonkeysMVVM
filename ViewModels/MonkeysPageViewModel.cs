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
    class MonkeysPageViewModel:ViewModel
    {
        private bool isRefreshing;
        public bool IsRefreshing {  get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public ICommand AddMonkeysCommand { get; private set; }
        public ICommand LoadMonkeysCommand { get; private set; }
        public ICommand ClearMonkeysCommand { get; private set; }
        public ObservableCollection<Monkey> Monkeys { get; set; }
        public MonkeysPageViewModel()
        {
            Monkeys = new ObservableCollection<Monkey>();
            LoadMonkeysCommand = new Command(async () => await LoadMonkeys());
            LoadMonkeys();
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
