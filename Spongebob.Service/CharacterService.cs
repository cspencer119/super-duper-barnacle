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
     }
}
