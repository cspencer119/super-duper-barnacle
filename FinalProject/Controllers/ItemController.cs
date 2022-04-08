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

        public IHttpActionResult Post(ItemCreate item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var iService = CreateItemService();
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

        public IHttpActionResult Delete(int id)
        {
            var iService = CreateItemService();

            if (!iService.DeleteItem(id))
                return InternalServerError();

            return Ok();
        }

        private ItemService CreateItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var itemService = new ItemService(userId);
            return itemService;
        }
    }
}
