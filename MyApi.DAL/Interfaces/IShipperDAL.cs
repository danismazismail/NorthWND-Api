using MyApi.Dtos.ShipperProcessDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.DAL.Interfaces
{
    public interface IShipperDAL
    {
         Task<List<ShipperListDTO>> ShipperList();
    }
}
