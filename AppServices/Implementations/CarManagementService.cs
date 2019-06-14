using AutoCatalogue.AppServices.DTOs;
using AutoCatalogue.Entities;
using AutoCatalogue.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Implementations
{
    public class CarManagementService : IService<CarDTO>
    {
        public List<CarDTO> Get()
        {
            List<CarDTO> carsDTO = new List<CarDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.CarRepository.Get())
                {
                    if(item.Type == null || item.Make == null)
                    {
                        carsDTO.Add(new CarDTO
                        {
                            CarId = item.CarId,
                            Model = item.Model,
                            ReleaseYear = item.ReleaseYear,
                            HorsePower = item.HorsePower,
                            MakeId = item.MakeId,
                            TypeId = item.TypeId,

                            Make = new MakeDTO
                            {
                                MakeId = item.MakeId,
                                Name = unitOfWork.MakeRepository.GetByID(item.MakeId).Name,
                                Description = unitOfWork.MakeRepository.GetByID(item.MakeId).Description,
                                Country = unitOfWork.MakeRepository.GetByID(item.MakeId).Country,
                            },

                            Type = new TypeDTO
                            {
                                TypeId = item.TypeId,
                                Name = unitOfWork.TypeRepository.GetByID(item.TypeId).Name,
                                Description = unitOfWork.TypeRepository.GetByID(item.TypeId).Description
                            }
                        });
                    }
                    else
                    {
                        carsDTO.Add(new CarDTO
                        {
                            CarId = item.CarId,
                            Model = item.Model,
                            ReleaseYear = item.ReleaseYear,
                            HorsePower = item.HorsePower,
                            TypeId = item.TypeId,
                            MakeId = item.MakeId,

                            Type = new TypeDTO
                            {
                                TypeId = item.TypeId,
                                Name = item.Type.Name,
                                Description = item.Type.Description
                            },

                            Make = new MakeDTO
                            {
                                MakeId = item.MakeId,
                                Name = item.Make.Name,
                                Description = item.Make.Description,
                                Country = item.Make.Country
                            }

                        });
                    }
                   
                }
            }
            return carsDTO;
        }

        public CarDTO GetByID(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Car car = unitOfWork.CarRepository.GetByID(id);
                // CarDTO otherCar = GetAll().Where(x => x.CarId == id).FirstOrDefault();

                if (car == null)
                    return null;

                CarDTO carDTO = new CarDTO
                {
                    CarId = car.CarId,
                    Model = car.Model,
                    ReleaseYear = car.ReleaseYear,
                    HorsePower = car.HorsePower,
                    MakeId = car.MakeId,
                    TypeId = car.TypeId,

                    Make = new MakeDTO
                    {
                        MakeId = car.MakeId,
                        Name = unitOfWork.MakeRepository.GetByID(car.MakeId).Name,
                        Country = unitOfWork.MakeRepository.GetByID(car.MakeId).Country,
                        Description = unitOfWork.MakeRepository.GetByID(car.MakeId).Description
                    },

                    Type = new TypeDTO
                    {
                        TypeId = car.TypeId,
                        Name = unitOfWork.TypeRepository.GetByID(car.TypeId).Name,
                        Description = unitOfWork.TypeRepository.GetByID(car.TypeId).Description
                    }
                    
                };
                return carDTO;
            }
        }

        public bool Save(CarDTO carDTO)
        {
            if (carDTO != null)
            {
                Car car = new Car
                {
                    CarId = carDTO.CarId,
                    Model = carDTO.Model,
                    ReleaseYear = carDTO.ReleaseYear,
                    HorsePower = carDTO.HorsePower,

                    MakeId = carDTO.MakeId,
                    TypeId = carDTO.TypeId

                    /*
                    Type = new CarType
                    {
                        Name = carDTO.Type.Name,
                        Description = carDTO.Type.Description
                    },

                    Make = new Make
                    {
                        Name = carDTO.Make.Name,
                        Description = carDTO.Make.Description,
                        Country = carDTO.Make.Country
                    }
                    */
                };
                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        unitOfWork.CarRepository.Insert(car);
                        unitOfWork.Save();
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public bool Update(int id, CarDTO carDTO)
        {
            if (carDTO == null)
                return false;

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Car car = unitOfWork.CarRepository.GetByID(id);
                    {
                        car.Model = carDTO.Model;
                        car.ReleaseYear = carDTO.ReleaseYear;
                        car.TypeId = carDTO.TypeId;
                        car.MakeId = carDTO.MakeId;
                    }

                    unitOfWork.CarRepository.Update(car);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Car Car = unitOfWork.CarRepository.GetByID(id);
                    unitOfWork.CarRepository.Delete(Car);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
