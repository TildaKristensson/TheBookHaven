using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookHaven.Command;
using TheBookHaven.Data;
using TheBookHaven.Model;

namespace TheBookHaven.ViewModel
{
    class BookStockViewModel 
    {

        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int StockBalance { get; set; }

        public RelayCommand AddToStockCommand { get; }

        public RelayCommand RemoveFromStockCommand { get; }
        public BookStore BookStore { get; set; }

        private StockBalance _stockBalance;

        public BookStockViewModel(Book book, StockBalance stockBalance)
        {
            Title = book.Title;
            Isbn = book.Isbn;
            Author = string.Join(", ", book.Authors.Select(a => $"{a.Firstname} {a.Lastname}"));
            Price = book.PriceInKr;
            StockBalance = stockBalance.UnitsInStock;
            _stockBalance = stockBalance;
            BookStore = stockBalance.BookStore;

            AddToStockCommand = new RelayCommand(AddToStock);
            RemoveFromStockCommand = new RelayCommand(RemoveFromStock);
        }

 
        private void AddToStock(object obj)
        {
            StockBalance++;
            _stockBalance.UnitsInStock = StockBalance;
            UpdateStockInDatabase();
        }


        private void RemoveFromStock(object obj)
        {
            if (StockBalance > 0)
            {
                StockBalance--;
                _stockBalance.UnitsInStock = StockBalance;
                UpdateStockInDatabase();
            }
        }


        private void UpdateStockInDatabase()
        {
            using var context = new TheBookHavenContext();
            var currentStock = context.StockBalances
                .FirstOrDefault(sb => sb.BookStoreId == _stockBalance.BookStoreId && sb.Isbn == _stockBalance.Isbn);

            if (currentStock != null)
            {
                currentStock.UnitsInStock = _stockBalance.UnitsInStock;

                context.SaveChanges();
            }
        }
    }
}
