CREATE OR ALTER PROCEDURE T7Library.CheckoutBook
	@BookId INT,
	@UserId INT,
	@LocationId INT,
	@LibrarianId NVARCHAR(32),
	@OutDate DATE,
	@DueDate DATE
AS

INSERT T7Library.Checkout(BookId, UserId, LocationId, LibrarianId, OutDate, DueDate)
VALUES (@BookId, @UserId, @LocationId, @LibrarianId, @OutDate, @DueDate);

UPDATE T7Library.BookCopy
SET IsCheckedOut = 1
WHERE BookId = @BookId;