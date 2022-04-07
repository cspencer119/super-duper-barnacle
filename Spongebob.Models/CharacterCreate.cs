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

        public int CharacterId { get; set; }
        [MaxLength(30, ErrorMessage = "There are too many characters in this field. (Max 30)")]
        [Required]
        public string CharacterName { get; set; }
        public override string ToString() => CharacterName;

        [MaxLength(1000, ErrorMessage = "There are too many characters in this field. (Max 1000)")]
        [Required]
        public string CharacterDescription { get; set; }
        [Required]
        public Place Place { get; set; }
        [Required]
        public int character_placeId { get; set; }
        [Required]
        public virtual List<Inventory> Inventories { get; set; } = new List<Inventory>();

    }
}
