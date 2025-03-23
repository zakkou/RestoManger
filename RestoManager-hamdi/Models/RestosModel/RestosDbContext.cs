using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestoManager_hamdi.Models.RestosModel;

namespace RestoManager_hamdi.Models.RestosModel
{
    public class RestosDbContext : DbContext
    {
            
        public RestosDbContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Proprietaire> Proprietaires { get; set; } = null!;
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Proprietaire>PropBuilder = modelBuilder.Entity<Proprietaire>();
            PropBuilder.ToTable("TProprietaire","resto");
            PropBuilder.HasKey(p=>p.Numero);
            PropBuilder.Property(p => p.Nom).HasColumnName("NomProp").HasMaxLength(20).IsRequired();
            PropBuilder.Property(p => p.Email).HasColumnName("EmailProp").HasMaxLength(50).IsRequired();
            PropBuilder.Property(p => p.Gsm).HasColumnName("GsmProp").HasMaxLength(8).IsRequired();

            EntityTypeBuilder<Restaurant> RestoBuilder = modelBuilder.Entity<Restaurant>();
            RestoBuilder.ToTable("TRestaurant", "resto");
            RestoBuilder.HasKey(r => r.CodeResto);
            RestoBuilder.Property(r => r.NomResto).HasMaxLength(20).IsRequired();
            RestoBuilder.Property(r => r.Specialiste).HasColumnName("SpecResto").HasMaxLength(20).IsRequired().HasDefaultValue("Tunisienne");
            RestoBuilder.Property(r => r.Ville).HasColumnName("VilleResto").HasMaxLength(20).IsRequired();
            RestoBuilder.Property(r => r.Tel).HasColumnName("TelResto").HasMaxLength(8).IsRequired();

            EntityTypeBuilder<Avis> AvisBuilder = modelBuilder.Entity<Avis>();
            AvisBuilder.ToTable("TAvis", "admin");
            AvisBuilder.HasKey(a => a.CodeAvis);
            AvisBuilder.Property(a => a.NomPersonne).HasMaxLength(30);
            AvisBuilder.Property(a => a.Note).HasMaxLength(20).IsRequired();
            AvisBuilder.Property(a => a.Commentaire).HasMaxLength(20).IsRequired();

            PropBuilder.HasMany(p=>p.LesRestos).WithOne(r=>r.LeProprio).HasForeignKey(r=>r.NumProp).HasConstraintName("Relation_Proprio_Restos");


        }
       
        public DbSet<RestoManager_hamdi.Models.RestosModel.Avis>? Avis { get; set; }
       

    }
}

