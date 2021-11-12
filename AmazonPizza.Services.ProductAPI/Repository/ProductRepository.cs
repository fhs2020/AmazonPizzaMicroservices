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

        public Task<ProductsDto> CreateUpdateProduct(ProductsDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
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
