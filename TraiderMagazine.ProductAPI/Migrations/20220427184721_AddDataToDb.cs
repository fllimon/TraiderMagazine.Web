using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TraiderMagazine.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Штурмовые винтовки", "Бесшумный карабин M4A1 оснащен менее вместительным магазином", "https://1drv.ms/u/s!AgoI2Zxw869CwSgpfHSfUziogxWM?e=bv6Pna", "M4A1-S", 116.0 },
                    { 2L, "Штурмовые винтовки", "Бесшумный карабин M4A1 оснащен менее вместительным магазином. Смешанный камуфляж", "https://1drv.ms/u/s!AgoI2Zxw869CwSrcvNa-z1INBRwL?e=bZrenf", "Сувенирный M4A1-S", 250.0 },
                    { 3L, "Штурмовые винтовки", "Бесшумный карабин M4A1 оснащен менее вместительным магазином. На оружие нанесено изображение василиска", "https://1drv.ms/u/s!AgoI2Zxw869CwSkJL3PXWFcD1bFB?e=regYTd", "M4A1-S | Василиск", 200.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
