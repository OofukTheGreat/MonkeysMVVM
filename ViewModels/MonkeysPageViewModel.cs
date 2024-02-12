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
    class MonkeysPageViewModel
    {
        public ICommand LoadMonkeysCommand { get; private set; }
        public ObservableCollection<Monkey> monkeys { get; set; }
        public MonkeysPageViewModel()
        {
            monkeys = new ObservableCollection<Monkey>();
            LoadMonkeysCommand = new Command(async () => await LoadMonkeys());
        }
        public async Task LoadMonkeys()
        {
            MonkeysService service = new MonkeysService();

        }
    }
}
