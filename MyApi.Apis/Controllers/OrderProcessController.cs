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

            //sipariş nedemek ?
            //orders -order details  ve products
            //orders 1 kayıt , order details a çok kayıt, order details a eklenen kadar urunun products (stok) tan düşürülmesi.
            //dikkat edilecekler ne?
            //validation. => varsa log tablosu log kaydı alınmalı.
            //işler ters giderse bu api ne yapacak.
            //transaction rollback , bad request gibi bir hata mesajı dönülmeli. 

            return _orderDAL.AddOrderWithDetails(dto) ==true?Ok("ok"):BadRequest("verilerinizi kontrol ederek tekrar deneyiniz.. ");
        }
        //CustomerID, ayşe mete umut.
        //EmployeeID,ismail alptuğ yavuz.
        //ShipVia, kerem dicle hanife
        //ProductID , alptuğ,eray
    }
}
