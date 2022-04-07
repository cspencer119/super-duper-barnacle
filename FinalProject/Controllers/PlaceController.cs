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
    public class PlaceController : ApiController
    {

        public IHttpActionResult Get()
        {
            PlaceService pService = CreatePlaceService();
            var place = pService.GetPlaces();
            return Ok(place);
        }

        public IHttpActionResult Post(PlaceCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlaceService();

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

        public IHttpActionResult Delete(int id)
        {
            var pService = CreatePlaceService();

            if (!pService.DeletePlace(id))
                return InternalServerError();

            return Ok();
            
        }


        private PlaceService CreatePlaceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var placeService = new PlaceService(userId);
            return placeService;

        }

    }
}
