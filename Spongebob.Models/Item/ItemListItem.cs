using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Models
{
    public class ItemListItem
    {
        public bool IsSeedList { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public bool ItemIsCool { get; set; }
    }
}
