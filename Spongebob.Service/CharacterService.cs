using Spongebob.Data;
using Spongebob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spongebob.Data;
using Spongebob.Models;
using Spongebob.Models.Item;

namespace Spongebob.Service
{
    public class CharacterService
    {
        private readonly Guid _userId;

        public CharacterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacter(CharacterCreate model)
        {
            var entity =
                new Character()
                {
                    UserId = _userId,
                    CharacterName = model.CharacterName,
                    CharacterDescription = model.CharacterDescription,
                    CharacterJob = model.CharacterJob,
                    PlaceId = model.PlaceId,
                    ItemId = model.ItemId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CharacterListItem> GetCharacter()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Characters.Where(e => e.UserId == _userId)
                    .Select(e => new CharacterListItem
                    {
                        CharacterId = e.CharacterId,
                        CharacterName = e.CharacterName
                    });
                return query.ToArray();
            }
        }

        public CharacterDetail GetCharacterById(int characterID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Characters.Single(e => e.CharacterId == characterID);
                if (entity.PlaceId == null)
                    return
                        new CharacterDetail
                        {
                            CharacterId = entity.CharacterId,
                            CharacterName = entity.CharacterName,
                            CharacterDescription = entity.CharacterDescription,
                            CharacterJob = entity.CharacterJob,
                            Inventory = entity.Inventory.Select(e => new InventoryListItem { CharacterId = e.CharacterId, InventoryId = e.InventoryId, ItemId = e.ItemId }).ToList(),
                            Items = entity.Inventory.Select(i => new ItemCharacterDetail
                            {
                                ItemName = i.Item.ItemName,
                            }).ToList(),
                        };
                else 
                return
                    new CharacterDetail
                    {
                        CharacterId = entity.CharacterId,
                        CharacterName = entity.CharacterName,
                        CharacterDescription = entity.CharacterDescription,
                        CharacterJob = entity.CharacterJob,
                        PlaceId = entity.Place.PlaceId,
                        PlaceName = entity.Place.PlaceName,
                        Inventory = entity.Inventory.Select(e => new InventoryListItem { CharacterId = e.CharacterId, InventoryId = e.InventoryId, ItemId = e.ItemId }).ToList(),
                        Items = entity.Inventory.Select(i => new ItemCharacterDetail
                        {
                            ItemName = i.Item.ItemName,
                        }).ToList(),
                    };
            }
        }

        public bool UpdateCharacter(CharacterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Characters.Single(e => e.CharacterId == model.CharacterId);
                entity.CharacterName = model.CharacterName;
                entity.CharacterDescription = model.CharacterDescription;
                entity.CharacterJob = model.CharacterJob;
                entity.PlaceId = model.PlaceId;
                entity.ItemId = model.ItemId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCharacter(int characterID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Characters
                    .Single(e => e.CharacterId == characterID);

                ctx.Characters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
