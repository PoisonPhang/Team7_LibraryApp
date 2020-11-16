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
    public class GetCheckoutsByBookIdDelegate : DataReaderDelegate<IReadOnlyList<BookCheckout>>
    {
        public readonly int BookId;

        public GetCheckoutsByBookIdDelegate (int BookId) : base ("T7Library.GetCheckoutByBookId")
        {
            this.BookId = BookId;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("BookId", BookId);
        }

        public override IReadOnlyList<BookCheckout> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<BookCheckout> bookCheckouts = new List<BookCheckout>();

            while (reader.Read())
            {
                bookCheckouts.Add(new BookCheckout(reader.GetInt32("BookId"), reader.GetString("Title"), reader.GetString("Author"), reader.GetInt32("UserId"), reader.GetString("UserFirstName"), reader.GetString("UserLastName"), reader.GetDateTimeOffset("OutDate"), reader.GetDateTimeOffset("DueDate")));
            }

            return bookCheckouts;
        }
    }
}
