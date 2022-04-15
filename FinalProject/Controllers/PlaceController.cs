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

            return Ok($"You created {model.PlaceName}!");
        }

        public IHttpActionResult Get(int id)
        {
            var pService = CreatePlaceService();
            var place = pService.GetPlaceById(id);
            if (place == null)
            {
                return BadRequest("That place id doesn't exist");
            }
            return Ok(place);
        }

        public IHttpActionResult Put(PlaceEdit place)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var pService = CreatePlaceService();
            if (!pService.UpdatePlace(place))
            {
                return BadRequest("That Place Id doesn't exist!");

            }

            return Ok($"You edited place {place.PlaceId}!");
            
        }
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var pService = CreatePlaceServiceUserId();

            if (!pService.DeletePlace(id))
                return BadRequest("You can only delete places that you have created. This place either does not exist or was not created by you!");

            return Ok("You sucessfully deleted the place!");
            
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
