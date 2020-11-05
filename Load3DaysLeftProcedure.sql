CREATE OR ALTER PROCEDURE T7Library.CheckoutsWith3DaysLeft
AS
SELECT U.FisrtName, U.LastName, UE.Email, B.Title as BookTitle, BA.FisrtName + N' ' + BA.LastName as BookAuthor, C.DueDate
FROM T7Library.Checkout C
INNER JOIN T7Library.BookCopy BC ON C.BookId = BC.BookId
INNER JOIN T7Library.Book B ON BC.ISBN = B.ISBN
INNER JOIN T7Library.BookAuthor BA ON B.ISBN = BA.ISBN
INNER JOIN T7Library.[User] U ON C.UserId = U.UserId
INNER JOIN T7Library.UserEmail UE ON U.UserId = UE.UserId
WHERE DATEDIFF(DAY, C.DueDate, SYSDATETIME()) = 3 AND
	UE.IsPrimary = 1;