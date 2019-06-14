using AutoCatalogue.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Implementations
{
    public interface IService<TDTO> where TDTO : class
    {
        List<TDTO> Get();
        TDTO GetByID(int id);
        bool Save(TDTO dto);
        bool Update(int id, TDTO carDTO);
        bool Delete(int id);
    }
}
