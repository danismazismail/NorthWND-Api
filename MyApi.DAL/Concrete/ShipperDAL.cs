using Microsoft.EntityFrameworkCore;
using MyApi.Core;
using MyApi.DAL.Interfaces;
using MyApi.Dtos.ShipperProcessDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyApi.DAL.Concrete.ShipperDAL;

namespace MyApi.DAL.Concrete
{
    public class ShipperDAL : IShipperDAL
    {

        private readonly MyAppDbContext _context;
        public ShipperDAL(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShipperListDTO>> ShipperList()
        {
            return await _context.Shippers.Where(x => x.IsActive == true).Select(a => new ShipperListDTO
            {
                ShipperID=a.ShipperID,
                CompanyName = a.CompanyName

            }).ToListAsync();
        }

    }
}
