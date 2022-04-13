using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Data
{
    
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string PlaceName { get; set; }
        [Required]
        public string PlaceDescription { get; set; }
        [Required]
        public string Address { get; set; }
        public virtual Character Character { get; set; }

    }
}
