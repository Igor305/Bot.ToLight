using DataAccessLayer.Entities.NetMonitoring;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccessLayer.AppContext
{
    public partial class NetMonitoringContext : DbContext
    {
        public NetMonitoringContext()
        {
        }

        public NetMonitoringContext(DbContextOptions<NetMonitoringContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Monitoring> Monitorings { get; set; }
        public virtual DbSet<Monitoring1> Monitorings1 { get; set; }
        public virtual DbSet<RStock> RStocks { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=sql08;Initial Catalog=NetMonitoring;Persist Security Info=True;User ID=j-sql08-read-NetMonitoring;Password=9g0sl3l9z1l0;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("Device");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DevicePrefiks)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Monitoring>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Monitoring");

                entity.HasIndex(e => new { e.Device, e.Stock, e.LogTime }, "CIDX-dbo-Monitoring")
                    .IsClustered();

                entity.Property(e => e.Device)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.Ttl).HasColumnName("TTL");
            });

            modelBuilder.Entity<Monitoring1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Monitoring", "history");

                entity.Property(e => e.Device)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.Ttl).HasColumnName("TTL");
            });

            modelBuilder.Entity<RStock>(entity =>
            {
                entity.HasKey(e => e.StockId);

                entity.ToTable("r_Stock");

                entity.Property(e => e.StockId)
                    .ValueGeneratedNever()
                    .HasColumnName("StockID");

                entity.Property(e => e.StockName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Network)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StockId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("StockID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
