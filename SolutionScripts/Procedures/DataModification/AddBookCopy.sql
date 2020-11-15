CREATE OR ALTER PROCEDURE T7Library.AddBookCopy
	@ISBN NVARCHAR(13),
	@LocationId INT,
	@BookId INT OUTPUT
AS

INSERT T7Library.BookCopy (ISBN, LocationId)
VALUES (@ISBN, @LocationId);

SET @BookId = SCOPE_IDENTITY();