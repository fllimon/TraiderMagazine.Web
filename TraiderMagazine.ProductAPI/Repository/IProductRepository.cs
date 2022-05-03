using TraiderMagazine.ProductAPI.Models.Dto;

namespace TraiderMagazine.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();

        Task<ProductDto> GetProductById(long id);
        
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);

        Task<bool> DeleteProduct(long id);
    }
}
