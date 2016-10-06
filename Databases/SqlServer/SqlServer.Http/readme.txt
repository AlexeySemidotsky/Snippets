ALTER database [Tools] SET TRUSTWORTHY ON;

sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO

sp_configure 'clr enabled', 1;
GO
RECONFIGURE;
GO

sp_configure 'show advanced options', 0;
GO
RECONFIGURE;
GO

GRANT EXTERNAL ACCESS ASSEMBLY TO [domain\petrov]; 

/* 

Call example

DECLARE @result NVARCHAR(4000)

EXEC [dbo].[SendHttpRequest] 
	'http://server/api/process',
	'POST',
	'Content-Type=application/json;Accept=application/json',
	'{
		"Name":"Semidotsky",
		"Model": { "Properties": [{"Name":"Title", "Value": "Report"}, {"Name":"Result", "Value": "Ошибка"}] },
	 }', 
	@result output

*/