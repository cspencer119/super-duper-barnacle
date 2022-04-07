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
    [Authorize]
    public class CharacterController : ApiController
    {

        private CharacterService CreateCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cService = new CharacterService(userId);
            return cService;
        }


        public IHttpActionResult Get()
        {
            var cService = CreateCharacterService();
            var chara = cService.GetCharacter();
            return Ok(chara);
        }

        public IHttpActionResult Post(CharacterCreate character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cService = CreateCharacterService();

            if (!cService.CreateCharacter(character))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            var cService = CreateCharacterService();
            var chara = cService.GetCharacterById(id);
            return Ok(chara);
        }

        public IHttpActionResult Put(CharacterEdit character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cService = CreateCharacterService();

            if (!cService.UpdateCharacter(character))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var cService = CreateCharacterService();

            if (!cService.DeleteCharacter(id))
                return InternalServerError();

            return Ok();

        }

    }
}
