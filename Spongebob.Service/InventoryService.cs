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

        public InventoryService() { }
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
                    .Select(
                        e =>
                        new InventoryListItem
                        {
                            ItemId = e.ItemId,
                            InventoryId = e.InventoryId,
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
                    .Single(e => e.InventoryId == id);
                return
                    new InventoryDetail
                    {
                        InventoryId = entity.InventoryId,
                        CharacterId = entity.CharacterId,
                        Character = entity.Character.CharacterName,
                        ItemId = entity.ItemId,
                        Item = entity.Item.ItemName
                    };
            }
        }

        public bool UpdateInventory(InventoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var all = ctx.Inventories.ToArray();
                foreach (var i in all)
                {
                    if (i.InventoryId == model.InventoryId)
                    {

                        var entity =
                            ctx
                            .Inventories
                            .Single(e => e.InventoryId == model.InventoryId);

                        entity.ItemId = model.ItemId;
                        entity.InventoryId = model.InventoryId;
                        entity.CharacterId = model.CharacterId;
                        return ctx.SaveChanges() >= 1;
                    }
                }
                return false;
            }
        }

        public bool DeleteInventory(int inventoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userInventory = ctx.Inventories.Where(e => e.UserId == _userId).ToArray();
                foreach (var i in userInventory)
                {
                    if (i.InventoryId == inventoryId)
                    {
                        var entity =
                            ctx
                            .Inventories
                            .Single(e => e.InventoryId == inventoryId && e.UserId == _userId);

                        ctx.Inventories.Remove(entity);

                        return ctx.SaveChanges() >= 1;
                    }
                }
                return false;
            }
        }


    }
}
