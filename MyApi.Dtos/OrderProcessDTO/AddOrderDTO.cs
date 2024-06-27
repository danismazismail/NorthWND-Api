using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.Dtos.OrderProcessDTO
{
    public class AddOrderDTO
    {
        public OrderDTO OrderInfo { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
