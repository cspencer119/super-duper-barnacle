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
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        //public ICollection<Inventory> Inventory { get; set; }
    }
}
