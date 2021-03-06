USE [NBA]
GO
/****** Object:  Table [dbo].[DepthChart]    Script Date: 6/22/2020 12:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepthChart](
	[DepthChartID] [int] IDENTITY(1,1) NOT NULL,
	[teamName] [nvarchar](150) NULL,
	[Position] [nvarchar](10) NULL,
	[Starter] [nvarchar](10) NULL,
	[2nd] [nvarchar](10) NULL,
	[3rd] [nvarchar](10) NULL,
	[4th] [nvarchar](10) NULL,
	[5th] [nvarchar](10) NULL,
	[DateAdded] [datetime] NOT NULL,
	[RowGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_DepthChart] PRIMARY KEY CLUSTERED 
(
	[DepthChartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NBAStanding]    Script Date: 6/22/2020 12:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBAStanding](
	[NBAStandingID] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [nvarchar](150) NULL,
	[W] [int] NULL,
	[L] [int] NULL,
	[PCT] [float] NULL,
	[GB] [int] NULL,
	[HomeWin] [nchar](10) NULL,
	[HomeLoss] [nchar](10) NULL,
	[AwayWin] [nchar](10) NULL,
	[AwayLoss] [nchar](10) NULL,
	[DIVWin] [nchar](10) NULL,
	[DIVLoss] [nchar](10) NULL,
	[CONFWin] [nchar](10) NULL,
	[CONFLoss] [nchar](10) NULL,
	[PPG] [nchar](10) NULL,
	[OPP_PPG] [nchar](10) NULL,
	[DIFF] [nchar](10) NULL,
	[STRK] [nchar](10) NULL,
	[L10] [nchar](10) NULL,
	[DateAdded] [datetime] NOT NULL,
	[RowGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_NBAStanding] PRIMARY KEY CLUSTERED 
(
	[NBAStandingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Player]    Script Date: 6/22/2020 12:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[PlayerID] [int] IDENTITY(1,1) NOT NULL,
	[playerFName] [nvarchar](100) NULL,
	[playerMName] [nvarchar](100) NULL,
	[playerLName] [nvarchar](100) NULL,
	[jerseyNumber] [nvarchar](20) NULL,
	[Position] [nchar](2) NULL,
	[Age] [int] NULL,
	[Weight] [int] NULL,
	[Height] [nvarchar](10) NULL,
	[College] [nvarchar](250) NULL,
	[Salary] [decimal](18, 2) NULL,
	[TeamName] [nvarchar](250) NULL,
	[DateAdded] [datetime] NOT NULL,
	[RowGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stat]    Script Date: 6/22/2020 12:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stat](
	[StatID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[TeamName] [varchar](150) NULL,
	[MidseasonTrades] [bit] NULL,
	[GamesPlayed] [varchar](1) NULL,
	[GamesStarted] [varchar](1) NULL,
	[MinutesperGame] [varchar](1) NULL,
	[PointsperGame] [varchar](1) NULL,
	[OffensiveReboundsPerGame] [varchar](1) NULL,
	[DefensiveReboundsPerGame] [varchar](1) NULL,
	[ReboundsPerGame] [varchar](1) NULL,
	[AssistsPerGame] [varchar](1) NULL,
	[StealsPerGame] [varchar](1) NULL,
	[BlocksPerGame] [varchar](1) NULL,
	[TurnOversPerGame] [varchar](1) NULL,
	[FoulsPerGame] [varchar](1) NULL,
	[PlayerEfficiencyRating] [varchar](1) NULL,
	[AverageFieldGoalsMade] [varchar](1) NULL,
	[AverageFieldGoalsAttempted] [varchar](1) NULL,
	[AverageFreeThrowsAttempted] [varchar](1) NULL,
	[FieldGoalPercentage] [varchar](1) NULL,
	[Average3PointFieldGoalsMade] [varchar](1) NULL,
	[Average3PointFieldGoalsAttempted] [varchar](1) NULL,
	[ThreePointFieldGoalPercentage] [varchar](1) NULL,
	[AverageFreeThrowsMade] [varchar](1) NULL,
	[FreeThrowPercentage] [varchar](1) NULL,
	[TwoPointFieldGoalsMadePerGame] [varchar](1) NULL,
	[TwoPointFieldGoalsAttemptedPerGame] [varchar](1) NULL,
	[TwoPointFieldGoalPercentage] [varchar](1) NULL,
	[ScoringEfficiency] [varchar](1) NULL,
	[ShootingEfficiency] [varchar](1) NULL,
	[DateAdded] [datetime] NOT NULL,
	[RowID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Stat] PRIMARY KEY CLUSTERED 
(
	[StatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DepthChart] ADD  CONSTRAINT [DF_DepthChart_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[DepthChart] ADD  CONSTRAINT [DF_DepthChart_RowGuid]  DEFAULT (newid()) FOR [RowGuid]
GO
ALTER TABLE [dbo].[NBAStanding] ADD  CONSTRAINT [DF_NBAStanding_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[NBAStanding] ADD  CONSTRAINT [DF_NBAStanding_RowGuid]  DEFAULT (newid()) FOR [RowGuid]
GO
ALTER TABLE [dbo].[Player] ADD  CONSTRAINT [DF_Player_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[Player] ADD  CONSTRAINT [DF_Player_RowGuid]  DEFAULT (newid()) FOR [RowGuid]
GO
ALTER TABLE [dbo].[Stat] ADD  CONSTRAINT [DF_Stat_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[Stat] ADD  CONSTRAINT [DF_Stat_RowID]  DEFAULT (newid()) FOR [RowID]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertDepthChart]    Script Date: 6/22/2020 12:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IshtiaqKasem
-- Create date: 6-21-2020
-- Description:	Hydrates the DepthChart table
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertDepthChart] 
	@teamName NVarChar(150),
	@Position NVarChar(10),
	@Starter NVarChar(10),
	@2nd NVarChar(10),
	@3rd NVarChar(10),
	@4th NVarChar(10),
	@5th NVarChar(10)
AS
BEGIN
	Insert DepthChart
	(
	teamName,
Position,
Starter,
[2nd],
[3rd],
[4th],
[5th]
)
Values
(
@teamName,
@Position,
@Starter,
@2nd,
@3rd,
@4th,
@5th)

END

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertNBAStanding]    Script Date: 6/22/2020 12:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ishtiaq Kasem
-- Create date: 6-21-2020
-- Description:	Hydrates the NBAStanding table
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertNBAStanding] 
	@TeamName NVarChar(150),
	@W Int,
	@L Int,
	@PCT Float,
	@GB Int,
	@HomeWin NChar(10),
	@HomeLoss NChar(10),
	@AwayWin NChar(10),
	@AwayLoss NChar(10),
	@DIVWin NChar(10),
	@DIVLoss NChar(10),
	@CONFWin NChar(10),
	@CONFLoss NChar(10),
	@PPG NChar(10),
	@OPP_PPG NChar(10),
	@DIFF NChar(10),
	@STRK NChar(10),
	@L10 NChar(10)
AS
BEGIN
	Insert NBAStanding
	(TeamName,
		W,
		L,
		PCT,
		GB,
		HomeWin,
		HomeLoss,
		AwayWin,
		AwayLoss,
		DIVWin,
		DIVLoss,
		CONFWin,
		CONFLoss,
		PPG,
		OPP_PPG,
		DIFF,
		STRK,
		L10)
		values
		(@TeamName,
			@W,
			@L,
			@PCT,
			@GB,
			@HomeWin,
			@HomeLoss,
			@AwayWin,
			@AwayLoss,
			@DIVWin,
			@DIVLoss,
			@CONFWin,
			@CONFLoss,
			@PPG,
			@OPP_PPG,
			@DIFF,
			@STRK,
			@L10)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPlayer]    Script Date: 6/22/2020 12:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ishtiaq Kasem
-- Create date: 6-21-2020
-- Description:	hydrates the Player table
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertPlayer] 
	-- Add the parameters for the stored procedure here
	@playerFName NVarChar(100),
	@playerMName NVarChar(100),
	@playerLName NVarChar(100),
	@jerseyNumber VarChar(20),
	@Position NChar(2),
	@Age Int,
	@Weight Int,
	@Height NVarChar(10),
	@College NVarChar(250),
	@Salary Decimal(18,2),
	@TeamName NVarChar(250)
AS
BEGIN
	INSERT Player
	(playerFName,
		playerMName,
		playerLName,
		jerseyNumber,
		Position,
		Age,
		[Weight],
		Height,
		College,
		Salary,
		TeamName)
	values
	(@playerFName,
		@playerMName,
		@playerLName,
		@jerseyNumber,
		@Position,
		@Age,
		@Weight,
		@Height,
		@College,
		@Salary,
		@TeamName)
	
END

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertStat]    Script Date: 6/22/2020 12:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ishtiaq Kasem
-- Create date: 6-21-2020
-- Description:	Hydrates the STAT table
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertStat] 
	@Name VarChar(50),
	@TeamName VarChar(150),
	@MidseasonTrades Bit,
	@GamesPlayed VarChar,
	@GamesStarted VarChar,
	@MinutesperGame VarChar,
	@PointsperGame VarChar,
	@OffensiveReboundsPerGame VarChar,
	@DefensiveReboundsPerGame VarChar,
	@ReboundsPerGame VarChar,
	@AssistsPerGame VarChar,
	@StealsPerGame VarChar,
	@BlocksPerGame VarChar,
	@TurnOversPerGame VarChar,
	@FoulsPerGame VarChar,
	@PlayerEfficiencyRating VarChar,
	@AverageFieldGoalsMade VarChar,
	@AverageFieldGoalsAttempted VarChar,
	@AverageFreeThrowsAttempted VarChar,
	@FieldGoalPercentage VarChar,
	@Average3PointFieldGoalsMade VarChar,
	@Average3PointFieldGoalsAttempted VarChar,
	@ThreePointFieldGoalPercentage VarChar,
	@AverageFreeThrowsMade VarChar,
	@FreeThrowPercentage VarChar,
	@TwoPointFieldGoalsMadePerGame VarChar,
	@TwoPointFieldGoalsAttemptedPerGame VarChar,
	@TwoPointFieldGoalPercentage VarChar,
	@ScoringEfficiency VarChar,
	@ShootingEfficiency VarChar
AS
BEGIN

Insert STAT
([Name],
TeamName,
MidseasonTrades,
GamesPlayed,
GamesStarted,
MinutesperGame,
PointsperGame,
OffensiveReboundsPerGame,
DefensiveReboundsPerGame,
ReboundsPerGame,
AssistsPerGame,
StealsPerGame,
BlocksPerGame,
TurnOversPerGame,
FoulsPerGame,
PlayerEfficiencyRating,
AverageFieldGoalsMade,
AverageFieldGoalsAttempted,
AverageFreeThrowsAttempted,
FieldGoalPercentage,
Average3PointFieldGoalsMade,
Average3PointFieldGoalsAttempted,
ThreePointFieldGoalPercentage,
AverageFreeThrowsMade,
FreeThrowPercentage,
TwoPointFieldGoalsMadePerGame,
TwoPointFieldGoalsAttemptedPerGame,
TwoPointFieldGoalPercentage,
ScoringEfficiency,
ShootingEfficiency
)
Values
(@Name,
@TeamName,
@MidseasonTrades,
@GamesPlayed,
@GamesStarted,
@MinutesperGame,
@PointsperGame,
@OffensiveReboundsPerGame,
@DefensiveReboundsPerGame,
@ReboundsPerGame,
@AssistsPerGame,
@StealsPerGame,
@BlocksPerGame,
@TurnOversPerGame,
@FoulsPerGame,
@PlayerEfficiencyRating,
@AverageFieldGoalsMade,
@AverageFieldGoalsAttempted,
@AverageFreeThrowsAttempted,
@FieldGoalPercentage,
@Average3PointFieldGoalsMade,
@Average3PointFieldGoalsAttempted,
@ThreePointFieldGoalPercentage,
@AverageFreeThrowsMade,
@FreeThrowPercentage,
@TwoPointFieldGoalsMadePerGame,
@TwoPointFieldGoalsAttemptedPerGame,
@TwoPointFieldGoalPercentage,
@ScoringEfficiency,
@ShootingEfficiency
)

END

GO
