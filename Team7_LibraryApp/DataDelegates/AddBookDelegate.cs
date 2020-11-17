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
        public readonly string Genre;
        public readonly string Publisher;
        public readonly int Year;
        public readonly string AuthorFirstName;
        public readonly string AuthorLastName;

        public AddBookDelegate(string ISBN, string Title, string Genre, string Publisher, int Year, string AuthorFirstName, string AuthorLastName) : base ("T7Library.AddBook")
        {
            this.ISBN = ISBN;
            this.Title = Title;
            this.Genre = Genre;
            this.Publisher = Publisher;
            this.Year = Year;
            this.AuthorFirstName = AuthorFirstName;
            this.AuthorLastName = AuthorLastName;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Title", Title);
            command.Parameters.AddWithValue("Publisher", Publisher);
            command.Parameters.AddWithValue("ISBN", ISBN);
            command.Parameters.AddWithValue("Year", Year);
            command.Parameters.AddWithValue("Genre", Genre);
            command.Parameters.AddWithValue("AuthorFirstName", AuthorFirstName);
            command.Parameters.AddWithValue("AuthorLastName", AuthorLastName);
        }

        public override Book Translate(SqlCommand command)
        {
            return new Book(ISBN, Title, Genre, Publisher, Year);
        }
    }
}
