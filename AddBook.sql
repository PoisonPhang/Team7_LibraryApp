CREATE OR ALTER PROCEDURE T7Library.AddBook
	@Title NVARCHAR(256),
	@Publisher NVARCHAR(32),
	@ISBN INT,
	@Year INT,
	@Genre NVARCHAR(32),
	@AuthorFirstName NVARCHAR(32),
	@AuthorLastName NVARCHAR(32)
AS

IF (@Genre NOT IN (SELECT Genre FROM T7Library.GenreCode))
BEGIN
INSERT T7Library.GenreCode (Genre)
VALUES(@Genre)
END;

INSERT T7Library.Book(ISBN, Title, GenreCode, Publisher, [Year])
VALUES (@ISBN, @Title, (SELECT GC.Code FROM GenreCode GC WHERE GC.Genre = @Genre), @Publisher, @Year);

INSERT T7Library.BookAuthor (FirstName, LastName, ISBN)
VALUES (@AuthorFirstName, @AuthorLastName, @ISBN);