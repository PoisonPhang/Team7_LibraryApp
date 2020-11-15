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
    public class CheckoutBookDelegate : NonQueryDataDelegate<BookCheckout>
    {
        public readonly int BookId;
        public readonly int UserId;
        public readonly int LocationId;
        public readonly string LibrarianId;
        public readonly string OutDate;
        public readonly string DueDate;

        public CheckoutBookDelegate(int BookId, int UserId, int LocationId, string LibrarianId, string OutDate, string DueDate) : base ("T7Library.CheckoutBook")
        {
            this.BookId = BookId;
            this.UserId = UserId;
            this.LocationId = LocationId;
            this.LibrarianId = LibrarianId;
            this.OutDate = OutDate;
            this.DueDate = DueDate;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("BookId", BookId);
            command.Parameters.AddWithValue("UserId", UserId);
            command.Parameters.AddWithValue("LocationId", LocationId);
            command.Parameters.AddWithValue("LibrarianId", LibrarianId);
            command.Parameters.AddWithValue("OutDate", OutDate);
            command.Parameters.AddWithValue("DueDate", DueDate);
        }

        public override BookCheckout Translate(SqlCommand command)
        {
            return new BookCheckout(BookId, UserId, LocationId, LibrarianId, OutDate, DueDate);
        }
    }
}
