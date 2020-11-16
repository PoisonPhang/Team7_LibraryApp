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
    public class ReturnBookDelegate : DataReaderDelegate<BookReturn>
    {
        public readonly int BookId;
        public readonly int LocationId;

        public ReturnBookDelegate(int BookId, int LocationId) : base("T7Library.ReturnBook")
        {
            this.BookId = BookId;
            this.LocationId = LocationId;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("BookId", BookId);
            command.Parameters.AddWithValue("LocationId", LocationId);
        }

        public override BookReturn Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(BookId.ToString());

            return new BookReturn(reader.GetString("ISBN"), 
                reader.GetString("Title"), 
                reader.GetString("Author"), 
                reader.GetInt32("UserId"), 
                reader.GetDateTime("DueDate"), 
                reader.GetInt32("DaysOverDue"), 
                reader.GetInt32("PenaltyFee"));
        }
    }
}
