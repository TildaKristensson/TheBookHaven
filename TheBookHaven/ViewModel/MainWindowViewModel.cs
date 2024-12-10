using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookHaven.Command;
using TheBookHaven.Data;
using TheBookHaven.Model;

namespace TheBookHaven.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public WelcomeViewModel WelcomeViewModel { get; }
        public RelayCommand EnterTheBookHavenCommand { get; }

        public BookStockViewModel BookStockViewModel { get; }

        public ObservableCollection<BookStore> BookStores { get; set; }
        

        private ObservableCollection<BookStockViewModel> _stockItems = new();
        public ObservableCollection<BookStockViewModel> StockItems
        {
            get => _stockItems;
            set
            {
                _stockItems = value;
                RaisePropertyChanged(nameof(StockItems));   
            }
        }

        private BookStockViewModel _selectedStockItem;

        public BookStockViewModel SelectedStockItem
        {
            get => _selectedStockItem;
            set
            {
                _selectedStockItem = value;
                RaisePropertyChanged(nameof(SelectedStockItem));
            }
        }

        private BookStore _selectedStore;
        public BookStore SelectedStore
        {
            get => _selectedStore;
            set
            {
                _selectedStore = value;
                RaisePropertyChanged(nameof(SelectedStore));
                LoadStockItems();
            }
        }

        private bool _isWelcomeView;
        private bool _isMainView;
        public bool IsWelcomeView
        {
            get { return _isWelcomeView; }
            set
            {
                _isWelcomeView = value;
                RaisePropertyChanged(nameof(IsWelcomeView));
                
            }

        }

        public bool IsMainView
        {
            get { return _isMainView; }
            set
            {
                _isMainView = value;
                RaisePropertyChanged(nameof(IsMainView));
                
            }
        }
        public MainWindowViewModel()
        {
           
            using var context = new TheBookHavenContext();

            WelcomeViewModel = new WelcomeViewModel(this);

            IsWelcomeView = true;
            IsMainView = false;

            EnterTheBookHavenCommand = new RelayCommand(EnterTheBookHaven);

            BookStores = new ObservableCollection<BookStore>(context.BookStores.ToList());
            
        }

        private void EnterTheBookHaven(object obj)
        {
            IsMainView = true;
            IsWelcomeView = false;
        }

        private void LoadStockItems()
        {
            if (SelectedStore != null)
            {
                using var context = new TheBookHavenContext();
                var stockItems = context.StockBalances
                    .Where(sb => sb.BookStoreId == SelectedStore.Id)
                    .Include(sb => sb.IsbnNavigation.Authors)
                    .ToList();

                StockItems.Clear();

                foreach (var stockItem in stockItems)
                {
                    var bookStockViewModel = new BookStockViewModel(stockItem.IsbnNavigation, stockItem);
                    StockItems.Add(bookStockViewModel);
                }
            }
        }
    }
}
