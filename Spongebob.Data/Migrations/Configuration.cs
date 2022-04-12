using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Spongebob.Data;

namespace Spongebob.Data.Migrations
{
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

                //PlaceId = 1,
                //InventoryId = 1
            },
            new Character()
            {
                CharacterId = 2,
                CharacterName = "Squidward Tentacles",
                CharacterDescription = "A cranky artistic squid stuck working as a cashier",
                CharacterJob = "Cashier",
                //PlaceId = 2,
                //InventoryId = 2
            },
            new Character()
            {
                CharacterId = 3,
                CharacterName = "Mr. Eugene Krabs",
                CharacterDescription = "A greedy crab who owns the Krusty Krab",
                CharacterJob = "Owner of Krusty Krab",
                //PlaceId = 3
            }
            );


            context.Places.AddOrUpdate(x => x.PlaceId,
            new Place()
            {
                PlaceId = 1,
                PlaceName = "Bikini Bottom",
                Address = "Bikini Atoll",
                PlaceDescription = "The heartbeat of the area a thriving metropolis and houses nearly every character in the series."
            },
            new Place()
            {
                PlaceId = 1,
                PlaceName = "Pineapple",
                Address = "124 Conch Street",
                PlaceDescription = "A Pineapple under the see where Spongebob lives"
            },
            new Place()
            {
                PlaceId = 2,
                PlaceName = "Tiki Head",
                Address = "122 Conch Street",
                PlaceDescription = "A sunken Easter Island Head serving as Squidwards home."
            },
            new Place()
            {
                PlaceId = 3,
                PlaceName = "Krusty Krab",
                Address = "831 Bottom Feeder Lane",
                PlaceDescription = "The most popular restaurant in Bikini Bottom. Home of the Krabby Patty."
            }
            );


            context.Items.AddOrUpdate(x => x.ItemId,
                 new Item()
                 {
                     ItemId = 1,
                     ItemName = "Spatula",
                     ItemDescription = "Spongebobs cooking tool. Used for making krabby patties",
                     ItemIsCool = true,
                     InventoryId = 1
                 },
                 new Item()
                 {
                     ItemId = 2,
                     ItemName = "Bubble Wand",
                     ItemDescription = "Spongebobs bubble wand. Used for blowing all sorts of bubbles.",
                     ItemIsCool = true,
                     InventoryId = 1
                 },
                 new Item()
                 {
                     ItemId = 3,
                     ItemName = "Conch Shell",
                     ItemDescription = "A magic consh shell that answers all sorts of questions.",
                     ItemIsCool = true,
                     InventoryId = 1
                 },
                 new Item()
                 {
                     ItemId = 4,
                     ItemName = "Clarinet",
                     ItemDescription = "Squidward prized clarinet. He thinks he is rathe gifted.",
                     ItemIsCool = false,
                     InventoryId = 2
                 },
                 new Item()
                 {
                     ItemId = 5,
                     ItemName = "Canned Bread",
                     ItemDescription = "A prized delicacy among squids in and around Bikini Bottom",
                     ItemIsCool = false,
                     InventoryId = 2
                 },
                 new Item()
                 {
                     ItemId = 6,
                     ItemName = "Painting supplies",
                     ItemDescription = "Squidwards tools for making all of his uhhh 'art'.",
                     ItemIsCool = false,
                     //InventoryId = 2
                 });


            context.Inventories.AddOrUpdate(x => x.InventoryId,
                 new Inventory()
                 {
                     InventoryId = 1,
                     ItemId = 1,
                     CharacterId = 1,
                 },
                 new Inventory()
                 {
                     InventoryId = 2,
                     ItemId = 2,
                     CharacterId = 1
                 },
                 new Inventory()
                 {
                     InventoryId = 3,
                     ItemId = 3,
                     CharacterId = 1
                 },
                 new Inventory()
                 {
                     InventoryId = 4,
                     ItemId = 4,
                     CharacterId = 2
                 },
                 new Inventory()
                 {
                     InventoryId = 5,
                     ItemId = 5,
                     CharacterId = 2
                 },
                 new Inventory()
                 {
                     InventoryId = 6,
                     ItemId = 6,
                     CharacterId = 2
                 });
        }
    }
}


