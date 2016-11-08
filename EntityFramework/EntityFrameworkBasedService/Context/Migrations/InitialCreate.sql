IF schema_id('payments') IS NULL
    EXECUTE('CREATE SCHEMA [payments]')

IF(NOT EXISTS(
	SELECT
		T.name,
		S.name 
	FROM sys.tables T
	INNER JOIN sys.schemas S
		ON S.schema_id = T.schema_id
	WHERE 
		T.name = 'Commissions'
		AND S.name = 'payments')
)
BEGIN

	CREATE TABLE [payments].[Commissions]
	(
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[PaymentServiceId] [int] NULL,
		[PointId] [int] NULL,
		[Level]  AS (
			case 
				when PaymentServiceId IS NULL then (0) 
				when PaymentServiceId IS NOT NULL AND [PointId] IS NULL then (1)
				else 2  
			end
		) PERSISTED NOT NULL,
		[CurrencyId] [int] NOT NULL,
		[MinCommission] [money] NULL,
		[Formula] [varchar](4096) NOT NULL,
		[StartDate] [datetime] NOT NULL,
		[EndDate] [datetime] NULL,
		CONSTRAINT [PK_Commissions] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)
	)
END