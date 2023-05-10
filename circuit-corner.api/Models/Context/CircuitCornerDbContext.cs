using Microsoft.EntityFrameworkCore;
using circuit_corner.api.Models.DTO;

namespace circuit_corner.api.Models.Context {
    public class CircuitCornerDbContext:DbContext {
        public CircuitCornerDbContext(DbContextOptions<CircuitCornerDbContext> options) : base(options) {
        
        }

        public DbSet<Product> Products { get; set; } = null;
        public DbSet<ProductCategory> ProductCategories { get; set; } = null;
        public DbSet<User> Users { get; set; } = null;
        public DbSet<circuit_corner.api.Models.DTO.ProductDTO> ProductDTO { get; set; } = default!;
        public DbSet<circuit_corner.api.Models.DTO.ProductCategoryDTO> ProductCategoryDTO { get; set; } = default!;
        public DbSet<circuit_corner.api.Models.DTO.UserDTO> UserDTO { get; set; } = default!;

    }
}
