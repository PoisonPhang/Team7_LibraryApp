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
    class GetPasswordHashDelegate : DataReaderDelegate<Librarian>
    {
        public readonly string Username;

        public GetPasswordHashDelegate(string Username) : base("T7Library.GetPasswordHash")
        {
            this.Username = Username;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Username", Username);
        }

        public override Librarian Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new Librarian(Username, reader.GetString("PasswordHash"));
        }
    }
}
