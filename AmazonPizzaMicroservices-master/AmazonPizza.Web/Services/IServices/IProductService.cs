using AmazonPizza.Web.Models;

namespace AmazonPizza.Web.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetAllProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductsDto productDto);
        Task<T> UpdateProductAsync<T>(ProductsDto productDto);
        Task<T> DeleteProductAsync<T>(int id);   
      
    }
}
