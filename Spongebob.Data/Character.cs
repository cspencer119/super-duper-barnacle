﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int character_placeId { get; set; }
        public virtual Place place { get; set; }
        

        //strech ListJunk items (virtual property)
    }
}
