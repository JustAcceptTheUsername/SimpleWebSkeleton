using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoCatalogue.Entities
{
    public class Make
    {
        [Key]
        public int MakeId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Too Many Characters")]
        [MinLength(1, ErrorMessage = "Insufficient Number Of Characters")]
        public string Name { get; set; }

        public string Description { get; set; }
        public string Country { get; set; }
          
    }
}