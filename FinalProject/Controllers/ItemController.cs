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
            var cService = CreateItemService();
            var items = cService.GetItems();
            return Ok(items);
        }

        public IHttpActionResult Post(ItemCreate item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var cService = CreateItemService();
            if (!cService.CreateItem(item))
            {
                return InternalServerError();
            }
            return Ok();
        }

        public IHttpActionResult Edit(ItemEdit items)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var cService = CreateItemService();
            if (!cService.EditItem(items))
            {
                return InternalServerError();
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateItemService();

            if (!service.DeleteItem(id))
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
