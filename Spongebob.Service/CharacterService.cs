using Spongebob.Data;
using Spongebob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spongebob.Models.Item;
using Spongebob.Models.Hangouts;

namespace Spongebob.Service
{
    public class CharacterService
    {
        private readonly Guid _userId;
        public CharacterService() { }
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

                    CharacterJob = model.CharacterJob

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
                    .Characters
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
                return
                    new CharacterDetail
                    {
                        CharacterId = entity.CharacterId,
                        CharacterName = entity.CharacterName,
                        CharacterDescription = entity.CharacterDescription,
                        CharacterJob = entity.CharacterJob,



                        Places = entity.Hangouts.Select(i => new Models.Place.PlaceCharacterDetail
                        {
                            PlaceId = i.Place.PlaceId,
                            PlaceName = i.Place.PlaceName,
                        }).ToList(),


                        Items = entity.Inventory.Select(i => new ItemCharacterDetail
                        {
                            ItemId = i.Item.ItemId,
                            ItemName = i.Item.ItemName,
                        }).ToList(),
                    };
            }
        }
        //ticket48
        public bool UpdateCharacter(CharacterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var all = ctx.Characters.ToArray();
                foreach (var c in all)
                {
                    if (c.CharacterId == model.CharacterId)
                    {



                        var entity =
                            ctx
                            .Characters.Single(e => e.CharacterId == model.CharacterId);
                        entity.CharacterName = model.CharacterName;
                        entity.CharacterDescription = model.CharacterDescription;
                        entity.CharacterJob = model.CharacterJob;

                        return ctx.SaveChanges() >= 1;
                    }
                }
                return false;
            }
        }

        public bool DeleteCharacter(int characterID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userCharacters = ctx.Characters.Where(e => e.UserId == _userId).ToArray();
                foreach (var c in userCharacters)
                {

                    if (c.CharacterId == characterID)
                    {

                        var entity =
                            ctx
                            .Characters
                            .Single(e => e.CharacterId == characterID && e.UserId == _userId);

                        ctx.Characters.Remove(entity);

                        return ctx.SaveChanges() == 1;
                    }
                }
                return false;
            }
        }
    }
}
