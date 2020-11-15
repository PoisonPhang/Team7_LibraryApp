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
    public class RankLibrariesDelegate : DataReaderDelegate<IReadOnlyList<LibraryRankReport>>
    {
        public RankLibrariesDelegate() : base("T7Library.RankLibraries")
        {

        }

        public override IReadOnlyList<LibraryRankReport> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<LibraryRankReport> libraryRankReports = new List<LibraryRankReport>();

            while (reader.Read())
            {
                libraryRankReports.Add(new LibraryRankReport(reader.GetInt32("LocationId"), reader.GetString("Location"), reader.GetInt32("Checkouts"), reader.GetInt32("Rank")));
            }

            return libraryRankReports;
        }
    }
}
