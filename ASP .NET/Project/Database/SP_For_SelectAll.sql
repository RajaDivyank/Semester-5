-- 1. StoredProcedure [dbo].[PR_Country_SelectAll]
CREATE PROCEDURE [dbo].[PR_Country_SelectAll]
AS

SELECT [dbo].[LOC_Country].[CountryID]
	  ,[dbo].[LOC_Country].[CountryName]
      ,[dbo].[LOC_Country].[CountryCode]
	  ,[dbo].[LOC_Country].[Created]
	  ,[dbo].[LOC_Country].[Modified]

FROM [dbo].[LOC_Country]
ORDER BY [dbo].[LOC_Country].[CountryName]


-- 2. StoredProcedure [dbo].[PR_LOC_State_SelectAll]
Create   Procedure [dbo].[PR_LOC_State_SelectAll]
as
	Select 
		[dbo].[LOC_State].[StateID],
		[dbo].[LOC_State].[StateName],
		[dbo].[LOC_State].[CountryID],
		[dbo].[LOC_State].[StateCode],
		[dbo].[LOC_State].[Created],
		[dbo].[LOC_State].[Modified],
		[dbo].[LOC_Country].[CountryName]
	from [dbo].[LOC_State]

	INNER JOIN [dbo].[LOC_Country]
	on [dbo].[LOC_State].[CountryID] = [dbo].[LOC_Country].[CountryID]
ORDER BY [dbo].[LOC_Country].[CountryName]
        ,[dbo].[LOC_State].[StateName]


-- 3. StoredProcedure [dbo].[PR_LOC_City_SelectAll]
Create   Procedure [dbo].[PR_LOC_City_SelectAll]
as
select 
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
ORDER BY [dbo].[LOC_Country].[CountryName]
        ,[dbo].[LOC_State].[StateName]
		,[dbo].[LOC_City].[CityName]

--4 StoredProcedure [dbo].[PR_MST_Branch_SelectAll]
Create Procedure [dbo].[PR_MST_Branch_SelectAll]
as
	Select 
		[dbo].[MST_Branch].[BranchID],
		[dbo].[MST_Branch].[BranchName],
		[dbo].[MST_Branch].[BranchCode],
		[dbo].[MST_Branch].[Created],
		[dbo].[MST_Branch].[Modified]
	from [dbo].[MST_Branch]
ORDER BY [dbo].[MST_Branch].[BranchName]
