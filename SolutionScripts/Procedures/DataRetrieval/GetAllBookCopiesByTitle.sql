CREATE OR ALTER PROCEDURE T7Library.GetAllBookCopiesByTitle
    @TitlePartial NVARCHAR(32)
AS
SELECT BC.BookId, B.Title, BA.FirstName + ' ' + BA.LastName AS Author, L.StreetAddress + N', ' + L.City + N' ' + L.StateCode AS [Location]
FROM T7Library.BookCopy BC
INNER JOIN T7Library.Book B ON BC.ISBN = B.ISBN
INNER JOIN T7Library.BookAuthor BA ON BC.ISBN = BA.ISBN
INNER JOIN T7Library.[Location] L ON BC.LocationId = L.LocationId
WHERE  B.Title LIKE '%' + @TitlePartial + '%';