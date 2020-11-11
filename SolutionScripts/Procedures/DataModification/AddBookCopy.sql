CREATE OR ALTER PROCEDURE T7Library.AddBookCopy
	@ISBN NVARCHAR(13),
	@LocationId INT
AS

INSERT T7Library.BookCopy (ISBN, LocationId)
VALUES (@ISBN, @LocationId);