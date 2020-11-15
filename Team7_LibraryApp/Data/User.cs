using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team7_LibraryApp.Data
{
    public class User
    {
        public int UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Street { get; }
        public string Unit { get; }
        public int ZipCode { get; }
        public string CityName { get; }
        public string StateCode { get; }

        public User(int UserId, string FirstName, string LastName, string Email, string Street, string Unit, int ZipCode, string CityName, string StateCode)
        {
            this.UserId = UserId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Street = Street;
            this.Unit = Unit;
            this.ZipCode = ZipCode;
            this.CityName = CityName;
            this.StateCode = StateCode;
        }
    }
}
