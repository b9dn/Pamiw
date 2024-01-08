using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using P06Shop.Shared.Auth;
using P06Shop.Shared.Shop;
using P07Shop.DataSeeder;
using P05Shop.API.Services.AuthService;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

namespace P05Shop.API.Models
{
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<FilmSuppliers> FilmSuppliers { get; set; }

        public DbSet<FilmDetails> FilmDetails { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // fluent api 
            // film 
            modelBuilder.Entity<Film>()
                .Property(p => p.Barcode)
                .IsRequired()
                .HasMaxLength(12);

            modelBuilder.Entity<Film>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Film>()
             .Property(p => p.Price)
             .HasColumnType("decimal(8,2)");

            modelBuilder.Entity<Film>()
                 .HasOne(p => p.Category)
                 .WithMany(c => c.Films);

            modelBuilder.Entity<Film>()
                .HasMany(p => p.FilmSuppliers)
                .WithOne(ps => ps.Film)
                .HasForeignKey(ps => ps.FilmId);

            modelBuilder.Entity<Film>()
            .HasOne(p => p.FilmDetails)
            .WithOne(d => d.Film)
            .HasForeignKey<FilmDetails>(d => d.FilmId);

            // category 
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Films)
                .WithOne(p => p.Category);

            // supplier 
            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.FilmSuppliers)
                .WithOne(ps => ps.Supplier)
                .HasForeignKey(ps => ps.SupplierId);

            // filmsupplier
            modelBuilder.Entity<FilmSuppliers>()
                .HasKey(ps => new { ps.FilmId, ps.SupplierId });


            // filmdetails
            modelBuilder.Entity<FilmDetails>()
                .HasKey(pd => pd.FilmId);

            // data seed 

            modelBuilder.Entity<Film>().HasData(FilmSeeder.GenerateFilmData());
            modelBuilder.Entity<User>().HasData(MakeRootUser());
        }


        private User MakeRootUser() {
            byte[] passwordHash;
            byte[] passwordSalt;
            AuthService.CreatePasswordHash("root", out passwordHash, out passwordSalt);
            return new User {
                Id = 1,
                Username = "root",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Email = "root@root",
                Role = "Admin",
                DateCreated = DateTime.Now
            };
        }
    }
}
// instalacja dotnet ef 
//dotnet tool install --global dotnet-ef

// aktualizacja 
//dotnet tool update --global dotnet-ef

// dotnet ef migrations add [nazwa_migracji]
// dotnet ef database update 
// dotnet ef database update -- --environment Production

// cofniecie migraji niezaplikowanych 
//dotnet ef migrations remove