CREATE OR ALTER PROCEDURE T7Library.RankBooksByGenre
	@GenreCode INT
AS

IF @GenreCode = 1
BEGIN
SELECT B.ISBN, B.Title, BA.FirstName + ' ' + BA.LastName AS BookAuthor, GC.Genre,DENSE_RANK() OVER(ORDER BY COUNT(C.CheckoutId) DESC) AS [Rank]
FROM T7Library.Book B
INNER JOIN T7Library.BookAuthor BA ON B.ISBN = BA.ISBN
INNER JOIN T7Library.GenreCode GC ON B.GenreCode = GC.Code
INNER JOIN T7Library.BookCopy BC ON B.ISBN = BC.ISBN
INNER JOIN T7Library.Checkout C ON BC.BookId = C.BookId
GROUP BY B.ISBN, B.Title, BA.FirstName + ' ' + BA.LastName, GC.Genre
ORDER BY DENSE_RANK() OVER(ORDER BY COUNT(C.CheckoutId) DESC);
END;

IF @GenreCode <> 1
BEGIN
SELECT B.ISBN, B.Title, BA.FirstName + ' ' + BA.LastName AS BookAuthor, GC.Genre, DENSE_RANK() OVER(ORDER BY COUNT(C.CheckoutId) DESC) AS [RANK]
FROM T7Library.Book B
INNER JOIN T7Library.BookAuthor BA ON B.ISBN = BA.ISBN
INNER JOIN T7Library.GenreCode GC ON B.GenreCode = GC.Code
INNER JOIN T7Library.BookCopy BC ON B.ISBN = BC.ISBN
INNER JOIN T7Library.Checkout C ON BC.BookId = C.BookId
WHERE GC.Code = @GenreCode
GROUP BY B.ISBN, B.Title, BA.FirstName + ' ' + BA.LastName, GC.Genre
ORDER BY DENSE_RANK() OVER(PARTITION BY GC.Genre ORDER BY COUNT(C.CheckoutId) DESC) ASC;
END;
