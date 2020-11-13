using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Team7_LibraryApp.Data;

namespace Team7_LibraryApp.DataDelegates
{
    public class AddBookCopyDelegate : NonQueryDataDelegate<BookCopy>
    {
        public int BookId;
        public readonly string ISBN;
        public readonly int LocationId;
        public readonly bool IsCheckedOut;
        public readonly bool IsOutOfService;

        public AddBookCopyDelegate(string ISBN, int LocationId) : base ("T7Library.AddBookCopy")
        {
            this.ISBN = ISBN;
            this.LocationId = LocationId;
            this.IsCheckedOut = false;
            this.IsOutOfService = false;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("ISBN", ISBN);
            command.Parameters.AddWithValue("LocationId", LocationId);
            command.Parameters.Add("BookId", SqlDbType.Int).Direction = ParameterDirection.Output;
        }

        public override BookCopy Translate(SqlCommand command)
        {
            this.BookId = (int) command.Parameters["BookId"].Value;
            return new BookCopy(BookId, ISBN, LocationId, IsCheckedOut, IsOutOfService);
        }
    }
}
