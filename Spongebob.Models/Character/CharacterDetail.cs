using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spongebob.Data;

namespace Spongebob.Models
{
    public class CharacterDetail
    {
        [Display(Name = "Character ID")]
        public int CharacterId { get; set; }
        [Display(Name = "Character Name")]
        public string CharacterName { get; set; }
        [Display(Name = "Character Description")]
        public string CharacterDescription { get; set; }
        [Display(Name = "Character Job")]
        public string CharacterJob { get; set; }
        [Display(Name = "Character Place")]
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public string PlaceDescription { get; set; }
        public string Address { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
    }
}
