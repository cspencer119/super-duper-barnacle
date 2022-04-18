using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Models.Hangouts
{
    public class HangoutsDetail
    {
        public int HangoutsId { get; set; }
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public bool IsSeedList { get; set; }
    }
}
