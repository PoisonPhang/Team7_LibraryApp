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
    public class GetThreeDaysLeftDelegate : DataReaderDelegate<IReadOnlyList<ThreeDaysLeftReport>>
    {
        public GetThreeDaysLeftDelegate() : base("T7Library.CheckoutsWith3DaysLeft")
        {

        }

        public override IReadOnlyList<ThreeDaysLeftReport> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<ThreeDaysLeftReport> threeDaysLeftReports = new List<ThreeDaysLeftReport>();

            while (reader.Read())
            {
                threeDaysLeftReports.Add(new ThreeDaysLeftReport(reader.GetString("FirstName"), 
                    reader.GetString("LastName"), 
                    reader.GetString("Email"), 
                    reader.GetString("BookTitle"), 
                    reader.GetString("BookAuthor"), 
                    reader.GetString("DueDate")));
            }

            return threeDaysLeftReports;
        }
    }
}
