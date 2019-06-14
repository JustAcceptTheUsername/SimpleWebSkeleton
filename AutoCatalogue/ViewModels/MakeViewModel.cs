using AutoCatalogue.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoCatalogue.ViewModels
{
    public class MakeViewModel
    {
        public MakeViewModel(MakeDTO makeDTO)
        {
            MakeId = makeDTO.MakeId;
            Name = makeDTO.Name;
            Description = makeDTO.Description;
            Country = makeDTO.Country;
        }

        public MakeViewModel()
        {

        }

        public int MakeId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Too Many Characters")]
        [MinLength(1, ErrorMessage = "Insufficient Number Of Characters")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Country { get; set; }

    }
}