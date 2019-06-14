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
    public class MakeManagementService : IService<MakeDTO>
    {
        public List<MakeDTO> Get()
        {
            List<MakeDTO> makesDTO = new List<MakeDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.MakeRepository.Get())
                {
                    makesDTO.Add(new MakeDTO
                    {
                        MakeId = item.MakeId,
                        Name = item.Name,
                        Country = item.Country,
                        Description = item.Description
                    });
                }
            }
            return makesDTO;
        }

        public MakeDTO GetByID(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Make make = unitOfWork.MakeRepository.GetByID(id);
                // MakeDTO localMake = GetAll().Where(x => x.MakeId == (int)id).FirstOrDefault();

                if (make == null)
                    return null;

                MakeDTO makeDTO = new MakeDTO
                {
                    MakeId = make.MakeId,
                    Name = make.Name,
                    Description = make.Description,
                    Country = make.Country
                };
                return makeDTO;
            }
        }

        public bool Save(MakeDTO makeDTO)
        {
            if (makeDTO != null)
            {
                Make make = new Make
                {
                    MakeId = makeDTO.MakeId,
                    Name = makeDTO.Name,
                    Country = makeDTO.Country,
                    Description = makeDTO.Description
                };

                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        unitOfWork.MakeRepository.Insert(make);
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

        public bool Update(int id, MakeDTO makeDTO)
        {
            if (makeDTO == null)
                return false;

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Make make = unitOfWork.MakeRepository.GetByID(id);

                    make.Name = makeDTO.Name;
                    make.Description = makeDTO.Description;
                    make.Country = makeDTO.Country;

                    unitOfWork.MakeRepository.Update(make);
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
                    Make make = unitOfWork.MakeRepository.GetByID(id);
                    unitOfWork.MakeRepository.Delete(make);
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

