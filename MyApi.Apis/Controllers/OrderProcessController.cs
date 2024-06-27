using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Apis.Filters;
using MyApi.DAL.Interfaces;
using MyApi.Dtos.OrderProcessDTO;

namespace MyApi.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderProcessController : ControllerBase
    {
        private readonly IOrderDAL _orderDAL;
        public OrderProcessController(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
                
        }
        [HttpGet("")]
        public IActionResult Get()
        {

            return null;

        }
        [MyExceptionFilter]
        [HttpPost("~/api/addOrderWithDetails")]
        public IActionResult Post([FromBody] AddOrderDTO dto)
        {          

            return _orderDAL.AddOrderWithDetails(dto) ==true?Ok("ok"):BadRequest("verilerinizi kontrol ederek tekrar deneyiniz.. ");
        }
        
    }
}
