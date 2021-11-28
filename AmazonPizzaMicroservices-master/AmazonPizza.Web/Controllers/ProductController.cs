using AmazonPizza.Web.Models;
using AmazonPizza.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AmazonPizza.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        public async Task<IActionResult> ProductIndex()
        {
            List<ProductsDto> list = new();
            var response = await _productService.GetAllProductsAsync<ResponseDto>();

            if (response != null && response.IsSuccess) 
            {
                list = JsonConvert.DeserializeObject<List<ProductsDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> ProductCreate()
        {
 
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ProductCreate(ProductsDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync<ResponseDto>(model);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            var response = await _productService.GetAllProductByIdAsync<ResponseDto>(productId);

            if (response != null && response.IsSuccess)
            {
                ProductsDto model = JsonConvert.DeserializeObject<ProductsDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ProductEdit(ProductsDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync<ResponseDto>(model);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
            var response = await _productService.GetAllProductByIdAsync<ResponseDto>(productId);

            if (response != null && response.IsSuccess)
            {
                ProductsDto model = JsonConvert.DeserializeObject<ProductsDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ProductDelete(ProductsDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.DeleteProductAsync<ResponseDto>(model.Id);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);
        }
    }
}
