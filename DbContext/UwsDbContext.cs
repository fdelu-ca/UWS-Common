using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using ArcelorMittal.UnifiedWeightSystem.Common.Documentation;
using ArcelorMittal.UnifiedWeightSystem.Common.Logging;
using ArcelorMittal.UnifiedWeightSystem.Common.RecognitionProcess;
using ArcelorMittal.UnifiedWeightSystem.Common.Sites;
using ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess;
using Microsoft.EntityFrameworkCore;

namespace ArcelorMittal.UnifiedWeightSystem.Common.DbContext
{
    public partial class UwsDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //Documentation
        // public virtual DbSet<StageHistory> StageHistories { get; set; }
        // public virtual DbSet<Vehicle> Vehicles { get; set; }        
        // public virtual DbSet<VehicleProperty> VehicleProperties { get; set; }        
        // public virtual DbSet<VehiclePropertyType> VehiclePropertyTypes { get; set; }        

        //Log
        public virtual DbSet<UwsLog> UwsLogs { get; set; }
        public virtual DbSet<UwsLogDetail> UwsLogDetails { get; set; }
        public virtual DbSet<UwsLogType> UwsLogTypes { get; set; }

        //RecognitionProcess
        //Todo Add Recognition in DB
        
        //Sites
        //public virtual DbSet<Shop> Shops  { get; set; }
        //public virtual DbSet<ShopProperty> ShopProperties  { get; set; }
        //public virtual DbSet<ShopPropertyType> ShopPropertyTypes  { get; set; }

        //public virtual DbSet<Station> Stations  { get; set; }
        //public virtual DbSet<StationProperty> StationProperties  { get; set; }
        //public virtual DbSet<StationPropertyType> StationPropertyTypes  { get; set; }

        //WeightingProcess
        public virtual DbSet<WeightingCollection> WeightingCollections { get; set; }
        public virtual DbSet<WeightingCollectionProperty> WeightingCollectionProperties  { get; set; }

        public virtual DbSet<WeightingElement> WeightingElements { get; set; }
        public virtual DbSet<WeightingElementProperty> WeightingElementProperties { get; set; }
        public virtual DbSet<WeightingPropertyType> WeightingPropertyTypes { get; set; }

        public UwsDbContext()
        {
        }

        public UwsDbContext(DbContextOptions<UwsDbContext> options)
            : base(options)
        {
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=KRR-TST-PAHWL02;Database=KRR-PA-ISA95_PRODUCTION;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeightingCollection>()
                .HasMany(sh => sh.WeightingElements)
                .WithOne(el => el.WeightingCollection)
                .HasForeignKey(el => el.WeightingCollectionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ShipmentId_Shipments");
            
            modelBuilder.Entity<WeightingElement>()
                .HasOne(el =>el.WeightingCollection)
                .WithMany(sh => sh.WeightingElements)
                .HasForeignKey(el => el.WeightingCollectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShipmentId_Shipments");

            modelBuilder.Entity<StageHistory>()
                .HasOne(x => x.LastStage)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<UwsLogType>()
                .HasIndex(u => u.Key)
                .IsUnique();
            modelBuilder.Entity<WeightingPropertyType>()
                .HasIndex(u => u.Key)
                .IsUnique();
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}