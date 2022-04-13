using Spongebob.Data;
using Spongebob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Service
{
    public class ItemService
    {
        private readonly Guid _userId;

        public ItemService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateItem(ItemCreate model)
        {
            var entity =
                new Item()
                {
                    UserId = _userId,
                    ItemName = model.ItemName,
                    ItemDescription = model.ItemDescription,
                    ItemIsCool = model.ItemIsCool
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                    return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ItemListItem> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Items
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new ItemListItem
                        {
                            ItemId = e.ItemId,
                            ItemName = e.ItemName,
                            ItemDescription = e.ItemDescription,
                            ItemIsCool = e.ItemIsCool
                        }
                        );
                return query.ToArray();
            }
        }

        public ItemDetail GetItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Items
                    .Single(e => e.ItemId == id && e.UserId == _userId);
                return
                    new ItemDetail
                    {
                        ItemId = entity.ItemId,
                        ItemName = entity.ItemName,
                        ItemDescription = entity.ItemDescription,
                        ItemIsCool = entity.ItemIsCool
                    };
            }
        }

        public bool EditItem(ItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Items
                    .Single(e => e.ItemId == model.ItemId && e.UserId == _userId);

                entity.ItemId = model.ItemId;
                entity.ItemName = model.ItemName;
                entity.ItemDescription = model.ItemDescription;
                entity.ItemIsCool = model.ItemIsCool;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteItem(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Items
                    .Single(e => e.ItemId == itemId && e.UserId == _userId);

                var inventories = ctx.Inventories.Where(e => e.UserId == _userId);
                foreach(var inventory in inventories)
                {
                    if (inventory.ItemId == itemId)
                        ctx.Inventories.Remove(inventory);
                }

                ctx.Items.Remove(entity);
                
                return ctx.SaveChanges() >= 1;
            }
        }

    }
}
