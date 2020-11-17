CREATE OR ALTER PROCEDURE T7Library.CheckoutBook
	@BookId INT,
	@UserId INT,
	@LocationId INT,
	@LibrarianId NVARCHAR(32),
	@OutDate DATETIME,
	@DueDate DATETIME
AS

INSERT T7Library.Checkout(BookId, UserId, LocationId, LibrarianId, OutDate, DueDate)
VALUES (@BookId, @UserId, @LocationId, @LibrarianId, @OutDate, @DueDate);

UPDATE T7Library.BookCopy
SET IsCheckedOut = 1
WHERE BookId = @BookId;

SELECT C.BookId, B.Title, BA.FirstName + N' ' + BA.LastName as Author, C.UserId, U.FirstName as UserFirstName, U.LastName AS UserLastName, C.OutDate, C.DueDate
FROM T7Library.Checkout C
INNER JOIN T7Library.BookCopy BC ON C.BookId = BC.BookId
INNER JOIN T7Library.Book B ON BC.ISBN = B.ISBN
INNER JOIN T7Library.BookAuthor BA ON B.ISBN = BA.ISBN
INNER JOIN T7Library.[User] U ON C.UserId = U.UserId
WHERE C.BookId = @BookId AND ReturnDate IS NULL;