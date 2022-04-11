using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Data
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string CharacterName { get; set; }
        [Required]
        public string CharacterDescription { get; set; }
        [Required]
        public string CharacterJob { get; set; }

        [ForeignKey(nameof(Place))]
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
       // public virtual List<Inventory> Inventory { get; set; }

        

    }
}
