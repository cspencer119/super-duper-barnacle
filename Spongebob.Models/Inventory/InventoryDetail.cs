
using Spongebob.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Models
{
    public class InventoryDetail
    {
        public int InventoryId { get; set; }
        public int ItemId { get; set; }
        public string Item { get; set; }
        public int CharacterId { get; set; }

        public string Character { get; set; }
        public bool IsSeedList { get; set; }
    }
}
