CREATE OR ALTER PROCEDURE T7Library.GetBookCopiesPerLocation
	@ISBN NVARCHAR(13)
AS

SELECT B.Title, BA.FirstName + N' ' + BA.LastName as Author, L.LocationId, L.StreetAddress + N', ' + L.CityName + N' ' + L.StateCode AS [Location], COUNT(DISTINCT BC.BookId) AS AvailableCopies 
FROM T7Library.BookCopy BC
INNER JOIN T7Library.Book B ON BC.ISBN = B.ISBN
INNER JOIN T7Library.BookAuthor BA ON BC.ISBN = BA.ISBN
INNER JOIN T7Library.[Location] L ON BC.LocationId = L.LocationId
WHERE BC.IsCheckedOut = 0 AND BC.IsOutOfService = 0
GROUP BY BC.LocationId, BC.ISBN