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
    public class GetOverdueCheckoutsDelegate : DataReaderDelegate<IReadOnlyList<LateReport>>
    {
        public GetOverdueCheckoutsDelegate() : base("T7Library.GetOverduePenalties")
        {

        }

        public override IReadOnlyList<LateReport> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<LateReport> lateReports = new List<LateReport>();

            while (reader.Read())
            {
                lateReports.Add(new LateReport(reader.GetInt32("UserId"), 
                    reader.GetString("UsersName"), 
                    reader.GetInt32("BookId"), 
                    reader.GetString("ISBN"), 
                    reader.GetString("Title"), 
                    reader.GetString("Author"), 
                    reader.GetDateTime("DueDate"), 
                    reader.GetInt32("DaysOverdue"), 
                    reader.GetInt32("PenaltyFee")));
            }

            return lateReports;
        }
    }
}
