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

        public bool IsSeedList { get; set; }

        public virtual List<Hangouts> Hangouts { get; set; }

        public virtual List<Inventory> Inventory { get; set; }

        

    }
}
