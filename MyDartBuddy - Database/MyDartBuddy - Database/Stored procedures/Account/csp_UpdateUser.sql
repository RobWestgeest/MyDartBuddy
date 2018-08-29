CREATE PROCEDURE [Account].[csp_UpdateUser]
	@Id UNIQUEIDENTIFIER,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(200),
	@Email NVARCHAR(200),
	@Password NVARCHAR(200)
AS
BEGIN	
	SET NOCOUNT ON;

	UPDATE [Account].[User] 
	SET FirstName = @FirstName, 
	LastName= @LastName, 
	Email = @Email, 
	Password = @Password
	WHERE Id = @Id
   
END
GO