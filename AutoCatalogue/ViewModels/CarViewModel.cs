using AppServices.Implementations;
using AutoCatalogue.AppServices.DTOs;
using AutoCatalogue.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoCatalogue.ViewModels
{
    public class CarViewModel
    {
        private MakeManagementService makeManagement = new MakeManagementService();
        private TypeManagementService typeManagement = new TypeManagementService();

        #region Constructors
        public CarViewModel(CarDTO carDTO)
        {
            CarId = carDTO.CarId;
            Model = carDTO.Model;
            ReleaseYear = carDTO.ReleaseYear;
            HorsePower = carDTO.HorsePower;
            MakeId = carDTO.MakeId;
            TypeId = carDTO.TypeId;
            Make = carDTO.Make;
            Type = carDTO.Type;

            Makes = makeManagement.Get();
            Types = typeManagement.Get();

            /*
            MakeViewModel makeVM = new MakeViewModel();
            {
                makeVM.MakeId = carDTO.Make.MakeId;
                makeVM.Name = carDTO.Make.Name;
                makeVM.Description = carDTO.Make.Description;
                makeVM.Country = carDTO.Make.Country;
            }

            TypeViewModel typeVM = new TypeViewModel();
            {
                typeVM.TypeId = carDTO.Type.TypeId;
                typeVM.Name = carDTO.Type.Name;
                typeVM.Description = carDTO.Type.Description;
            }
            */

        }

        public CarViewModel()
        {

        }
        #endregion

        public int CarId { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Too Many Characters")]
        [MinLength(1, ErrorMessage = "Insufficient Number Of Characters")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Year Format is Incorrect")]
        [MinLength(1, ErrorMessage = "Year Format is Incorrect")]
        [Display(Name = "Release Year")]
        [DataType(DataType.Date)]
        public string ReleaseYear { get; set; }

        [Display(Name = "HorsePower")]
        [DataType(DataType.Duration)]
        public int? HorsePower { get; set; }

        [Display(Name = "Make")]
        public int MakeId { get; set; }
        public MakeDTO Make { get; set; } // Make Make

        [Display(Name = "Type")]
        public int TypeId { get; set; }
        public TypeDTO Type { get; set; } // Type Type

        public IEnumerable<TypeDTO> Types { get; set; }
        public IEnumerable<MakeDTO> Makes { get; set; }


    }
}