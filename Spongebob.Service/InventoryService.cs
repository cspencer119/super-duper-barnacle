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
            using (var ctx = new ApplicationDbContext())
            {
                var chars = ctx.Characters.ToArray();
                var items = ctx.Items.ToArray();
                foreach (var c in chars)
                {
                    if (c.CharacterId == model.CharacterId)
                    {
                        foreach (var i in items)
                        {
                            if (i.ItemId == model.ItemId)
                            {
                                var entity = new Inventory()
                                {
                                    UserId = _userId,
                                    CharacterId = model.CharacterId,
                                    ItemId = model.ItemId,
                                };
                                ctx.Inventories.Add(entity);
                                return ctx.SaveChanges() == 1;
                            }
                        }
                    }
                }
                return false;
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
                        });
                return query.ToArray();
            }
        }

        public InventoryDetail GetInventoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var inventories = ctx.Inventories.Where(e => e.InventoryId == id).ToArray();
                foreach (var i in inventories)
                {
                    if (i.InventoryId == id)
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
                return null;
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
                        var chars = ctx.Characters.ToArray();
                        var items = ctx.Items.ToArray();
                        foreach (var c in chars)
                        {
                            if (c.CharacterId == model.CharacterId)
                            {
                                foreach (var item in items)
                                {
                                    if (item.ItemId == model.ItemId)
                                    {
                                        entity.InventoryId = model.InventoryId;
                                        entity.CharacterId = model.CharacterId;
                                        entity.ItemId = model.ItemId;
                                        return ctx.SaveChanges() >= 1;
                                    }
                                }
                            }
                        }
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
