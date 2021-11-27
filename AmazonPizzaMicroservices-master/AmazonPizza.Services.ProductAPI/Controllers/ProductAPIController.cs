using AmazonPizza.Services.ProductAPI.Model.Dto;
using AmazonPizza.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AmazonPizza.Services.ProductAPI.Controllers
{

    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            try
            {
                IEnumerable<ProductsDto> productsDtos = await _productRepository.GetProductsDtosAsync();
                _response.Result = productsDtos;

            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Object> Get(int id)
        {
            try
            {
                ProductsDto productsDto = await _productRepository.GetProductById(id);
                _response.Result = productsDto;

            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        public async Task<Object> Post([FromBody] ProductsDto productDto)
        {
            try
            {
                ProductsDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;

            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPut]
        public async Task<Object> Put([FromBody] ProductsDto productDto)
        {
            try
            {
                ProductsDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;

            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool issSuccess = await _productRepository.DeleteProduct(id);
                _response.Result = issSuccess;

            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}
