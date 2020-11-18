using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team7_LibraryApp.Data
{
    public class LateReport
    {
        public int UserId { get; }
        public string UserName { get; }
        public int BookId { get; }
        public string ISBN { get; }
        public string Title { get; }
        public string Author { get; }
        public string DueDate { get; }
        public int DaysOverDue { get; }
        public double PenaltyFee { get; }

        public LateReport(int UserId, string UserName, int BookId, string ISBN, string Title, string Author, DateTime DueDate, int DaysOverDue, double PenaltyFee)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.BookId = BookId;
            this.ISBN = ISBN;
            this.Title = Title;
            this.Author = Author;
            this.DueDate = DueDate.ToString("MM/dd/yyyy");
            this.DaysOverDue = DaysOverDue;
            this.PenaltyFee = PenaltyFee;
        }
    }
}
