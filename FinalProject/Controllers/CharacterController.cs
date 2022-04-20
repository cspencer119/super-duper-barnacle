using Microsoft.AspNet.Identity;
using Spongebob.Models;
using Spongebob.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{  
    public class CharacterController : ApiController
    {     
        private CharacterService CreateCharacterServiceUserId()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cService = new CharacterService(userId);
            return cService;
        }

        private CharacterService CreateCharacterService()
        {
            var cService = new CharacterService();
            return cService;
        }
        
        public IHttpActionResult Get()
        {
            var cService = CreateCharacterService();
            var chara = cService.GetCharacter();
            return Ok(chara);
        }

        [Authorize]
        public IHttpActionResult Post(CharacterCreate character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var cService = CreateCharacterServiceUserId();
            if (!cService.CreateCharacter(character))      
                return InternalServerError();      
            return Ok($"Character {character.CharacterName} has been created!");
        }

        public IHttpActionResult Get(int id)
        {
            var cService = CreateCharacterService();
            var chara = cService.GetCharacterById(id);
            if (chara == null)
                return BadRequest("That character Id doesn't exist!");
            return Ok(chara);
        }

        public IHttpActionResult Put(CharacterEdit character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var cService = CreateCharacterService();
            if (!cService.UpdateCharacter(character))
                return BadRequest("Nothing to update! Either the ID you provided does not exist or this character is already updated with that information.");
            return Ok($"You have edited character {character.CharacterId}!");
        }

        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var cService = CreateCharacterServiceUserId();
            if (!cService.DeleteCharacter(id))
                return BadRequest("You can only delete Character that you have created. This Character either does not exist or was not created by you!");
            return Ok("You have successfully deleted the character!");
        }
    }
}
