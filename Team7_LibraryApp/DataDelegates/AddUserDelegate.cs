using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Team7_LibraryApp.Data;

namespace Team7_LibraryApp.DataDelegates
{
    public class AddUserDelegate : NonQueryDataDelegate<User>
    {
        public int UserId;
        public readonly string FirstName;
        public readonly string LastName;
        public readonly string Email;
        public readonly string Street;
        public readonly string Unit;
        public readonly int ZipCode;
        public readonly string CityName;
        public readonly string StateCode;

        public AddUserDelegate(string FirstName, string LastName, string Email, string Street, string Unit, int ZipCode, string CityName, string StateCode) : base ("T7Library.AddUser")
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Street = Street;
            this.Unit = Unit;
            this.ZipCode = ZipCode;
            this.CityName = CityName;
            this.StateCode = StateCode;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("FirstName", FirstName);
            command.Parameters.AddWithValue("LastName", LastName);
            command.Parameters.AddWithValue("Email", Email);
            command.Parameters.AddWithValue("Street", Street);
            command.Parameters.AddWithValue("Unit", Unit);
            command.Parameters.AddWithValue("ZipCode", ZipCode);
            command.Parameters.AddWithValue("CityName", CityName);
            command.Parameters.AddWithValue("StateCode", StateCode);
            command.Parameters.Add("UserId", SqlDbType.Int).Direction = ParameterDirection.Output;
        }

        public override User Translate(SqlCommand command)
        {
            this.UserId = (int)command.Parameters["UserId"].Value;
            return new User(UserId, FirstName, LastName, Email, Street, Unit, ZipCode, CityName, StateCode);
        }
    }
}
