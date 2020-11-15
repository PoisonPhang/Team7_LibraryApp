using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Team7_LibraryApp.DataDelegates
{
    public class MoveCopyDelegate : DataDelegate
    {
        public readonly int BookId;
        public readonly int LocationId;

        public MoveCopyDelegate(int BookId, int LocationId) : base ("T7Library.MoveCopy")
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
    }
}
