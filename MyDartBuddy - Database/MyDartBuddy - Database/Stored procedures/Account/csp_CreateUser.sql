CREATE PROCEDURE [Account].[csp_CreateUser]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(200),
	@Email NVARCHAR(200),
	@Password NVARCHAR(200)
AS
BEGIN	
	SET NOCOUNT ON;

	INSERT INTO [Account].[User] (FirstName, LastName, Email, Password) 
	VALUES(@FirstName, @LastName, @Email, @Password)
   
END
GO