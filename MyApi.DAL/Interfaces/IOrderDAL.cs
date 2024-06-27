using MyApi.Dtos.OrderProcessDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.DAL.Interfaces
{
    public interface IOrderDAL
    {
        bool AddOrderWithDetails(AddOrderDTO dto);
    }
}
