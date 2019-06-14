using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCatalogue.AppServices.DTOs
{
    public class MakeDTO
    {
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
    }
}