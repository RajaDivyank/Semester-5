
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