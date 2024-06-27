using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.DAL.Concrete;
using MyApi.DAL.Interfaces;

namespace MyApi.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductProcessController : ControllerBase
    {
        private readonly IProductDAL _dal;

        public ProductProcessController(IProductDAL dal)
        {
            _dal = dal;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            
            return Ok(await _dal.GetProductListForDropDown());
        }

        // [HttpGet("{GetDetail}")]
        [HttpGet("~/api/GetDetailAsync")]
        public async Task<IActionResult> GetDetailAsync(int proID)
        {
            return Ok( await _dal.GetProductDetailByProductIDAsync(proID));
        }

        [HttpGet("~/api/GetAllProductAsync")]
        public async Task<IActionResult> GetAllProductAsync()
        {
            return Ok(await _dal.GetAllProductsAsync());
        }
        [HttpGet("~/api/GetProductListToCategoryAsync")]
        public async Task<IActionResult> GetProductListToCategoryAsync(int categoryId)
        {
            return Ok(await _dal.GetProductListToCategoryAsync(categoryId));
        }










        //[NonAction]
        //public IActionResult Husamettin()
        //{

        //    return Ok(_dal.GetProductListForDropDown());

        //}
    }
}
