﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team7_LibraryApp.Data
{
    public class BookReturn
    {
        public string ISBN { get; }
        public string Title { get; }
        public string Author { get; }
        public int UserId { get; }
        public string DueDate { get; }
        public int DaysOverdue { get; }
        public double PenaltyFee { get; }

        public BookReturn(string ISBN, string Title, string Author, int UserId, DateTime DueDate, int DaysOverdue, double PenaltyFee)
        {
            this.ISBN = ISBN;
            this.Title = Title;
            this.Author = Author;
            this.UserId = UserId;
            this.DueDate = DueDate.ToString("MM/dd/yyyy");
            this.DaysOverdue = DaysOverdue;
            this.PenaltyFee = PenaltyFee;
        }
    }
}
