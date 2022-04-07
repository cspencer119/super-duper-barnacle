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
        public string itemName { get; set; }

        [Required]
        [MaxLength(250)]
        public string itemDescription { get; set; }

        [Required]
        public bool itemIsCool { get; set; }

    }
}
