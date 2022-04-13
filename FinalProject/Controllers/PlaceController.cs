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
    
    public class PlaceController : ApiController
    {

        public IHttpActionResult Get()
        {
            PlaceService pService = CreatePlaceService();
            var place = pService.GetPlaces();
            return Ok(place);
        }
        [Authorize]
        public IHttpActionResult Post(PlaceCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlaceServiceUserId();

            if (!service.CreatePlace(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            var pService = CreatePlaceService();
            var place = pService.GetPlaceById(id);
            return Ok(place);
        }

        public IHttpActionResult Put(PlaceEdit place)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pService = CreatePlaceService();

            if (!pService.UpdatePlace(place))
                return InternalServerError();

            return Ok();
            
        }
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var pService = CreatePlaceServiceUserId();

            if (!pService.DeletePlace(id))
                return BadRequest("You do not have access to delete Places in Seed list!");

            return Ok();
            
        }


        private PlaceService CreatePlaceServiceUserId()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var placeService = new PlaceService(userId);
            return placeService;

        }
        private PlaceService CreatePlaceService()
        {
            var placeService = new PlaceService();
            return placeService;
        }

    }
}
