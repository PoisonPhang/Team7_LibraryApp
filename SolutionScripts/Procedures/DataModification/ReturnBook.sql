CREATE OR ALTER PROCEDURE T7Library.ReturnBook
	@BookId INT,
	@LocationId INT
AS

DECLARE @RtrnDate DATE = SYSDATETIME();

UPDATE T7Library.Checkout
SET ReturnDate = @RtrnDate
WHERE BookId = @BookId AND ReturnDate IS NULL;

UPDATE T7Library.BookCopy
SET IsCheckedOut = 0
WHERE BookId = @BookId;

IF ((SELECT BC.LocationId FROM T7Library.BookCopy BC WHERE BC.BookId = @BookId) = @LocationId)
BEGIN
EXEC T7Library.MoveCopy @BookId = @BookId, @LocationId = @LocationId
END;

--DECLARE @BookId INT = 1;
--DECLARE @RtrnDate DATE = SYSDATETIME();
SELECT B.ISBN,
	B.Title,
	BA.FirstName + N' ' + BA.LastName AS Author,
	C.UserId,
	C.DueDate,
	CASE
		WHEN DATEDIFF(DAY, C.DueDate, @RtrnDate) < 0 THEN 0
		WHEN DATEDIFF(DAY, C.DueDate, @RtrnDate) > 0 THEN DATEDIFF(DAY, C.DueDate, @RtrnDate)
	END AS DaysOverdue,
	CASE
		WHEN DATEDIFF(DAY, C.DueDate, @RtrnDate) <= 0 THEN 0
		WHEN DATEDIFF(DAY, C.DueDate, @RtrnDate) < 7 THEN 1
		WHEN DATEDIFF(DAY, C.DueDate, @RtrnDate) BETWEEN 7 AND 14 THEN 2
		WHEN DATEDIFF(DAY, C.DueDate, @RtrnDate) > 15 THEN 3
	END AS PenaltyFee
FROM T7Library.Checkout C
INNER JOIN T7Library.BookCopy BC ON C.BookId = BC.BookId
INNER JOIN T7Library.Book B ON BC.ISBN = B.ISBN
INNER JOIN T7Library.BookAuthor BA ON B.ISBN = BA.ISBN
WHERE C.BookId = @BookId AND C.ReturnDate = @RtrnDate;