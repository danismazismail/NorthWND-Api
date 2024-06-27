using Microsoft.EntityFrameworkCore;
using MyApi.Core;
using MyApi.DAL.Interfaces;
using MyApi.Dtos.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.DAL.Concrete
{
    public class ProductDAL : IProductDAL
    {
        private readonly MyAppDbContext _context;
        public ProductDAL(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductListDTO>> GetProductListForDropDown()
        {
            return await _context.Products.Where(a => a.IsActive == true).Select(a => new ProductListDTO()
            {
                ProductID = a.ProductID,
                ProductName = a.ProductName
            }).ToListAsync();
        }

        //urunun Id sine göre detay gösteren method????

        public async Task<ProductDetailDTO> GetProductDetailByProductIDAsync(int getDetailsProductID)
        {
            var x = await _context.Products.Where(a => a.IsActive == true && a.ProductID == getDetailsProductID).Select(a => new ProductDetailDTO()
            {
                ProductID = a.ProductID,
                Discontinued = a.Discontinued,
                ProductName = a.ProductName,
                QuantityPerUnit = a.QuantityPerUnit,
                ReorderLevel = a.ReorderLevel,
                UnitPrice = a.UnitPrice,
                UnitsInStock = a.UnitsInStock,
                UnitsOnOrder = a.UnitsOnOrder
            }).SingleOrDefaultAsync();

            return x?? new ProductDetailDTO();
        }

        public async Task<ICollection<ProductsDTO>> GetAllProductsAsync()
        {
           return await _context.Products.Join(_context.Categories,x=> x.CategoryID,a=>a.CategoryID,(x,a) => new { Products = x, Categories = a }).Where(x => x.Products.IsActive && x.Products.UnitsInStock>0).Select(x => new ProductsDTO() 
            {
                CategoryID = x.Products.CategoryID,
                ProductID = x.Products.ProductID,
                ProductName= x.Products.ProductName,
                UnitPrice= x.Products.UnitPrice,
                UnitsInStock = x.Products.UnitsInStock, 
                CategoryName= x.Categories.CategoryName,
            }).OrderBy(x=> x.ProductName).ToListAsync();
        }

        public async Task<ICollection<ProductsDTO>> GetProductListToCategoryAsync(int categoryId)
        {
            return await _context.Products.Where(x=> x.CategoryID==categoryId && x.IsActive).Select(x => new ProductsDTO()
            {
                CategoryID = x.CategoryID,
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
            }).OrderBy(x => x.ProductName).ToListAsync();
        }
    }
}
