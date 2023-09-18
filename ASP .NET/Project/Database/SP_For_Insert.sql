
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


-- 3. StoredProcedure [dbo].[PR_LOC_City_Insert]
Create   Procedure [dbo].[PR_LOC_City_Insert]
@CityName varchar(100),
@CityCode varchar(50),
@StateID int,
@CountryID int
as
	Insert into LOC_City
	(
		[dbo].[LOC_City].[CityName],
		[dbo].[LOC_City].[CityCode],
		[dbo].[LOC_City].[StateID],
		[dbo].[LOC_City].[CountryID],
		[dbo].[LOC_City].[CreationDate],
		[dbo].[LOC_City].[Modified]
	)
	values
	(
		@CityName,
		@CityCode,
		@StateID,
		@CountryID,
		GETDATE(),
		GETDATE()
	)

--4 StoredProcedure [dbo].[PR_MST_Branch_Insert]
CREATE Procedure [dbo].[PR_MST_Branch_Insert]
@BranchName varchar(100),
@BranchCode varchar(100),
@Created	datetime = null,
@Modified	datetime = null
as
	Insert into [dbo].[MST_Branch]
	(
		[dbo].[MST_Branch].[BranchName],
		[dbo].[MST_Branch].[BranchCode],
		[dbo].[MST_Branch].[Created],
		[dbo].[MST_Branch].[Modified]
	)
	values
	(
		@BranchName,
		@BranchCode,
		ISNULL(@Created, GETDATE()),
		ISNULL(@Modified, GETDATE())
	)