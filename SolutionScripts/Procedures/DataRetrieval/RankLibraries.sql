CREATE OR ALTER PROCEDURE T7Library.RankLibraries
	@StartDate DATE,
	@EndDate DATE
AS
SELECT L.LocationId, L.StreetAddress + N', ' + L.City + N' ' + L.StateCode AS [Location], COUNT(DISTINCT C.CheckoutId) AS Checkouts, RANK() OVER(ORDER BY COUNT(DISTINCT C.CheckoutId) DESC) AS [Rank]
FROM T7Library.[Location] L
INNER JOIN T7Library.Checkout C ON L.LocationId = C.LocationId
WHERE C.OutDate BETWEEN @StartDate AND @EndDate
GROUP BY L.LocationId, L.StreetAddress + N', ' + L.City + N' ' + L.StateCode
ORDER BY RANK() OVER(ORDER BY COUNT(DISTINCT C.CheckoutId) DESC);