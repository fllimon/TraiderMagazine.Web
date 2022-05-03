using Microsoft.EntityFrameworkCore;
using TraiderMagazine.ProductAPI.Models;

namespace TraiderMagazine.ProductAPI.DbContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> option)
            : base(option)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "M4A1-S",
                CategoryName = "Штурмовые винтовки",
                Description = "Бесшумный карабин M4A1 оснащен менее вместительным магазином",
                ImageUrl = "https://1drv.ms/u/s!AgoI2Zxw869CwSgpfHSfUziogxWM?e=bv6Pna",
                Price = 116
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Сувенирный M4A1-S",
                CategoryName = "Штурмовые винтовки",
                Description = "Бесшумный карабин M4A1 оснащен менее вместительным магазином. Смешанный камуфляж",
                ImageUrl = "https://1drv.ms/u/s!AgoI2Zxw869CwSrcvNa-z1INBRwL?e=bZrenf",
                Price = 250
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "M4A1-S | Василиск",
                CategoryName = "Штурмовые винтовки",
                Description = "Бесшумный карабин M4A1 оснащен менее вместительным магазином. На оружие нанесено изображение василиска",
                ImageUrl = "https://1drv.ms/u/s!AgoI2Zxw869CwSkJL3PXWFcD1bFB?e=regYTd",
                Price = 200
            });
        }
    }
}
