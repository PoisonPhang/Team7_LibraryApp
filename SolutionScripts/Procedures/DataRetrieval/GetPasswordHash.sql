CREATE OR ALTER PROCEDURE T7Library.GetPasswordHash
    @Username NVARCHAR(32)
AS
    SELECT PasswordHash
    FROM T7Library.Librarian
    WHERE Username = @Username