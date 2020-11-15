using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team7_LibraryApp.Data
{
    public class BookRankReport
    {
        public string ISBN { get; }
        public string Title { get; }
        public string BookAuthor { get; }
        public string Genre { get; }
        public int Rank { get; }

        public BookRankReport(string ISBN, string Title, string BookAuthor, string Genre, int Rank)
        {
            this.ISBN = ISBN;
            this.Title = Title;
            this.BookAuthor = BookAuthor;
            this.Genre = Genre;
            this.Rank = Rank;
        }
    }
}
