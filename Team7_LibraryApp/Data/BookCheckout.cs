using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team7_LibraryApp.Data
{
    public class BookCheckout
    {
        public int BookId { get; }
        public string Title { get; }
        public string Author { get; }
        public int UserId { get; }
        public string UserFirstName { get; }
        public string UserLastName { get; }
        public int LocationId { get; }
        public string LibrarianId { get; }
        public string OutDate { get; }
        public string DueDate { get; }

        public BookCheckout(int BookId, string Title, string Author, int UserId, string UserFirstName, string UserLastName, string OutDate, string DueDate)
        {
            this.BookId = BookId;
            this.Title = Title;
            this.Author = Author;
            this.UserId = UserId;
            this.UserFirstName = UserFirstName;
            this.UserLastName = UserLastName;
            this.OutDate = OutDate;
            this.DueDate = DueDate;
        }

        public BookCheckout(int BookId, int UserId, int LocationId, string LibrarianId, string OutDate, string DueDate)
        {
            this.BookId = BookId;
            this.UserId = UserId;
            this.LocationId = LocationId;
            this.LibrarianId = LibrarianId;
            this.OutDate = OutDate;
            this.DueDate = DueDate;
        }
    }
}
