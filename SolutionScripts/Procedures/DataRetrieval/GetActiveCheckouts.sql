CREATE OR ALTER PROCEDURE T7Library.GetActiveCheckouts
AS

SELECT C.BookId, B.Title, BA.FirstName + N' ' + BA.LastName as Author, C.UserId, U.FirstName as UserFirstName, U.LastName AS UserLastName, C.OutDate, C.DueDate
FROM T7Library.Checkout C
INNER JOIN T7Library.BookCopy BC ON C.BookId = BC.BookId
INNER JOIN T7Library.Book B ON BC.ISBN = B.ISBN
INNER JOIN T7Library.BookAuthor BA ON B.ISBN = BA.ISBN
INNER JOIN T7Library.[User] U ON C.UserId = U.UserId
WHERE C.ReturnDate IS NULL