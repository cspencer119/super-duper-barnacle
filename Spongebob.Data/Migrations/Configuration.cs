namespace Spongebob.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Spongebob.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Spongebob.Data.ApplicationDbContext";
        }

        protected override void Seed(Spongebob.Data.ApplicationDbContext context)
        {
            context.Characters.AddOrUpdate(x => x.CharacterId,
           new Character()
           {
               CharacterId = 1,
               CharacterName = "Spongebob Squarepants",
               CharacterDescription = "The yellow sponge under the sea. Cooks at the Krusty Krab.",
               CharacterJob = "Fry Cook",
               IsSeedList = true

                //PlaceId = 1,
                //InventoryId = 1
            },
           new Character()
           {
               CharacterId = 2,
               CharacterName = "Squidward Tentacles",
               CharacterDescription = "A cranky artistic squid stuck working as a cashier",
               CharacterJob = "Cashier",
               IsSeedList = true
               //PlaceId = 2,
               //InventoryId = 2
           },
           new Character()
           {
               CharacterId = 3,
               CharacterName = "Mr. Eugene Krabs",
               CharacterDescription = "A greedy crab who owns the Krusty Krab",
               CharacterJob = "Owner of Krusty Krab",
               IsSeedList = true
               //PlaceId = 3
           },
           new Character()
           {
               CharacterId = 4,
               CharacterName = "Patrick Star",
               CharacterDescription = "Spongebobs best friend who is a little lazy but loveable.",
               CharacterJob = "Spongebobs Friend",
               IsSeedList = true
           },
           new Character()
           {
               CharacterId = 5,
               CharacterName = "Larry the Lobster",
               CharacterDescription = "A boby building lobster who works as a lifeguard at Goo Lagoon.",
               CharacterJob = "Lifeguard",
               IsSeedList = true
           },
           new Character()
           {
               CharacterId = 6,
               CharacterName = "Fred",
               CharacterDescription = "AHHH MY LEG..MY LEG",
               CharacterJob = "Catchphrase Deployer",
               IsSeedList = true
           });


            context.Places.AddOrUpdate(x => x.PlaceId,
            new Place()
            {
                PlaceId = 1,
                PlaceName = "Bikini Bottom",
                Address = "Bikini Atoll",
                PlaceDescription = "The heartbeat of the area a thriving metropolis and houses nearly every character in the series.",
                IsSeedList = true
            },
            new Place()
            {
                PlaceId = 2,
                PlaceName = "Pineapple",
                Address = "124 Conch Street",
                PlaceDescription = "A Pineapple under the see where Spongebob lives",
                IsSeedList = true
            },
            new Place()
            {
                PlaceId = 3,
                PlaceName = "Tiki Head",
                Address = "122 Conch Street",
                PlaceDescription = "A sunken Easter Island Head serving as Squidwards home.",
                IsSeedList = true
            },
            new Place()
            {
                PlaceId = 4,
                PlaceName = "Krusty Krab",
                Address = "831 Bottom Feeder Lane",
                PlaceDescription = "The most popular restaurant in Bikini Bottom. Home of the Krabby Patty.",
                IsSeedList = true
            },
            new Place()
            {
                PlaceId = 5,
                PlaceName = "Patricks Rock",
                Address = "120 Conch Street",
                PlaceDescription = "Patricks rock that serves, to varying degrees, as his 'house'.",
                IsSeedList = true
            },
            new Place()
            {
                PlaceId = 6,
                PlaceName = "Goo Lagoon",
                Address = "The Beach",
                PlaceDescription = "The beach in Bikini Bottom.",
                IsSeedList = true
            });

            context.Hangouts.AddOrUpdate(x => x.HangoutsId,
                new Hangouts()
                {
                    HangoutsId = 1,
                    PlaceId = 1,
                    CharacterId = 1,
                    IsSeedList = true
                },
                new Hangouts()
                {
                    HangoutsId = 2,
                    PlaceId = 2,
                    CharacterId = 1,
                    IsSeedList = true
                },
                new Hangouts()
                {
                    HangoutsId = 3,
                    PlaceId = 4,
                    CharacterId = 1,
                    IsSeedList = true
                },
                new Hangouts()
                {
                    HangoutsId = 4,
                    PlaceId = 6,
                    CharacterId = 1,
                    IsSeedList = true
                },
                new Hangouts()
                {
                    HangoutsId = 5,
                    PlaceId = 3,
                    CharacterId = 2,
                    IsSeedList = true
                },
                new Hangouts()
                {
                    HangoutsId = 6,
                    PlaceId = 4,
                    CharacterId = 2,
                    IsSeedList = true
                },
                new Hangouts()
                {
                    HangoutsId = 7,
                    PlaceId = 4,
                    CharacterId = 3,
                    IsSeedList = true
                },
                new Hangouts()
                {
                    HangoutsId = 8,
                    PlaceId = 1,
                    CharacterId = 3,
                    IsSeedList = true
                },
                new Hangouts()
                {
                    HangoutsId = 9,
                    PlaceId = 5,
                    CharacterId = 4,
                    IsSeedList = true
                },
                new Hangouts()
                {
                    HangoutsId = 10,
                    PlaceId = 4,
                    CharacterId = 4,
                    IsSeedList = true
                },
                new Hangouts()
                {
                    HangoutsId = 11,
                    PlaceId = 6,
                    CharacterId = 5,
                    IsSeedList = true
                });

            context.Items.AddOrUpdate(x => x.ItemId,
                 new Item()
                 {
                     ItemId = 1,
                     ItemName = "Spatula",
                     ItemDescription = "Spongebobs cooking tool. Used for making krabby patties",
                     ItemIsCool = true,
                     IsSeedList = true

                 },
                 new Item()
                 {
                     ItemId = 2,
                     ItemName = "Bubble Wand",
                     ItemDescription = "Spongebobs bubble wand. Used for blowing all sorts of bubbles.",
                     ItemIsCool = true,
                     IsSeedList = true

                 },
                 new Item()
                 {
                     ItemId = 3,
                     ItemName = "Conch Shell",
                     ItemDescription = "A magic consh shell that answers all sorts of questions.",
                     ItemIsCool = true,
                     IsSeedList = true

                 },
                 new Item()
                 {
                     ItemId = 4,
                     ItemName = "Clarinet",
                     ItemDescription = "Squidward prized clarinet. He thinks he is rathe gifted.",
                     ItemIsCool = false,
                     IsSeedList = true

                 },
                 new Item()
                 {
                     ItemId = 5,
                     ItemName = "Canned Bread",
                     ItemDescription = "A prized delicacy among squids in and around Bikini Bottom",
                     ItemIsCool = false,
                     IsSeedList = true

                 },
                 new Item()
                 {
                     ItemId = 6,
                     ItemName = "Painting supplies",
                     ItemDescription = "Squidwards tools for making all of his uhhh 'art'.",
                     ItemIsCool = false,
                     IsSeedList = true

                 },
                 new Item()
                 {
                     ItemId = 7,
                     ItemName = "Money",
                     ItemDescription = "Mr. Krabs money. He cherishes it.",
                     ItemIsCool = true,
                     IsSeedList = true
                 },
                 new Item()
                 {
                     ItemId = 8,
                     ItemName = "Secret Formula",
                     ItemDescription = "The Krabby Patty secret formula. Plankton is always trying to steal it!",
                     ItemIsCool = true,
                     IsSeedList = true
                 },
                 new Item()
                 {
                     ItemId = 9,
                     ItemName = "Lifeguard Whistle",
                     ItemDescription = "A whistle for getting attention.",
                     ItemIsCool = true,
                     IsSeedList = true
                 },
                 new Item()
                 {
                     ItemId = 10,
                     ItemName = "Jellyfish net",
                     ItemDescription = "A simple net used to catch jellyfish.",
                     ItemIsCool = true,
                     IsSeedList = true
                 });


            context.Inventories.AddOrUpdate(x => x.InventoryId,
                 new Inventory()
                 {
                     InventoryId = 1,
                     ItemId = 1,
                     CharacterId = 1,
                     IsSeedList = true
                 },
                 new Inventory()
                 {
                     InventoryId = 2,
                     ItemId = 2,
                     CharacterId = 1,
                     IsSeedList = true
                 },
                 new Inventory()
                 {
                     InventoryId = 3,
                     ItemId = 3,
                     CharacterId = 1,
                     IsSeedList = true
                 },
                 new Inventory()
                 {
                     InventoryId = 4,
                     ItemId = 4,
                     CharacterId = 2,
                     IsSeedList = true
                 },
                 new Inventory()
                 {
                     InventoryId = 5,
                     ItemId = 5,
                     CharacterId = 2,
                     IsSeedList = true
                 },
                 new Inventory()
                 {
                     InventoryId = 6,
                     ItemId = 6,
                     CharacterId = 2,
                     IsSeedList = true
                 },
                 new Inventory()
                 {
                     InventoryId = 7,
                     ItemId = 7,
                     CharacterId = 3,
                     IsSeedList = true
                 },
                 new Inventory()
                 {
                     InventoryId = 8,
                     ItemId = 8,
                     CharacterId = 3,
                     IsSeedList = true
                 },
                 new Inventory()
                 {
                     InventoryId = 9,
                     ItemId = 9,
                     CharacterId = 5,
                     IsSeedList = true
                 },
                 new Inventory()
                 {
                     InventoryId = 10,
                     ItemId = 10,
                     CharacterId = 4,
                     IsSeedList = true
                 },
                 new Inventory()
                 {
                     InventoryId = 11,
                     ItemId = 10,
                     CharacterId = 1,
                     IsSeedList = true
                 });
        }
    }
}
