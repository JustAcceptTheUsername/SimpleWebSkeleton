using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCatalogue.AppServices.DTOs
{
    public class CarDTO
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public string ReleaseYear { get; set; }
        public int? HorsePower { get; set; }

        public int MakeId { get; set; }
        public MakeDTO Make { get; set; }

        public int TypeId { get; set; }
        public TypeDTO Type { get; set; }
    }
}