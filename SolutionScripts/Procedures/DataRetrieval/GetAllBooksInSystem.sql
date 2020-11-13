CREATE OR ALTER PROCEDURE T7Library.GetAllBooksInSystem
AS
SELECT B.Title, BA.FirstName + N' ' + BA.LastName AS Author, B.Year, B.ISBN, B.Publisher, GC.Genre
FROM T7Library.Book B
INNER JOIN T7Library.BookAuthor BA ON B.ISBN = BA.ISBN
INNER JOIN T7Library.GenreCode GC On B.GenreCode = GC.Code;