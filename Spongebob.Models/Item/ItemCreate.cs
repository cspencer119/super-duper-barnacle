using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spongebob.Models
{
    public class ItemCreate
    {
        [Required]
        [MaxLength(50)]
        public string ItemName { get; set; }
        [Required]
        [MaxLength(250)]
        public string ItemDescription { get; set; }
        public bool ItemIsCool { get; set; }

    }
}
