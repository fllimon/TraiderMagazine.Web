using TraiderMagazine.Web.Models;
using TraiderMagazine.Web.Models.Dto;
using TraiderMagazine.Web.Services.IServices;

namespace TraiderMagazine.Web.Services
{
    public class ProductService : BaseServise, IProductServices
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
        {
            return await SendAsync<T>(new ApiRequest
            {
                Type = MetaData.ApiType.POST,
                Data = productDto,
                Url = MetaData.ApiUrl + "/ProductApi",
                AccessToken = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(long id, string token)
        {
            return await SendAsync<T>(new ApiRequest
            {
                Type = MetaData.ApiType.DELETE,
                Url = MetaData.ApiUrl + "/ProductApi/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetAllProductAsync<T>(string token)
        {
            return await SendAsync<T>(new ApiRequest
            {
                Type = MetaData.ApiType.GET,
                Url = MetaData.ApiUrl + "/ProductApi",
                AccessToken = token
            });
        }

        public async Task<T> GetProductByIdAsync<T>(long id, string token)
        {
            return await SendAsync<T>(new ApiRequest
            {
                Type = MetaData.ApiType.GET,
                Url = MetaData.ApiUrl + "/ProductApi/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
        {
            return await SendAsync<T>(new ApiRequest
            {
                Type = MetaData.ApiType.POST,
                Data = productDto,
                Url = MetaData.ApiUrl + "/ProductApi",
                AccessToken = token
            });
        }
    }
}
