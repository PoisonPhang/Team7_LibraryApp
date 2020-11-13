using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team7_LibraryApp.Data
{
    public class BookCopy
    {
        public int BookId { get; }
        public string ISBN { get; }
        public int LocationId { get; }
        public bool IsCheckedOut { get; }
        public bool IsOutOfService { get; }

        public BookCopy(int BookId, string ISBN, int LocationId, bool IsCheckedOut, bool IsOutOfService)
        {
            this.BookId = BookId;
            this.ISBN = ISBN;
            this.LocationId = LocationId;
            this.IsCheckedOut = IsCheckedOut;
            this.IsOutOfService = IsOutOfService;
        }
    }
}
