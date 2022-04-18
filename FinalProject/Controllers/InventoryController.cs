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
                return BadRequest("An Id you provided doesn't exist");
            return Ok("Inventory has been created!");
        }

        public IHttpActionResult Get(int id)
        {
            var iService = CreateInventoryService();
            var inventory = iService.GetInventoryById(id);
            if (inventory == null)
                return BadRequest("That inventory Id doesn't exist!");
            return Ok(inventory);
        }

        public IHttpActionResult Put(InventoryEdit inventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var iService = CreateInventoryService();
            if (!iService.UpdateInventory(inventory))

                return BadRequest("The InventoryId/CharacterId/ItemId you provided does not exist!");

            return Ok($"You have sucussfully updated inventory {inventory.InventoryId}!");

        }

        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var iService = CreateInventoryServiceUserId();
            if (!iService.DeleteInventory(id))
                return BadRequest("You can only delete Inventories that you have created. This Inventory either does not exist or was not created by you!");
            return Ok("You have deleted the inventory!");
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
