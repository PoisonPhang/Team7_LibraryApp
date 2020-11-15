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
    public class AddLibrarianDelegate : DataDelegate
    {
        public readonly string Username;
        public readonly string PasswordHash;
        public readonly string FirstName;
        public readonly string LastName;
        public readonly string StartDate;

        public AddLibrarianDelegate(string Username, string passwordHash, string FirstName, string LastName, string StartDate) : base("T7Library.AddLibrarian")
        {
            this.Username = Username;
            this.PasswordHash = passwordHash;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.StartDate = StartDate;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Username", Username);
            command.Parameters.AddWithValue("PasswordHash", PasswordHash);
            command.Parameters.AddWithValue("FirstName", FirstName);
            command.Parameters.AddWithValue("LastName", LastName);
            command.Parameters.AddWithValue("StartDate", StartDate);
        }
    }
}
