using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Team7_LibraryApp.Data;

namespace Team7_LibraryApp.DataDelegates
{
    public class AddBookDelegate : NonQueryDataDelegate<Book>
    {
        public readonly string ISBN;
        public readonly string Title;
        public readonly int GenreCode;
        public readonly string Publisher;
        public readonly int Year;

        public AddBookDelegate(string ISBN, string Title, int GenreCode, string Publisher, int Year) : base ("T7Library.AddBook")
        {
            this.ISBN = ISBN;
            this.Title = Title;
            this.GenreCode = GenreCode;
            this.Publisher = Publisher;
            this.Year = Year;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("ISBN", ISBN);
            command.Parameters.AddWithValue("Title", Title);
            command.Parameters.AddWithValue("GenreCode", GenreCode);
            command.Parameters.AddWithValue("Publisher", Publisher);
            command.Parameters.AddWithValue("Year", Year);
        }

        public override Book Translate(SqlCommand command)
        {
            return new Book(ISBN, Title, GenreCode, Publisher, Year);
        }
    }
}
