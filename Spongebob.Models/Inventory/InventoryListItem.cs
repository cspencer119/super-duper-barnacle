
using Spongebob.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Models
{
    public class InventoryListItem
    {
        public bool IsSeedList { get; set; }
        public int InventoryId { get; set; }
        public int ItemId { get; set; }
        public int CharacterId { get; set; }

        
    }
}
