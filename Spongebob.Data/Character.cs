using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Data
{
    public class Character
    {
        [Key]
        public int characterId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string characterName { get; set; }
        [Required]
        public string characterDescription { get; set; }
        [Required]
        public string characterJob { get; set; }

        [ForeignKey(nameof(Place))]
        Place place
        int characterPlaceId

//strech ListJunk items (virtual property)
    }
}
