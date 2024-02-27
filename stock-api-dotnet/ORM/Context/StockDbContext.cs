using Microsoft.EntityFrameworkCore;
using stock_api_dotnet.ORM.Models.Category;
using stock_api_dotnet.ORM.Models.Paciente;
using stock_api_dotnet.ORM.Models.Product;
using stock_api_dotnet.ORM.Models.User;

namespace stock_api_dotnet.ORM.Context
{
    public class StockDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public StockDbContext(DbContextOptions<StockDbContext> options, IConfiguration configuration) : base(options) => _configuration = configuration;
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PacienteModel> Pacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region product
            modelBuilder.Entity<ProductModel>().HasKey(c => c.Product_id);
            modelBuilder.Entity<ProductModel>().Property(c => c.Name).HasMaxLength(255);
            modelBuilder.Entity<ProductModel>().Property(c => c.Description).HasMaxLength(255);            
            modelBuilder.Entity<ProductModel>().Property(c => c.Amount).
                IsRequired().
                HasPrecision(14, 2);
            #endregion product

            #region category
            modelBuilder.Entity<CategoryModel>().HasKey(c => c.Category_id);
            modelBuilder.Entity<CategoryModel>().Property(c => c.Name)
               .HasMaxLength(255)
               .IsRequired();

            #endregion category

            #region user
            modelBuilder.Entity<UserModel>().HasKey(u => u.Id);
            modelBuilder.Entity<UserModel>().Property(u => u.UserName).HasMaxLength(255);
            modelBuilder.Entity<UserModel>().Property(u => u.Email).HasMaxLength(255);
            modelBuilder.Entity<UserModel>().Property(u => u.Password).HasMaxLength(255);
            #endregion user

            #region pacientes
            modelBuilder.Entity<PacienteModel>()
            .HasKey(p => p.Id);
            modelBuilder.Entity<PacienteModel>()
                .Property(p => p.Name).HasMaxLength(255);
            modelBuilder.Entity<PacienteModel>()
                .Property(p => p.Email).HasMaxLength(255);
            modelBuilder.Entity<PacienteModel>()
                .Property(p => p.Phone).HasMaxLength(255);
            modelBuilder.Entity<PacienteModel>()
                .Property(p => p.City).HasMaxLength(255);
            modelBuilder.Entity<PacienteModel>()
                .Property(p => p.Adress).HasMaxLength(255);
            #endregion pacientes


            //Relacionamento
            modelBuilder.Entity<ProductModel>()
             .HasOne(p => p.Category);

            // Relacionamento Um-Para-Muitos
            modelBuilder.Entity<UserModel>()
             .HasMany(m => m.Pacientes)
             .WithOne(p => p.Medico)  
             .HasForeignKey(p => p.MedicoId);



        }

    }
}
