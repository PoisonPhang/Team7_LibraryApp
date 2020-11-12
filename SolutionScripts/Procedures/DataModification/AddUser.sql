CREATE OR ALTER PROCEDURE T7Library.AddUser
	@FirstName NVARCHAR(32),
	@LastName NVARCHAR(32),
	@Email NVARCHAR(128),
	@Street NVARCHAR(128),
	@Unit NVARCHAR(16),
	@ZipCode INT,
	@CityName NVARCHAR(128),
    @StateCode NVARCHAR(2)
AS

INSERT T7Library.[User](FirstName, LastName)
VALUES (@FirstName, @LastName)


INSERT T7Library.UserEmail(UserId, Email)
VALUES (IDENT_CURRENT('T7Library.[User]'), @Email)

INSERT T7Library.UserAddress(UserId, StreetAddress, Unit, ZipCode, CityName, StateCode)
VALUES (IDENT_CURRENT('T7Library.[User]'), @Street, @Unit, @ZipCode, @CityName, @StateCode)