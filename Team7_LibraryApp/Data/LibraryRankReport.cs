using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team7_LibraryApp.Data
{
    public class LibraryRankReport
    {
        public int LocationId { get; }
        public string Location { get; }
        public int Checkouts { get; }
        public long Rank { get; }

        public LibraryRankReport(int LocationId, string Location, int Checkouts, long Rank)
        {
            this.LocationId = LocationId;
            this.Location = Location;
            this.Checkouts = Checkouts;
            this.Rank = Rank;
        }
    }
}
