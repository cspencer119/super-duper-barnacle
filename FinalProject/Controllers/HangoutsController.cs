using Microsoft.AspNet.Identity;
using Spongebob.Models;
using Spongebob.Models.Hangouts;
using Spongebob.Models.Locations;
using Spongebob.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    
    public class HangoutsController : ApiController
    {
        public IHttpActionResult Get()
        {
            HangoutsService iService = CreateHangoutsService();
            var hangouts = iService.GetHangouts();
            return Ok(hangouts);
        }
        [Authorize]
        public IHttpActionResult Post(HangoutsCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateHangoutsServiceUserId();

            if (!service.CreateHangouts(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            var iService = CreateHangoutsService();
            var hangouts = iService.GetHangoutsById(id);
            return Ok(hangouts);
        }

        public IHttpActionResult Put(HangoutsEdit hangouts)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var iService = CreateHangoutsService();

            if (!iService.UpdateHangouts(hangouts))
                return InternalServerError();

            return Ok();

        }
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var iService = CreateHangoutsServiceUserId();

            if (!iService.DeleteHangouts(id))
                return BadRequest("You do not have access to delete Hangouts in Seed list!");

            return Ok();

        }



        private HangoutsService CreateHangoutsService()
        {
            var hangoutsService = new HangoutsService();
            return hangoutsService;
        }

        private HangoutsService CreateHangoutsServiceUserId()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var hangoutsService = new HangoutsService(userId);
            return hangoutsService;
        }


    }
}