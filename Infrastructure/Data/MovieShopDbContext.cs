using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Trailers> Trailers { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<MovieCast> MovieCast { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<Users>(ConfigureUsers);
            modelBuilder.Entity<Favorites>(ConfigureFavorites);
            modelBuilder.Entity<UserRoles>(ConfigureUserRoles);
            modelBuilder.Entity<Reviews>(ConfigureReviews);
            modelBuilder.Entity<Purchases>(ConfigurePurchases);
            modelBuilder.Entity<Cast>(ConfigureCast);
        }

        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.ToTable("MovieGenres");
            builder.HasKey(mg => new { mg.MovieId, mg.GenreId });
        }
        
        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCasts");
            builder.HasKey(mg => new { mg.MovieId, mg.Character, mg.CastId });
        }
        
        private void ConfigureFavorites(EntityTypeBuilder<Favorites> builder)
        {
            builder.HasKey(mg => new { mg.MovieId, mg.UserId });
        }
        private void ConfigureUserRoles(EntityTypeBuilder<UserRoles> builder)
        {
            builder.HasKey(mg => new { mg.RoleId, mg.UserId });
        }
     
        private void ConfigureReviews(EntityTypeBuilder<Reviews> builder)
        {
            builder.HasKey(mg => new { mg.MovieId, mg.UserId });
            builder.Property(m => m.Rating).HasColumnType("decimal(3, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
        }
        
        private void ConfigurePurchases(EntityTypeBuilder<Purchases> builder)
        {
            builder.ToTable("Purchases");
            builder.HasKey(mg => new { mg.MovieId, mg.UserId });
            builder.Property(m => m.TotalPrice).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
        }

        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Casts");
        }


        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            // specify all the Fluent API rules
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(512);
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.UpdatedBy).HasMaxLength(512);
            builder.Property(m => m.CreatedBy).HasMaxLength(512);

            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");

            // you want the property in your C# for your business logic not as column in database
            builder.Ignore(m => m.Rating);

            builder.HasIndex(m => m.Title);
            builder.HasIndex(m => m.Price);
            builder.HasIndex(m => m.Revenue);
            builder.HasIndex(m => m.Budget);


        }
        
        private void ConfigureUsers(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Email).HasMaxLength(256);
            builder.Property(m => m.FirstName).HasMaxLength(128);
            builder.Property(m => m.HashedPassword).HasMaxLength(1024);
            builder.Property(m => m.LastName).HasMaxLength(128);
            builder.Property(m => m.PhoneNumber).HasMaxLength(16);
            builder.Property(m => m.Salt).HasMaxLength(1024);
            builder.Property(m => m.IsLocked).HasMaxLength(1);
        }

    }
}