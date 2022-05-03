using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraiderMagazine.Web.Models.Dto;
using TraiderMagazine.Web.Services.IServices;

namespace TraiderMagazine.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _product;

        public ProductController(IProductServices product)
        {
            _product = product;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> products = new();
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _product.GetAllProductAsync<ResponseDto>(token);

            if (response != null && response.IsSuccess)
            {
                products = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }

            return View(products);
        }

        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _product.CreateProductAsync<ResponseDto>(productDto, token);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("ProductIndex");
                }
            }
            
            return View(productDto);
        }

        public async Task<IActionResult> EditProduct(long id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _product.GetProductByIdAsync<ResponseDto>(id, token);

            if (response != null && response.IsSuccess)
            {
                ProductDto product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));

                return View(product);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _product.UpdateProductAsync<ResponseDto>(productDto, token);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("ProductIndex");
                }
            }

            return View(productDto);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _product.GetProductByIdAsync<ResponseDto>(id, token);

            if (response != null && response.IsSuccess)
            {
                ProductDto product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));

                return View(product);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(ProductDto productDto)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _product.DeleteProductAsync<ResponseDto>(productDto.Id, token);

            if (response.IsSuccess)
            {
                return RedirectToAction("ProductIndex");
            }

            return View(productDto);
        }
    }
}
