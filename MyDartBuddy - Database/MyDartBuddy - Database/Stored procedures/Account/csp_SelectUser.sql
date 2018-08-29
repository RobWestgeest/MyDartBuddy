CREATE PROCEDURE [Account].[csp_SelectUser]	
	@Email NVARCHAR(200)
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT 
		Id, 
		FirstName, 
		LastName, 
		Email, 
		Password
	FROM [Account].[User]
	WHERE Email =  @Email
   
END
GO