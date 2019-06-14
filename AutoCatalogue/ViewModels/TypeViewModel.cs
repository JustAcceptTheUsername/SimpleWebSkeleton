using AutoCatalogue.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoCatalogue.ViewModels
{
    public class TypeViewModel
    {
        public TypeViewModel(TypeDTO typeDTO)
        {
            TypeId = typeDTO.TypeId;
            Name = typeDTO.Name;
            Description = typeDTO.Description;
        }

        public TypeViewModel()
        {

        }

        public int TypeId { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage = "Too Many Characters")]
        [MinLength(1,ErrorMessage = "Insufficient Number Of Characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(400, ErrorMessage = "Too Many Characters")]
        [MinLength(1, ErrorMessage = "Insufficient Number Of Characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}