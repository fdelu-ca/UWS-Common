using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using ArcelorMittal.UnifiedWeightSystem.Common.Documentation;
using ArcelorMittal.UnifiedWeightSystem.Common.Log;
using ArcelorMittal.UnifiedWeightSystem.Common.RecognitionProcess;
using ArcelorMittal.UnifiedWeightSystem.Common.Sites;
using ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess;
using Microsoft.EntityFrameworkCore;

namespace ArcelorMittal.UnifiedWeightSystem.Common.DbContext
{
    public partial class UwsDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //Documentation
        public virtual DbSet<StageHistory> StageHistories { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }        
        public virtual DbSet<VehicleProperty> VehicleProperties { get; set; }        
        public virtual DbSet<VehiclePropertyType> VehiclePropertyTypes { get; set; }        

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
        public virtual DbSet<WeightCollection> WeightCollections { get; set; }
        public virtual DbSet<WeightCollectionProperty> WeightCollectionProperties  { get; set; }

        public virtual DbSet<WeightElement> WeightElements  { get; set; }
        public virtual DbSet<WeightElementProperty> WeightElementProperties  { get; set; }
        public virtual DbSet<WeightPropertyType> WeightPropertyTypes  { get; set; }

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
                optionsBuilder.UseSqlServer("Server=HOME-PC\\SQLEXPRESS;Database=KRR-PA-ISA95_PRODUCTION;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeightCollection>()
                .HasMany(sh => sh.WeightElements)
                .WithOne(el => el.WeightCollection)
                .HasForeignKey(el => el.WeightCollectionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ShipmentId_Shipments");
            
            modelBuilder.Entity<WeightElement>()
                .HasOne(el =>el.WeightCollection)
                .WithMany(sh => sh.WeightElements)
                .HasForeignKey(el => el.WeightCollectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShipmentId_Shipments");

            modelBuilder.Entity<StageHistory>()
                .HasOne(x => x.LastStage)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}