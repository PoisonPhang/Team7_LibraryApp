using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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

        public AddLibrarianDelegate(string Username, string password, string FirstName, string LastName, string StartDate) : base("T7Library.AddLibrarian")
        {
            this.Username = Username;
            this.PasswordHash = HashPassword(password);
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

        public string HashPassword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
