using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Team7_LibraryApp
{
    public class GetActiveCheckoutsDelegate : DataDelegate
    {
        public readonly int LocationId;

        public GetActiveCheckoutsDelegate(int LocationId) : base("T7Library.GetActiveCheckouts")
        {
            this.LocationId = LocationId;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("LocationId", LocationId);
        }
    }
}
