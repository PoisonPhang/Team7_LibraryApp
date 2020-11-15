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
    public class RankBooksDelegate : DataReaderDelegate<IReadOnlyList<BookRankReport>>
    {
        public readonly int GenreCode;
        public RankBooksDelegate(int GenreCode) : base("T7Library.RankBooksByGenre")
        {
            this.GenreCode = GenreCode;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("GenreCode", GenreCode);
        }

        public override IReadOnlyList<BookRankReport> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<BookRankReport> bookRankReports = new List<BookRankReport>();

            while (reader.Read())
            {
                bookRankReports.Add(new BookRankReport(reader.GetString("ISBN"), reader.GetString("Title"), reader.GetString("BookAuthor"), reader.GetString("Genre"), reader.GetInt32("Rank")));
            }

            return bookRankReports;
        }
    }
}
