using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spongebob.Data;

namespace Spongebob.Models
{
    public class CharacterCreate
    {
        [MaxLength(30, ErrorMessage = "There are too many characters in this field. (Max 30)")]
        [Required]
        public string CharacterName { get; set; }
        //public override string ToString() => CharacterName;
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field. (Max 1000)")]
        [Required]
        public string CharacterDescription { get; set; }
        [Required]
        public string CharacterJob { get; set; }
        //[Required]
        public int PlaceId { get; set; }
        public int ItemId { get; set; }
        
        //public virtual List<Inventory> Items { get; set; } = new List<Inventory>();
        //public int InventoryId { get; set; }
    }
}
