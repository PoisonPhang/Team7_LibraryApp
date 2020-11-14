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
    class GetBookCopiesByAuthorDelegate : DataReaderDelegate<IReadOnlyList<BookCopy>>
    {
        public readonly string AuthorPartial;

        public GetBookCopiesByAuthorDelegate(string AuthorPartial) : base("T7Library.GetAllBookCopiesByAuthor")
        {
            this.AuthorPartial = AuthorPartial;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("AuthorPartial", AuthorPartial);
        }

        public override IReadOnlyList<BookCopy> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<BookCopy> bookCopies = new List<BookCopy>();

            while(reader.Read())
            {
                bookCopies.Add(new BookCopy(reader.GetInt32("BookId"), reader.GetString("Title"), reader.GetString("Author"), reader.GetString("Location")));
            }

            return bookCopies;
        }
    }
}
