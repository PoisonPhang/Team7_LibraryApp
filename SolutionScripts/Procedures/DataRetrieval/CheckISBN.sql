CREATE OR ALTER PROCEDURE T7Library.CheckISBN
    @ISBN NVARCHAR(13)
AS
SELECT B.ISBN, B.Title, B.GenreCode, B.Publisher, B.[Year], BA.FirstName + ' ' + BA.LastName AS Author
FROM T7Library.Book B
INNER JOIN T7Library.BookAuthor BA ON B.ISBN = BA.ISBN
WHERE B.ISBN = @ISBN;