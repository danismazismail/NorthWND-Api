using MyApi.DAL.Concrete;
using MyApi.Dtos.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.DAL.Interfaces
{
    public interface IEmployeeDAL
    {
        List<EmloyeeListDTO> EmployeeListele();
    }
}
