using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Models
{
    public class CharacterListItem
    {
        [Display(Name = "Character Id")]
        public int CharacterId { get; set; }
        [Display(Name = "Character Name")]
        public string CharacterName { get; set; }
        public override string ToString() => CharacterName;
        public bool IsSeedList { get; set; }
    }
}
