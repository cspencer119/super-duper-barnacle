using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spongebob.Data;

namespace Spongebob.Models
{
    public class CharacterEdit
    {    
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }  
        public string CharacterDescription { get; set; }
        public string CharacterJob { get; set; } 
    }
}
