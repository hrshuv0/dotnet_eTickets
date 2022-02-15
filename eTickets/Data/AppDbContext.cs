using eTickets.Models;
using eTickets.Models.Shopping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });
            modelBuilder.Entity<ActorMovie>()
                .HasOne(m => m.Movie)
                .WithMany(am => am.ActorsMovies)
                .HasForeignKey(m => m.MovieId);
            
            modelBuilder.Entity<ActorMovie>()
                .HasOne(a => a.Actor)
                .WithMany(am => am.ActorsMovies)
                .HasForeignKey(a => a.ActorId);
            
            
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        
        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}

// "DefaultConnectionString" : "Server=tcp:hrshuvo-etickets.database.windows.net,1433;Initial Catalog=etickets-app-db;Persist Security Info=False;User ID=etickets-admin;Password=shuvo123#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"