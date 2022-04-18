using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Data
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public bool IsSeedList { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        [Required]
        public bool ItemIsCool { get; set; }

        public int InventoryId { get; set; }

    }
}
