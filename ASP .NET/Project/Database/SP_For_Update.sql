-- 1. Create Update Procedure to edit/modeify existing record for Country.
CREATE PROCEDURE [dbo].[PR_Country_UpdateByPK]
	@CountryID		int,
	@CountryName	varchar(100),
	@CountryCode	varchar(50)
AS
UPDATE [dbo].[LOC_Country]
	
	SET [dbo].[LOC_Country].[CountryName] = @CountryName,
		[dbo].[LOC_Country].[CountryCode] = @CountryCode

	WHERE [dbo].[LOC_Country].[CountryID] = @CountryID


-- 2. Create Update Procedure to edit/modify existing record for State.
Create   Procedure [dbo].[PR_LOC_State_Update]
@StateID    int,
@StateName	varchar(100),
@CountryID  int,
@StateCode	varchar(50)
as
	Update [dbo].[LOC_State]
	set
		[dbo].[LOC_State].[StateName] = @StateName,
		[dbo].[LOC_State].[CountryID] = @CountryID,
		[dbo].[LOC_State].[StateCode] = @StateCode,
		[dbo].[LOC_State].[Created] = (Select [dbo].[Loc_State].[Created] from [dbo].[Loc_State] where [dbo].[Loc_State].[StateID] = @StateID),
		[dbo].[LOC_State].[Modified] = GETDATE()
	where [dbo].[LOC_State].[StateID] = @StateID


-- 3. StoredProcedure [dbo].[PR_LOC_City_Update].
Create   Procedure [dbo].[PR_LOC_City_Update]
@CityID int,
@CityName varchar(100),
@CityCode varchar(50),
@StateID int,
@CountryID int
as
	Update LOC_City 
	set
		[dbo].[LOC_City].[CityName] = @CityName,
		[dbo].[LOC_City].[CityCode] = @CityCode,
		[dbo].[LOC_City].[StateID] = @StateID,
		[dbo].[LOC_City].[CountryID] = @CountryID,
		[dbo].[LOC_City].[Modified] = GETDATE()
	where [dbo].[LOC_City].[CityID] = @CityID

--4 StoredProcedure [dbo].[PR_MST_Branch_UpdateByBranchID]
CREATE   Procedure [dbo].[PR_MST_Branch_UpdateByBranchID]
@BranchID	int,
@BranchName varchar(100),
@BranchCode varchar(100),
@Created datetime = null,
@Modified datetime = null
as
Begin
	Update [dbo].[MST_Branch] set
		[dbo].[MST_Branch].[BranchCode] = @BranchCode,
		[dbo].[MST_Branch].[BranchName] = @BranchName,
		[dbo].[MST_Branch].[Created] = ISNULL(@Created,GetDate()),
		[dbo].[MST_Branch].[Modified] = ISNULL(@Modified,GETDATE())
	where [dbo].[MST_Branch].[BranchID] = @BranchID
End