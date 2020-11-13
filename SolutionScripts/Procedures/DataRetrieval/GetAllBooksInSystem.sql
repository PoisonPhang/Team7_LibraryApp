CREATE OR ALTER PROCEDURE T7Library.GetAllBooksInSystem
AS
SELECT B.Title, BA.FirstName + N' ' + BA.LastName AS Author, B.Year, B.ISBN, B.Publisher, GC.Genre
FROM T7Library.Book B
INNER JOIN BookAuthor BA ON B.ISBN = BA.ISBN
INNER JOIN GenreCode GC On B.GenreCode = GC.Code