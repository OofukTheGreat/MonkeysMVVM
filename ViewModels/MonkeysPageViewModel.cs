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
    public class MonkeysPageViewModel : ViewModel
    {
        private MonkeysService service;

        private bool isRefreshing;
        private string entry;
        private List<Monkey> monkeys;
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public string Entry { get { return entry; } set { entry = value; OnPropertyChanged(); } }
        private Monkey selectedMonkey;
        public Monkey SelectedMonkey { get=>selectedMonkey; set { selectedMonkey = value; OnPropertyChanged(); } }
        public ICommand FilterMonkeysCommand { get; private set; }
        public ICommand LoadMonkeysCommand { get; private set; }
        public ICommand ClearMonkeysCommand { get; private set; }
        public ICommand NavigateShowMonkeyCommand { get; private set; }
        public ICommand DeleteMonkeysCommand { get; private set; }
        public ObservableCollection<Monkey> Monkeys { get; set; }
        public MonkeysPageViewModel(MonkeysService s)
        {
            service = s;
            Monkeys = new ObservableCollection<Monkey>();
            LoadMonkeysCommand = new Command(async () => await LoadMonkeys());
            FilterMonkeysCommand = new Command<string>((x) => FilterMonkeys(x));
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
            SelectedMonkey = null;
        }
        private void FilterMonkeys(string filter)
        {
            Monkeys.Clear();
            foreach (Monkey monkey in monkeys)
            {
                Monkeys.Add(monkey);
            }
            filter = filter.ToLower();
            List<Monkey> filtered=new List<Monkey>();    
            foreach (Monkey m in Monkeys)
            {
                if (m.Name.ToLower().Contains(filter) || m.Location.ToLower().Contains(filter))
                {
                    filtered.Add(m);
                }
            }
            Monkeys.Clear();
            foreach (Monkey m in filtered)
            {
                Monkeys.Add(m);
            }

        }
        private void ClearMonkeys()
        {
            Monkeys.Clear();
            ((Command)ClearMonkeysCommand).ChangeCanExecute();
        }
        private async Task LoadMonkeys()
        {
            IsRefreshing = true;
            monkeys = await service.GetMonkeys();
            Monkeys.Clear();
            foreach (var item in monkeys)
            {
                Monkeys.Add(item);
            }
            IsRefreshing = false;
        }
    }
}
