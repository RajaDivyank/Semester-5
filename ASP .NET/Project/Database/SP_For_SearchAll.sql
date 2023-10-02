
-- PR_Country_Search @CountrySearch = "i"
CREATE or ALTER PROCEDURE [dbo].[PR_Country_Search]
	@CountrySearch  nvarchar(50) = null,
	@CountryCode	nvarchar(50) = null
AS
SELECT [dbo].[LOC_Country].[CountryID]
	  ,[dbo].[LOC_Country].[CountryName]
      ,[dbo].[LOC_Country].[CountryCode]
	  ,[dbo].[LOC_Country].[Created]
	  ,[dbo].[LOC_Country].[Modified]
FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryName] like CONCAT('%',@CountrySearch,'%') AND [dbo].[LOC_Country].[CountryCode] like CONCAT('%',@CountryCode,'%')
ORDER BY [dbo].[LOC_Country].[CountryName]

--[PR_LOC_State_Filter]
Create or alter Procedure [dbo].[PR_LOC_State_Filter]
@StateName varchar(100) = null,
@StateCode varchar(100) = null,
@CountryName varchar(100) = null
as
BEGIN
	Select 
		[dbo].[LOC_State].[StateID],
		[dbo].[LOC_State].[StateName],
		[dbo].[LOC_State].[CountryID],
		[dbo].[LOC_State].[StateCode],
		[dbo].[LOC_State].[Created],
		[dbo].[LOC_Country].[CountryName],

		[dbo].[LOC_State].[Modified]
	from [dbo].[LOC_State]
	INNER JOIN [dbo].[LOC_Country]
	on [dbo].[LOC_State].[CountryID] = [dbo].[LOC_Country].[CountryID]

Where (@StateName is null OR [dbo].[LOC_State].[StateName] like '%'+@StateName+'%')
AND   (@StateCode is null OR [dbo].[LOC_State].[StateCode] like '%'+@StateCode+'%')
AND	  (@CountryName is null OR [dbo].[LOC_Country].[CountryName] like '%'+@CountryName+'%')

ORDER BY [dbo].[LOC_State].[StateID]
END

--FILTER IN CITY 
Create or alter Procedure [dbo].[PR_LOC_City_Filter_CityNameCountryNameStateNameCityCode]
@CityName varchar(50) = null ,
@StateName varchar(50) = null ,
@CountryName varchar(50) = null ,
@CityCode varchar(50) = null 
as
begin
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

Where (@CityName is null OR [dbo].[LOC_City].[CityName] like '%'+@CityName+'%')
AND	  (@StateName is null OR [dbo].[LOC_State].[StateName] like '%'+@StateName+'%')
AND	  (@CountryName is null OR [dbo].[LOC_Country].[CountryName] like '%'+@CountryName+'%')
AND   (@CityCode is null OR [dbo].[LOC_City].[CityCode] like '%'+@CityCode+'%')

ORDER BY [dbo].[LOC_City].[CityID]
end

--FILTER IN BRANCH

Create or Alter Procedure [dbo].[PR_MST_Branch_Filter]
@BranchName varchar(100) = null,
@BranchCode varchar(100) = null
as
Begin
	Select 
		[dbo].[MST_Branch].[BranchID],
		[dbo].[MST_Branch].[BranchName],
		[dbo].[MST_Branch].[BranchCode],
		[dbo].[MST_Branch].[Created],
		[dbo].[MST_Branch].[Modified]
	from [dbo].[MST_Branch]
Where (@BranchName is null OR [dbo].[MST_Branch].[BranchName] like '%'+@BranchName+'%')
AND	  (@BranchCode is null OR [dbo].[MST_Branch].[BranchCode] like '%'+@BranchCode+'%')

ORDER BY [dbo].[MST_Branch].[BranchID]

end

--STUDENT FILTER

CREATE OR ALTER PROCEDURE [dbo].[PR_MST_Student_Filter]
@StudentName varchar(50) = null,
@BranchName  varchar(50) = null,
@CityName    varchar(50) = null,
@Gender      varchar(50) = null
as
Begin
	Select 
		[dbo].[MST_Student].[StudentID],
		[dbo].[MST_Student].[StudentName],
		[dbo].[MST_Student].[MobileNoFather],
		[dbo].[MST_Student].[MobileNoStudent],
		[dbo].[MST_Student].[Address],
		[dbo].[MST_Student].[Email],
		[dbo].[MST_Student].[Age],
		[dbo].[MST_Student].[Gender],
		[dbo].[MST_Student].[IsActive],
		[dbo].[MST_Student].[Password],
		[dbo].[MST_Student].[Created],
		[dbo].[MST_Student].[Modified],
		FORMAT([dbo].[MST_Student].[BirthDate],'dd/MM/yyyy') as BirthDate,
		[dbo].[LOC_City].[CityName],
		[dbo].[MST_Branch].[BranchName]
	
	from [dbo].[MST_Student]
	INNER JOIN [dbo].[LOC_City]
	on [dbo].[MST_Student].[CityID] = [dbo].[LOC_City].[CityID]
	INNER JOIN [dbo].[MST_Branch]
	on [dbo].[MST_Student].[BranchID] = [dbo].[MST_Branch].[BranchID]

	Where (@StudentName is null OR [dbo].[MST_Student].[StudentName] like '%'+@StudentName+'%')
	AND	  (@CityName is null OR [dbo].[LOC_City].[CityName] like '%'+@CityName+'%')
	AND	  (@BranchName is null OR [dbo].[MST_Branch].[BranchName] like '%'+@BranchName+'%')
	AND   (@Gender is null OR [dbo].[MST_Student].[Gender] like '%'+@Gender+'%')

ORDER BY [dbo].[MST_Student].[StudentID]
end