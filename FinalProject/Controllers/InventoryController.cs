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
    
    public class InventoryController : ApiController
    {

        public IHttpActionResult Get()
        {
            InventoryService iService = CreateInventoryService();
            var inventory = iService.GetInventory();
            return Ok(inventory);
        }
        [Authorize]
        public IHttpActionResult Post(InventoryCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateInventoryServiceUserId();

            if (!service.CreateInventory(model))
                return InternalServerError();

            return Ok();
        }

        //public IHttpActionResult Get(int id)
        //{
        //    var iService = CreateInventoryService();
        //    var inventory = iService.GetInventoryById(id);
        //    return Ok(inventory);
        //}

        public IHttpActionResult Put(InventoryEdit inventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var iService = CreateInventoryService();

            if (!iService.UpdateInventory(inventory))
                return InternalServerError();

            return Ok();

        }
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var iService = CreateInventoryServiceUserId();

            if (!iService.DeleteInventory(id))
                return BadRequest("You do not have access to delete Inventories in Seed list!");

            return Ok();

        }



        private InventoryService CreateInventoryService()
        {
            var inventoryService = new InventoryService();
            return inventoryService;
        }


        private InventoryService CreateInventoryServiceUserId()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var inventoryService = new InventoryService(userId);
            return inventoryService;
        }


    }
}
