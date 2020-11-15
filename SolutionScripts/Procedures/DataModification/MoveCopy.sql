CREATE OR ALTER PROCEDURE T7Library.MoveCopy
	@BookId INT,
	@LocationId INT
AS

UPDATE T7Library.BookCopy
SET LocationId = @LocationId
WHERE LocationId <> @LocationId AND BookId = @BookId;