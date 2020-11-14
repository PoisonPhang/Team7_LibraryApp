CREATE OR ALTER PROCEDURE T7Library.AddLibrarian
    @Username NVARCHAR(32),
	@PasswordHash NVARCHAR(128),
	@FirstName NVARCHAR(32),
	@LastName NVARCHAR(32),
	@StartDate DATE
AS

INSERT T7Library.Librarian(UserName, PasswordHash, FirstName, LastName, StartDate)
VALUES (@UserName, @PasswordHash, @FirstName, @LastName, @StartDate);
