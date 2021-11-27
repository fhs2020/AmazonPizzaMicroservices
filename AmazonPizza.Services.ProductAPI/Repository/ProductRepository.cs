using AmazonPizza.Services.ProductAPI.DbContexts;
using AmazonPizza.Services.ProductAPI.Model;
using AmazonPizza.Services.ProductAPI.Model.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmazonPizza.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductsDto> CreateUpdateProduct(ProductsDto productDto)
        {
             Product product = _mapper.Map<ProductsDto, Product>(productDto);

             if(product.Id > 0)
                _dbContext.Update(product);
             else
                _dbContext.Products.Add(product);

             await _dbContext.SaveChangesAsync();

            return _mapper.Map<Product, ProductsDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _dbContext.Products.FirstOrDefaultAsync(u => u.Id == productId);

                if (product == null)
                    return false;

                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true; 
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ProductsDto> GetProductById(int productId)
        {
            var product = await _dbContext.Products.Where(p => p.Id == productId).FirstOrDefaultAsync(); 

            return _mapper.Map<ProductsDto>(product);
        }

        public async Task<IEnumerable<ProductsDto>> GetProductsDtosAsync()
        {
           IEnumerable<Product> productList = await _dbContext.Products.ToListAsync();

            return _mapper.Map<List<ProductsDto>>(productList);
        }
    }
}
