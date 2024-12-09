using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public BookStore BookStore { get; set; }

        public BookStockViewModel(Book book, StockBalance stockBalance)
        {
            Title = book.Title;
            Isbn = book.Isbn;
            Author = string.Join(", ", book.Authors.Select(a => $"{a.Firstname} {a.Lastname}"));
            Price = book.PriceInKr;
            StockBalance = stockBalance.UnitsInStock;
            BookStore = stockBalance.BookStore;
        }
    }
}
