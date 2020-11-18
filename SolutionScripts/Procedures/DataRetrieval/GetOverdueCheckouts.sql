CREATE OR ALTER PROCEDURE T7Library.GetOverduePenalties
AS
SELECT U.UserId, 
	U.FirstName + N' ' + U.LastName AS UsersName,
	BC.BookId,
	B.ISBN,
	B.Title,
	BA.FirstName + N' ' + BA.LastName AS Author,
	C.DueDate,
	DATEDIFF(DAY, C.DueDate, SYSDATETIME()) AS DaysOverdue,
	CASE
		WHEN DATEDIFF(DAY, C.DueDate, SYSDATETIME()) < 7 THEN 1
		WHEN DATEDIFF(DAY, C.DueDate, SYSDATETIME()) BETWEEN 7 AND 14 THEN 2
		WHEN DATEDIFF(DAY, C.DueDate, SYSDATETIME()) > 15 THEN 4
	END AS PenaltyFee
FROM T7Library.Checkout C
INNER JOIN T7Library.BookCopy BC ON C.BookId = BC.BookId
INNER JOIN T7Library.Book B ON BC.ISBN = B.ISBN
INNER JOIN T7Library.BookAuthor BA ON B.ISBN = BA.ISBN
INNER JOIN T7Library.[User] U ON C.UserId = U.UserId
WHERE DATEDIFF(DAY, C.DueDate, SYSDATETIME()) > 0
ORDER BY U.UserId
