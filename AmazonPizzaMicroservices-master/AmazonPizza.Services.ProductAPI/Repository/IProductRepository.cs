using AmazonPizza.Services.ProductAPI.Model.Dto;

namespace AmazonPizza.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductsDto>> GetProductsDtosAsync();
        Task<ProductsDto> GetProductById(int productId);
        Task<ProductsDto> CreateUpdateProduct(ProductsDto productDto);
        Task<bool> DeleteProduct(int productId);
    }
}
