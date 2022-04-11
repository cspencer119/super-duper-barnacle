using Spongebob.Data;
using Spongebob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Service
{
    public class InventoryService
    {


        private readonly Guid _userId;

        public InventoryService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateInventory(InventoryCreate model)
        {
            var entity =
                new Inventory()
                {
                    UserId = _userId,
                    CharacterId = model.CharacterId,
                    ItemId = model.ItemId,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Inventories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InventoryListItem> GetInventory()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Inventories
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new InventoryListItem
                        {
                            ItemId = e.ItemId,
                            InventoryId = e.InventoryId,
                            //ItemList = e.ItemList,
                            CharacterId = e.CharacterId,
                        }
                        );
                return query.ToArray();
            }
        }

        public InventoryDetail GetInventoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Inventories
                    .Single(e => e.InventoryId == id && e.UserId == _userId);
                return
                    new InventoryDetail
                    {
                        ItemId = entity.ItemId,
                        InventoryId = entity.InventoryId,
                        CharacterId = entity.CharacterId,
                    };
            }
        }

        public bool UpdateInventory(InventoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Inventories
                    .Single(e => e.InventoryId == model.InventoryId && e.UserId == _userId);

                entity.ItemId = model.ItemId;
                entity.InventoryId = model.InventoryId;
                entity.CharacterId = model.CharacterId;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInventory(int inventoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Inventories
                    .Single(e => e.InventoryId == inventoryId && e.UserId == _userId);

                ctx.Inventories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
