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
    class CheckISBNDelegate : DataReaderDelegate<Book>
    {
        public readonly string ISBN;

        public CheckISBNDelegate(string ISBN) : base("T7Library.CheckISBN")
        {
            this.ISBN = ISBN;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("ISBN", ISBN);
        }

        public override Book Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read()) return null;

            return new Book(ISBN, reader.GetString("Title"), reader.GetInt32("GenreCode"), reader.GetString("Publisher"), reader.GetInt32("Year"));
        }
    }
}
