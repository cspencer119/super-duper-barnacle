using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Models
{
    public class PlaceCreate
    {

        [Required]
        [MinLength(1, ErrorMessage ="Please enter at least 1 character.")]
        [MaxLength (100, ErrorMessage ="There are too many characters in this field.")]
        public string PlaceName { get; set; }

        public string PlaceDescription { get; set; }
        public string Address { get; set; }
    }
}
