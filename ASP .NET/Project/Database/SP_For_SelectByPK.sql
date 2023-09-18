
-- 1. Create Procedure for Select Country by PK
CREATE PROCEDURE [dbo].[PR_Country_SelectByPK]
	@CountryID int
AS

SELECT [dbo].[LOC_Country].[CountryName]
	  ,[dbo].[LOC_Country].[CountryName]
      ,[dbo].[LOC_Country].[CountryCode]
	  ,[dbo].[LOC_Country].[Created]
	  ,[dbo].[LOC_Country].[Modified]

FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryID] = @CountryID
ORDER BY [dbo].[LOC_Country].[CountryName]


-- 2. Create Procedure for Select State by PK
Create Procedure [dbo].[PR_LOC_State_SelectByStateID]
@StateID int
as
	Select 
		[dbo].[LOC_State].[StateID],
		[dbo].[LOC_State].[StateName],
		[dbo].[LOC_State].[CountryID],
		[dbo].[LOC_State].[StateCode],
		[dbo].[LOC_State].[Created],
		[dbo].[LOC_State].[Modified]
	from [dbo].[LOC_State]

	where [dbo].[LOC_State].[StateID] = @StateID
ORDER BY  [dbo].[LOC_State].[StateName]


-- 3. Create Procedure for Select City by PK
Create   PROCEDURE [dbo].[PR_LOC_City_Select_By_PrimaryKey]
@CityID int
as
	Select 
		[dbo].[LOC_City].[CityID],
		[dbo].[LOC_City].[Citycode],
		[dbo].[LOC_City].[CityName],
		[dbo].[LOC_City].[StateID],
		[dbo].[LOC_City].[CreationDate],
		[dbo].[LOC_City].[Modified],
		[dbo].[LOC_City].[CountryID],
		[dbo].[LOC_State].[StateName],
		[dbo].[LOC_Country].[CountryName]
	from [dbo].[LOC_City] 

	INNER JOIN [dbo].[LOC_State]
	on [dbo].[LOC_City].[StateID] = [dbo].[LOC_State].[StateID]

	INNER JOIN [dbo].[LOC_Country]
	on [dbo].[LOC_City].[CountryID] = [dbo].[LOC_Country].[CountryID]

	where [dbo].[LOC_City].[CityID] = @CityID
ORDER BY [dbo].[LOC_Country].[CountryName]
        ,[dbo].[LOC_State].[StateName]
		,[dbo].[LOC_City].[CityName]

--4 StoredProcedure [dbo].[PR_MST_Branch_SelectByBranchID]
Create Procedure [dbo].[PR_MST_Branch_SelectByBranchID]
@branchID int
as
Begin
	Select 
		[dbo].[MST_Branch].[BranchID],
		[dbo].[MST_Branch].[BranchName],
		[dbo].[MST_Branch].[BranchCode],
		[dbo].[MST_Branch].[Created],
		[dbo].[MST_Branch].[Modified]
	from [dbo].[MST_Branch]

	where [dbo].[MST_Branch].[BranchID]=@branchID
End

