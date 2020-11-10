USE [Database];

IF NOT EXISTS ( SELECT  *
                FROM    sys.schemas
                WHERE   name = N'T7Library' )
    EXEC('CREATE SCHEMA [T7Library]');

ALTER DATABASE [Database]
SET
   ANSI_NULLS ON,
   ANSI_PADDING ON,
   ANSI_WARNINGS ON,
   ARITHABORT ON,
   AUTO_CLOSE OFF,
   AUTO_CREATE_STATISTICS ON,
   AUTO_SHRINK OFF,
   AUTO_UPDATE_STATISTICS ON,
   CONCAT_NULL_YIELDS_NULL ON,
   NUMERIC_ROUNDABORT OFF,
   QUOTED_IDENTIFIER OFF,
   RECURSIVE_TRIGGERS OFF,
   ALLOW_SNAPSHOT_ISOLATION ON,
   RECOVERY SIMPLE;

DROP TABLE IF EXISTS T7Library.Checkout;
DROP TABLE IF EXISTS T7Library.UserAddress;
DROP TABLE IF EXISTS T7Library.UserEmail;
DROP TABLE IF EXISTS T7Library.[User];
DROP TABLE IF EXISTS T7Library.BookCopy;
DROP TABLE IF EXISTS T7Library.BookAuthor;
DROP TABLE IF EXISTS T7Library.Book;
DROP TABLE IF EXISTS T7Library.[Location];
DROP TABLE IF EXISTS T7Library.Librarian;
DROP TABLE IF EXISTS T7Library.GenreCode;

IF OBJECT_ID(N'T7Library.GenreCode') IS NULL
BEGIN
	CREATE TABLE T7Library.GenreCode (
		Code INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		Genre NVARCHAR(32) NOT NULL
	);
END;

INSERT T7Library.GenreCode(Genre)
VALUES (N'All Genres');

IF OBJECT_ID(N'T7Library.Librarian') IS NULL
BEGIN
	CREATE TABLE T7Library.Librarian (
		Username NVARCHAR(32) NOT NULL PRIMARY KEY,
		PasswordHash NVARCHAR(128) NOT NULL,
		FirstName NVARCHAR(32) NOT NULL,
		LastName NVARCHAR(32) NOT NULL,
		StartDate DATE NOT NULL,
		EndDate Date
	);
END;

IF OBJECT_ID(N'T7Library.Location') IS NULL
BEGIN
	CREATE TABLE T7Library.[Location] (
		LocationId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		StreetAddress NVARCHAR(128) NOT NULL,
		Unit NVARCHAR(16),
		ZipCode INT NOT NULL,
		CityName NVARCHAR(128) NOT NULL,
		StateCode NVARCHAR(2) NOT NULL
	);
END;

IF OBJECT_ID(N'T7Library.Book') IS NULL
BEGIN
	CREATE TABLE T7Library.Book (
		ISBN NVARCHAR(13) NOT NULL PRIMARY KEY,
		Title NVARCHAR(256) NOT NULL,
		GenreCode INT NOT NULL FOREIGN KEY
			REFERENCES T7Library.GenreCode,
		Publisher NVARCHAR(32) NOT NULL,
		[Year] INT NOT NULL
	);
END;

IF OBJECT_ID(N'T7Library.BookAuthor') IS NULL
BEGIN
	CREATE TABLE T7Library.BookAuthor (
		FirstName NVARCHAR(32) NOT NULL,
		LastName NVARCHAR(32) NOT NULL,
		ISBN NVARCHAR(13) NOT NULL FOREIGN KEY
			REFERENCES T7Library.Book,

		UNIQUE (FirstName, LastName, ISBN)
	);
END;

IF OBJECT_ID(N'T7Library.BookCopy') IS NULL
BEGIN
	CREATE TABLE T7Library.BookCopy (
		BookId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		ISBN NVARCHAR(13) NOT NULL FOREIGN KEY
			REFERENCES T7Library.Book,
		LocationId INT NOT NULL FOREIGN KEY
			REFERENCES T7Library.[Location],
		IsOutOfService TINYINT NOT NULL
	);
END;

IF OBJECT_ID(N'T7Library.User') IS NULL
BEGIN
	CREATE TABLE T7Library.[User] (
		UserId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		FirstName NVARCHAR(32) NOT NULL,
		LastName NVARCHAR(32) NOT NULL,
	);
END;

IF OBJECT_ID(N'T7Library.UserEmail') IS NULL
BEGIN
	CREATE TABLE T7Library.UserEmail (
		UserId INT NOT NULL FOREIGN KEY
			REFERENCES T7Library.[User],
		Email NVARCHAR(128) NOT NULL,
		IsPrimary TINYINT NOT NULL,

		UNIQUE (UserId, Email)
	);
END;

IF OBJECT_ID(N'T7Library.UserAddress') IS NULL
BEGIN
	CREATE TABLE T7Library.UserAddress (
		UserId INT NOT NULL PRIMARY KEY FOREIGN KEY
			REFERENCES T7Library.[User],
		StreetAddress NVARCHAR(128) NOT NULL,
		Unit NVARCHAR(16),
		ZipCode INT NOT NULL,
		CityName NVARCHAR(128) NOT NULL,
		StateCode NVARCHAR(2) NOT NULL,
		IsPrimary TINYINT NOT NULL
	);
END;

IF OBJECT_ID(N'T7Library.Checkout') IS NULL
BEGIN
	CREATE TABLE T7Library.Checkout (
		CheckoutId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		BookId INT NOT NULL FOREIGN KEY
			REFERENCES T7Library.BookCopy,
		UserId INT NOT NULL FOREIGN KEY
			REFERENCES T7Library.[User],
		LocationId INT NOT NULL FOREIGN KEY
			REFERENCES T7Library.[Location],
		LibrarianId NVARCHAR(32) NOT NULL FOREIGN KEY
			REFERENCES T7Library.Librarian,
		OutDate DATE NOT NULL,
		DueDate Date NOT NULL,
		ReturnDate Date NOT NULL
	);
END;
