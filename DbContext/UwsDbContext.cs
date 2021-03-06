﻿using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using ArcelorMittal.UnifiedWeightSystem.Common.Documentation;
using ArcelorMittal.UnifiedWeightSystem.Common.DiagnosticProcess;
using ArcelorMittal.UnifiedWeightSystem.Common.RecognitionProcess;
using ArcelorMittal.UnifiedWeightSystem.Common.Sites;
using ArcelorMittal.UnifiedWeightSystem.Common.WeightingProcess;
using Microsoft.EntityFrameworkCore;
using ArcelorMittal.UnifiedWeightSystem.Common.ChainOfStages;

namespace ArcelorMittal.UnifiedWeightSystem.Common.DbContext
{
    public partial class UwsDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //Documentation
        // public virtual DbSet<StageHistory> StageHistories { get; set; }
        // public virtual DbSet<Vehicle> Vehicles { get; set; }        
        // public virtual DbSet<VehicleProperty> VehicleProperties { get; set; }        
        // public virtual DbSet<VehiclePropertyType> VehiclePropertyTypes { get; set; }        

        //Diagnostic Process
        public virtual DbSet<LogData> ServiceLog { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<StatusType> StatusTypes{ get; set; }

        //RecognitionProcess
        //Todo Add Recognition in DB

        //StageProcess
        public virtual DbSet<ProcessCellStage> ProcessCellStages { get; set; }

        //Sites
        //public virtual DbSet<Shop> Shops  { get; set; }
        //public virtual DbSet<ShopProperty> ShopProperties  { get; set; }
        //public virtual DbSet<ShopPropertyType> ShopPropertyTypes  { get; set; }

        //public virtual DbSet<Station> Stations  { get; set; }
        //public virtual DbSet<StationProperty> StationProperties  { get; set; }
        //public virtual DbSet<StationPropertyType> StationPropertyTypes  { get; set; }

        //Weighting Process
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

            Database.SetCommandTimeout(60);
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=KRR-tst-pahwl02;Database=KRR-PA-ISA95_PRODUCTION;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=KRR-SQL-PACLX02;Database=KRR-PA-ISA95_PRODUCTION;Trusted_Connection=True;");
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
            
            modelBuilder.Entity<WeightingPropertyType>()
                .HasIndex(u => u.Key)
                .IsUnique();
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}