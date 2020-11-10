CREATE OR ALTER PROCEDURE T7Library.RankLibraries
	@StartDate DATE,
	@EndDate DATE
AS
SELECT L.StreetAddress, COUNT(DISTINCT C.CheckoutId) AS Checkouts, RANK() OVER(ORDER BY COUNT(DISTINCT C.CheckoutId)) AS [Rank]
FROM T7Library.[Location] L
INNER JOIN T7Library.Checkout C ON L.LocationId = C.LocationId
GROUP BY L.LocationId
ORDER BY RANK() OVER(ORDER BY COUNT(DISTINCT C.CheckoutId)) DESC