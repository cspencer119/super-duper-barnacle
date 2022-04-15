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
    
    public class ItemController : ApiController
    {
        public IHttpActionResult Get()
        {
            var iService = CreateItemService();
            var items = iService.GetItems();
            return Ok(items);
        }

        public IHttpActionResult Get(int id)
        {
            var iService = CreateItemService();
            var item = iService.GetItemById(id);
            if (item == null)
            {
                return BadRequest("That item Id doesn't exist!");
            }
            return Ok(item);
        }
        [Authorize]
        public IHttpActionResult Post(ItemCreate item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var iService = CreateItemServiceUserId();
            if (!iService.CreateItem(item))
            {
                return InternalServerError();
            }
            return Ok($"Item {item.ItemName} has been created!");
        }


        public IHttpActionResult Put(ItemEdit items)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var iService = CreateItemService();
            if (!iService.EditItem(items))
            {
                return BadRequest("That Item Id doesn't exist!");
            }
            return Ok($"You edited item {items.ItemId}!");
        }
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var iService = CreateItemServiceUserId();

            if (!iService.DeleteItem(id))
                return BadRequest("You can only delete Items that you have created. This Item either does not exist or was not created by you!");

            return Ok("You have successfully deleted the item!");
        }

        private ItemService CreateItemService()
        {
            
            var itemService = new ItemService();
            return itemService;
        }
        private ItemService CreateItemServiceUserId()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var itemService = new ItemService(userId);
            return itemService;
        }

    }
}
