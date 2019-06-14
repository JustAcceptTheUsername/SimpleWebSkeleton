using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoCatalogue.Entities
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Too Many Characters")]
        [MinLength(1, ErrorMessage = "Insufficient Number Of Characters")]
        public string Model { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Too Many Characters")]
        [MinLength(1, ErrorMessage = "Insufficient Number Of Characters")]
        public string ReleaseYear { get; set; }

        public int? HorsePower { get; set; }

        [ForeignKey("Make")]
        public int MakeId { get; set; }
        public Make Make { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public CarType Type { get; set; }
    }
}