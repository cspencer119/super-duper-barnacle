using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spongebob.Models.Hangouts;
using Spongebob.Models.Item;
using Spongebob.Models.Place;

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
        
        public List<PlaceCharacterDetail> Places { get; set; }
        public List<ItemCharacterDetail> Items { get; set; }
 
    }
}
