using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace WebApplication1.Models
{
    public partial class MyContext_S18290 : DbContext{
        public MyContext_S18290() {
        }
        public MyContext_S18290(DbContextOptions<MyContext_S18290> options) : base(options){
        }
        private readonly string s = "Data source=db-mssql16.pjwstk.edu.pl;Initial Catalog='s18290';Integrated Security=True";

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientTrip> ClientTrips { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CountryTrip> CountryTrips { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) {
            if (!dbContextOptionsBuilder.IsConfigured)  {
                dbContextOptionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18290;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");
            modelBuilder.Entity<Client>(entity =>{
                entity.HasKey(e => e.IdClient).HasName("Client_pk");
                entity.ToTable("Client");
                entity.Property(e => e.IdClient).ValueGeneratedNever();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(120);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(120);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(120);
                entity.Property(e => e.PESEL).IsRequired().HasMaxLength(120);
                entity.Property(e => e.Telephone).IsRequired().HasMaxLength(120);
            });
            modelBuilder.Entity<ClientTrip>(entity =>{
                entity.HasKey(e => new { e.IdClient, e.IdTrip }).HasName("Client_Trip_pk");
                entity.ToTable("Client_Trip");
                entity.Property(e => e.PaymentDate).HasColumnType("datetime");
                entity.Property(e => e.RegisteredAt).HasColumnType("datetime");
                entity.HasOne(a => a.IdClientNavigation).WithMany(b => b.cTrips).HasForeignKey(c => c.IdClient).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Table_5_Client");
                entity.HasOne(a => a.IdTripNavigation).WithMany(b => b.CleintTrips).HasForeignKey(c => c.IdTrip).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Table_5_Trip");
            });
            modelBuilder.Entity<Country>(entity => {
                entity.HasKey(e => e.IdCountry).HasName("Country_pk");
                entity.ToTable("Country");
                entity.Property(e => e.IdCountry).ValueGeneratedNever();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(120);
            });
            modelBuilder.Entity<CountryTrip>(entity =>{
                entity.HasKey(e => new { e.IdCountry, e.IdTrip }).HasName("Country_Trip_pk");
                entity.ToTable("Country_Trip");
                entity.HasOne(a => a.IdCountryNavigation).WithMany(b => b.CountryTrip).HasForeignKey(c => c.IdCountry).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Country_Trip_Country");
                entity.HasOne(a => a.IdTripNavigation).WithMany(b => b.CountryTrips) .HasForeignKey(c => c.IdTrip).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Country_Trip_Trip");
            });

            modelBuilder.Entity<Trip>(entity =>{
                entity.HasKey(e => e.IdTrip) .HasName("Trip_pk");
                entity.ToTable("Trip");
                entity.Property(e => e.IdTrip).ValueGeneratedNever();
                entity.Property(e => e.DateFrom).HasColumnType("datetime");
                entity.Property(e => e.Dateto).HasColumnType("datetime");
                entity.Property(e => e.Description).IsRequired().HasMaxLength(220);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(120);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}

