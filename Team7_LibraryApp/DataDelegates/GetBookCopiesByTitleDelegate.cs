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
    public class GetBookCopiesByTitleDelegate : DataReaderDelegate<IReadOnlyList<BookCopy>>
    {
        public readonly string TitlePartial;

        public GetBookCopiesByTitleDelegate(string TitlePartial) : base("T7Library.GetAllBookCopiesByTitle")
        {
            this.TitlePartial = TitlePartial;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("TitlePartial", TitlePartial);
        }

        public override IReadOnlyList<BookCopy> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<BookCopy> bookCopies = new List<BookCopy>();

            while (reader.Read())
            {
                bookCopies.Add(new BookCopy(reader.GetInt32("BookId"), reader.GetString("Title"), reader.GetString("Author"), reader.GetString("Location")));
            }

            return bookCopies;
        }
    }
}
