using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Team7_LibraryApp.Data;
using Team7_LibraryApp.DataDelegates;

namespace Team7_LibraryApp
{
    public class LibraryDataRepo
    {
        private readonly SqlCommandExecutor executor;
        const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=Database;Integrated Security=SSPI;";

        public LibraryDataRepo()
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public void AddBook(string ISBN, string Title, int GenreCode, string Publisher, int Year)
        {
            AddBookDelegate d = new AddBookDelegate(ISBN, Title, GenreCode, Publisher, Year);

            executor.ExecuteNonQuery(d);
        }

        public void AddBookCopy(string ISBN, int LocationId)
        {
            AddBookCopyDelegate d = new AddBookCopyDelegate(ISBN, LocationId);

            executor.ExecuteNonQuery(d);
        }

        public User AddUser(string FirstName, string LastName, string Email, string Street, string Unit, int ZipCode, string CityName, string StateCode)
        {
            AddUserDelegate d = new AddUserDelegate(FirstName, LastName, Email, Street, Unit, ZipCode, CityName, StateCode);

            return executor.ExecuteNonQuery(d);
        }

        public void CheckoutBook(int BookId, int UserId, int LocationId, string LibrarianId, string OutDate, string DueDate)
        {
            CheckoutBookDelegate d = new CheckoutBookDelegate(BookId, UserId, LocationId, LibrarianId, OutDate, DueDate);

            executor.ExecuteNonQuery(d);
        }

        public IReadOnlyList<BookCopy> GetBookCopiesByAuthor(string AuthorPartial)
        {
            GetBookCopiesByAuthorDelegate d = new GetBookCopiesByAuthorDelegate(AuthorPartial);

            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<BookCopy> GetBookCopiesByTitle(string TitlePartial)
        {
            GetBookCopiesByTitleDelegate d = new GetBookCopiesByTitleDelegate(TitlePartial);

            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<BookCheckout> GetBookCheckoutsByBookId(int BookId)
        {
            GetCheckoutsByBookIdDelegate d = new GetCheckoutsByBookIdDelegate(BookId);

            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<BookCheckout> GetBookCheckoutsByUsersName(string NamePartial)
        {
            GetCheckoutsByUsersNameDelegate d = new GetCheckoutsByUsersNameDelegate(NamePartial);

            return executor.ExecuteReader(d);
        }

        public void MoveCopy(int BookId, int LocationId)
        {
            MoveCopyDelegate d = new MoveCopyDelegate(BookId, LocationId);

            executor.ExecuteNonQuery(d);
        }

        public BookReturn ReturnBook(int BookId, int LocationId)
        {
            ReturnBookDelegate d = new ReturnBookDelegate(BookId, LocationId);

            return executor.ExecuteReader(d);
        }

        public void AddLibrarian(string Username, string passwordHash, string FirstName, string LastName, string StartDate)
        {
            AddLibrarianDelegate d = new AddLibrarianDelegate(Username, passwordHash, FirstName, LastName, StartDate);

            executor.ExecuteNonQuery(d);
        }

        public IReadOnlyList<LateReport> GetOverDueCheckouts()
        {
            GetOverdueCheckoutsDelegate d = new GetOverdueCheckoutsDelegate();

            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<ThreeDaysLeftReport> GetThreeDaysLeft()
        {
            GetThreeDaysLeftDelegate d = new GetThreeDaysLeftDelegate();

            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<BookRankReport> GetBookRankReports(int GenreCode)
        {
            RankBooksDelegate d = new RankBooksDelegate(GenreCode);

            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<LibraryRankReport> GetLibraryRankReports(string StartDate, string EndDate)
        {
            RankLibrariesDelegate d = new RankLibrariesDelegate(StartDate, EndDate);

            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<BookCheckout> GetAllActiveCheckouts()
        {
            GetAllActiveCheckouts d = new GetAllActiveCheckouts();

            return executor.ExecuteReader(d);
        }

        public bool ValidateLogin(string username, string password)
        {
            GetPasswordHashDelegate d = new GetPasswordHashDelegate(username);
            Librarian librarian = executor.ExecuteReader(d);

            if (librarian == null) return false;

            return librarian.CheckPassword(password);
        }
    }
}
