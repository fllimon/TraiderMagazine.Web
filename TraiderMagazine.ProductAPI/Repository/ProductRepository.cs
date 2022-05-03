using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TraiderMagazine.ProductAPI.DbContexts;
using TraiderMagazine.ProductAPI.Models;
using TraiderMagazine.ProductAPI.Models.Dto;

namespace TraiderMagazine.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _db;
        private IMapper _mapper;

        public ProductRepository(ProductContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);

            if (product.Id > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            
            await _db.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(long id)
        {
            try
            {
                Product product = await _db.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (product == null)
                {
                    return false;
                }

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            IEnumerable<Product> products = await _db.Products.ToListAsync();

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductById(long id)
        {
            Product product = await _db.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<ProductDto>(product);
        }
    }
}
