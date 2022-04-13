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
            return Ok();
        }


        public IHttpActionResult Put(ItemEdit items)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var iService = CreateItemService();
            if (!iService.EditItem(items))
            {
                return InternalServerError();
            }
            return Ok();
        }
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var iService = CreateItemServiceUserId();

            if (!iService.DeleteItem(id))
                return BadRequest("You do not have access to delete Items in Seed list!");

            return Ok();
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
