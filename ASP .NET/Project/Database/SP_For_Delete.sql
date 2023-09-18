
-- 1. Create Delete Procedure to delete record for Country.
CREATE PROCEDURE [dbo].[PR_Country_DeleteByPK]
	@CountryID	int
AS
	DELETE FROM [dbo].[LOC_Country]
	WHERE [dbo].[LOC_Country].[CountryID] = @CountryID


-- 2. Create Delete Procedure to delete record for State.
Create Procedure [dbo].[PR_LOC_State_Delete]
@StateID int
as
	Delete from [dbo].[LOC_State]
	where [dbo].[LOC_State].[StateID] = @StateID


-- 3. Create Delete Procedure to delete record for City.
Create Procedure [dbo].[PR_LOC_City_DeleteByCityID]
@CityID int
as
	Delete from LOC_City
	where [dbo].[LOC_City].[CityID] = @CityID

--4 StoredProcedure [dbo].[PR_MST_Branch_DeleteByBranchID]
Create Procedure [dbo].[PR_MST_Branch_DeleteByBranchID]
@BranchID int
as
Begin
	Delete from [dbo].[MST_Branch] 
	where [dbo].[MST_Branch].[BranchID] = @BranchID
End