﻿using System;
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
        public readonly string StartDate;
        public readonly string EndDate;
        public RankLibrariesDelegate(string StartDate, string EndDate) : base("T7Library.RankLibraries")
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("StartDate", StartDate);
            command.Parameters.AddWithValue("EndDate", EndDate);
        }

        public override IReadOnlyList<LibraryRankReport> Translate(SqlCommand command, IDataRowReader reader)
        {
            List<LibraryRankReport> libraryRankReports = new List<LibraryRankReport>();

            while (reader.Read())
            {
                libraryRankReports.Add(new LibraryRankReport(reader.GetInt32("LocationId"), reader.GetString("Location"), reader.GetInt32("Checkouts"), reader.GetBigInt("Rank")));
            }

            return libraryRankReports;
        }
    }
}
