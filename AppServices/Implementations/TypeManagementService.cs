using AutoCatalogue.AppServices.DTOs;
using AutoCatalogue.Entities;
using AutoCatalogue.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Implementations
{
    public class TypeManagementService : IService<TypeDTO>
    {
        public List<TypeDTO> Get()
        {
            List<TypeDTO> typesDTO = new List<TypeDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.TypeRepository.Get())
                {
                    typesDTO.Add(new TypeDTO
                    {
                        TypeId = item.TypeId,
                        Name = item.Name,
                        Description = item.Description
                    });
                }
            }
            return typesDTO;
        }

        public TypeDTO GetByID(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                CarType type = unitOfWork.TypeRepository.GetByID(id);
                // TypeDTO otherType = GetAll().Where(x => x.TypeId == id).FirstOrDefault();

                if (type == null)
                    return null;

                TypeDTO typeDTO = new TypeDTO
                {
                    TypeId = type.TypeId,
                    Name = type.Name,
                    Description = type.Description,
                };

                return typeDTO;
            }
        }

        public bool Save(TypeDTO typeDTO)
        {
            if (typeDTO != null)
            {
                CarType type = new CarType
                {
                    TypeId = typeDTO.TypeId,
                    Name = typeDTO.Name,
                    Description = typeDTO.Description
                };

                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        unitOfWork.TypeRepository.Insert(type);
                        unitOfWork.Save();
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Update(int id, TypeDTO typeDTO)
        {
            if (typeDTO == null)
                return false;

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    CarType oldType = unitOfWork.TypeRepository.GetByID(id);

                    oldType.Name = typeDTO.Name;
                    oldType.Description = typeDTO.Description;

                    unitOfWork.TypeRepository.Update(oldType);
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
                    CarType type = unitOfWork.TypeRepository.GetByID(id);
                    unitOfWork.TypeRepository.Delete(type);
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

