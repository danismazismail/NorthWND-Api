using MyApi.Core;
using MyApi.DAL.Interfaces;
using MyApi.Dtos.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.DAL.Concrete
{
    public class EmployeeDAL : IEmployeeDAL
    {
        readonly MyAppDbContext _context;
        public EmployeeDAL(MyAppDbContext context)
        {
            _context = context;
        }
        public List<EmloyeeListDTO> EmployeeListele()
        {
            return _context.Employees.Where(x => x.IsActive == true).Select(a => new EmloyeeListDTO
            {
                EmloyeeID = a.EmployeeID,
                FullName= a.FirstName + " " + a.LastName
            }).ToList();
        }

    }
}
