using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Team7_LibraryApp.Data
{
    public class ThreeDaysLeftReport
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string BookTitle { get; }
        public string BookAuthor { get; }
        public string DueDate { get; }

        public ThreeDaysLeftReport(string FirstName, string LastName, string Email, string BookTitle, string BookAuthor, DateTime DueDate)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.BookTitle = BookTitle;
            this.BookAuthor = BookAuthor;
            this.DueDate = DueDate.ToString("MM/dd/yyyy");
        }
    }
}
