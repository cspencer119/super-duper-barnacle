using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spongebob.Data;
using Spongebob.Models;

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
                    //Should computer generate ID???
                    //CharacterId = model.CharacterId,
                    CharacterName = model.CharacterName,
                    CharacterDescription = model.CharacterDescription,
                    CharacterJob = model.CharacterJob
                    //Character Place
                    //Character Inventory
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
                    .Characters.Select(e => new CharacterListItem
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
                        CharacterPlace = entity.Place,
                        Inventory = entity.Inventory
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
                entity.Place = model.Place;
                entity.Inventory = model.Items;

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
