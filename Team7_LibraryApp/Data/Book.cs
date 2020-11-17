using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team7_LibraryApp.Data
{
    public class Book
    {
        public string ISBN { get; }
        public string Title { get; }
        public int GenreCode { get; }
        public string Publisher { get; }
        public int Year { get; }

        public string Author { get; }

        public Book (string ISBN, string Title, int GenreCode, string Publisher, int Year)
        {
            this.ISBN = ISBN;
            this.Title = Title;
            this.GenreCode = GenreCode;
            this.Publisher = Publisher;
            this.Year = Year;
        }

        public Book(string ISBN, string Title, int GenreCode, string Publisher, int Year, string Author)
        {
            this.ISBN = ISBN;
            this.Title = Title;
            this.GenreCode = GenreCode;
            this.Publisher = Publisher;
            this.Year = Year;
            this.Author = Author; 
        }
    }
}
