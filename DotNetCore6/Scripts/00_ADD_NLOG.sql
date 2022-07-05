
GO
IF NOT EXISTS ( SELECT  *
                FROM    sys.schemas
                WHERE   name = N'NLog' )
    EXEC('CREATE SCHEMA [NLog]');
GO
  SET ANSI_NULLS ON
  SET QUOTED_IDENTIFIER ON
  CREATE TABLE [Nlog].[ExceptionLog] (
      [ID] [int] IDENTITY(1,1) NOT NULL,
      [MachineName] [nvarchar](50) NOT NULL,
      [Logged] [datetime] NOT NULL,
      [Level] [nvarchar](50) NOT NULL,
      [Message] [nvarchar](max) NOT NULL,
      [Logger] [nvarchar](250) NULL,
      [Callsite] [nvarchar](max) NULL,
	  [Properties] [nvarchar](max) NULL,
      [Exception] [nvarchar](max) NULL,
	  [URL] [nvarchar](300) NULL,
	  [UserAgent] [nvarchar](300) NULL,
	  [IP] [nvarchar](300) NULL,
    CONSTRAINT [PK_dbo.ExceptionLog] PRIMARY KEY CLUSTERED ([ID] ASC)
      WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  
GO

/****** Object:  StoredProcedure [dbo].[NLog_AddEntry_p]    Script Date: 4/22/2021 10:09:34 PM ******/

create PROCEDURE [NLog].[NLog_Add] (
  @machineName nvarchar(200),
  @logged datetime,
  @level varchar(5),
  @message nvarchar(max),
  @logger nvarchar(300),
  @properties nvarchar(max),
  @callsite nvarchar(300),
  @exception nvarchar(max),
  @url nvarchar(300),
  @remoteAddress nvarchar(300),
  @useragent nvarchar(300)

) AS
BEGIN
  INSERT INTO [Nlog].[ExceptionLog] (
    [MachineName],
    [Logged],
    [Level],
    [Message],
    [Logger],
    [Properties],
    [Callsite],
    [Exception]
	,[URL],
	[IP],
	[UserAgent]
  ) VALUES (
    @machineName,
    @logged,
    @level,
    @message,
    @logger,
    @properties,
    @callsite,
    @exception,
	@url,
	@remoteAddress,
	@useragent

  );
END
GO


