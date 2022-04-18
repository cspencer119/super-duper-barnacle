using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Data
{
    public class Hangouts
    {
        [Key]
        public int HangoutsId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public bool IsSeedList { get; set; }

        [Required]
        public int PlaceId { get; set; }

        [ForeignKey(nameof(PlaceId))]
        public virtual Place Place { get; set; }

        [Required]
        public int CharacterId { get; set; }

        [ForeignKey(nameof(CharacterId))]
        public virtual Character Character { get; set; }
    }
}
