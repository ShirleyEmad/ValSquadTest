using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ValSquadTest.Models
{
    public partial class ValTestContext : DbContext
    {
        public ValTestContext()
        {
        }

        public ValTestContext(DbContextOptions<ValTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ParkingAccessCard> ParkingAccessCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=.;Database=ValTest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.PlateNumber);

                entity.ToTable("Car");

                entity.Property(e => e.PlateNumber).HasColumnName("plateNumber");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("brand");

                entity.Property(e => e.CardId).HasColumnName("cardID");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.Model).HasColumnName("model");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CardId)
                    .HasConstraintName("FK_Car_ParkingAccessCard");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Car_Employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("position");
            });

            modelBuilder.Entity<ParkingAccessCard>(entity =>
            {
                entity.ToTable("ParkingAccessCard");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasDefaultValueSql("((10))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
