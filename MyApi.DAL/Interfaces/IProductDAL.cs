using MyApi.Dtos.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.DAL.Interfaces
{
    public interface IProductDAL
    {
        Task<List<ProductListDTO>> GetProductListForDropDown();
        Task<ProductDetailDTO> GetProductDetailByProductIDAsync(int getDetailsProductID);
        Task<ICollection<ProductsDTO>> GetAllProductsAsync();
        Task<ICollection<ProductsDTO>> GetProductListToCategoryAsync(int categoryId);
    }
}
