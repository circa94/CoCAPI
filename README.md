# Welcome to CoCAPI!

 **CoCAPI** is a cross-platform, ready to use implementation of the Clash of Clans REST API for .NET
 It is still in development and not all features are implemented, yet. 


# Current features
**Players**
 - [x] Player search by player tag
 
 **Clans**
 
 - [x] Search all clans
 - [x] Get information about a single clan by clan tag
 - [x] List clan members
 - [ ] Retrieve clan's clan war log
 - [ ] Retrieve information about clan's current clan war
 - [ ] Retrieve information about clan's current clan war league group
 - [ ] Retrieve information about individual clan war league war

 **Leagues**
 

 - [ ] List leagues
 - [ ] Get league information
 - [ ] Get league seasons
 - [ ] Get league season rankings
 
 
 **Locations**
 - [ ] List locations
 - [ ] Get information about specific location
 - [ ] Get clan rankings for a specific location
 - [ ] Get player rankings for a specific location
 - [ ] Get clan versus rankings for a specific location
 - [ ] Get player versus rankings for a specific location

## Usage

Some examples:

     CoCApiClient api = new CoCApiClient("your-api-key");
     
     //search for a specific clan
     Clan clan = await api.Clans("#9908QC9Y").Search();
     
     
     //Search for any clan
     ICollection<Clan> clans = await api.Clans()
     	.WithName("!!!")
	     .WithWarFrequency(WarFrequency.Always)
	     .Search();
	     
	     
	// search for 10 german clans with min. level 10
	ICollection<Clan> germanClans = await api.Clans()
		.WithLocationId(32000094)
		.WithLimt(10)
		.WithMinClanLevel(10)
		.Search();
	
	
	// list all members of clan
	ICollection<ClanMember> members = await api.Clans("#9908QC9Y").Members().Search();


     //search for a specific player
     Player player = await api.Players().WithPlayerTag("#GP28C8JU").Search();


Give this repo a ⭐ if you like it. 


