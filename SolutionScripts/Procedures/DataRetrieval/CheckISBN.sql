CREATE OR ALTER PROCEDURE T7Library.CheckISBN
    @ISBN NVARCHAR(13)
AS
SELECT ISBN, Title, GenreCode, Publisher, [Year]
FROM T7Library.Book
WHERE ISBN = @ISBN;