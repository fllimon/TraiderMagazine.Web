using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraiderMagazine.ProductAPI.Models.Dto;
using TraiderMagazine.ProductAPI.Repository;

namespace TraiderMagazine.ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductApiController : ControllerBase
    {
        private ResponseDto _response;
        private IProductRepository _repository;

        public ProductApiController(IProductRepository repository)
        {
            _repository = repository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productsDto = await _repository.GetAllProducts();
                _response.Result = productsDto;

                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string> { ex.ToString() };

                return _response;
            }
        }

        [HttpGet("{id}")]
        public async Task<object> Get(long id)
        {
            try
            {
                ProductDto productDto = await _repository.GetProductById(id);
                _response.Result = productDto;

                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string> { ex.ToString() };

                return _response;
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _repository.CreateUpdateProduct(productDto);
                _response.Result = model;

                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string> { ex.ToString() };

                return _response;
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _repository.CreateUpdateProduct(productDto);
                _response.Result = model;

                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string> { ex.ToString() };

                return _response;
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<object> Delete(long id)
        {
            try
            {
                bool isSuccess = await _repository.DeleteProduct(id);
                _response.Result = isSuccess;

                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string> { ex.ToString() };

                return _response;
            }
        }
    }
}
