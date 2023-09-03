
-- 1. Create Insert Procedure to add any new record for Country
-- [PR_Country_Insert_Record] @CountryName = 'India', @CountryCode = 'IND'
CREATE PROCEDURE [dbo].[PR_Country_Insert_Record]
	@CountryName	varchar(100),
	@CountryCode	varchar(50)

AS
INSERT INTO [dbo].[LOC_Country]
(
	[dbo].[LOC_Country].[CountryName]
   ,[dbo].[LOC_Country].[CountryCode]
)
VALUES
(
	@CountryName,
	@CountryCode
)


-- 2. Create Insert Procedure to add new record for State.
CREATE PROCEDURE [dbo].[PR_LOC_State_Insert]
	@StateName	varchar(100),
	@CountryID	int,
	@StateCode	varchar(50)

AS
INSERT INTO [dbo].[LOC_State]
(
	[dbo].[LOC_State].[StateName]
   ,[dbo].[LOC_State].[CountryID]
   ,[dbo].[LOC_State].[StateCode]
)
VALUES
(
	@StateName,
	@CountryID,
	@StateCode
)


-- 3. Create Insert Procedure to add new record for City.
CREATE PROCEDURE [dbo].[PR_City_Insert_Record]
	@CityName	varchar(100),
	@StateID	int,
	@CountryID	int,
	@CityCode	varchar(50)

AS
INSERT INTO [dbo].[LOC_City]
(
	[dbo].[LOC_City].[CityName]
   ,[dbo].[LOC_City].[StateID]
   ,[dbo].[LOC_City].[CountryID]
   ,[dbo].[LOC_City].[Citycode]
)
VALUES
(
	@CityName,
	@StateID,
	@CountryID,
	@CityCode
)