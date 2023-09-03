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


-- 3. Create Update Procedure to edit/modify existing record for City.
CREATE PROCEDURE [dbo].[PR_City_UpdateByPK]
	@CityID		int,
	@CityName	varchar(100),
	@StateID	int,
	@CountryID	int,
	@CityCode	varchar(50)

AS
UPDATE [dbo].[LOC_City]

	SET [dbo].[LOC_City].[CityName] = @CityName,
		[dbo].[LOC_City].[StateID] = @StateID,
		[dbo].[LOC_City].[CountryID] = @CountryID,
		[dbo].[LOC_City].[Citycode] = @CityCode

	WHERE [dbo].[LOC_City].[CityID] = @CityID