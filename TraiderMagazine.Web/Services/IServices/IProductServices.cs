using TraiderMagazine.Web.Models.Dto;

namespace TraiderMagazine.Web.Services.IServices
{
    public interface IProductServices : IBaseService
    {
        Task<T> GetAllProductAsync<T>(string token);
        Task<T> GetProductByIdAsync<T>(long id, string token);
        Task<T> CreateProductAsync<T>(ProductDto productDto, string token);
        Task<T> UpdateProductAsync<T>(ProductDto productDto, string token);
        Task<T> DeleteProductAsync<T>(long id, string token);
    }
}
