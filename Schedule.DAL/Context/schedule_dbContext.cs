using Microsoft.EntityFrameworkCore;
using ScheduleProject.DAL.Entities;

namespace ScheduleProject.DAL.Context
{
    public partial class schedule_dbContext : DbContext
    {
        public schedule_dbContext()
        {
        }

        public schedule_dbContext(DbContextOptions<schedule_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ScheduleModel> Schedule { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=projectschedule.mysql.database.azure.com; Port=3306; Database=schedule_db; Uid=dimash@projectschedule; Pwd=Dinmukhamed!; SslMode=Preferred;", x => x.ServerVersion("8.0.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduleModel>(entity =>
            {
                entity.ToTable("schedule");

                entity.HasIndex(e => e.Class)
                    .HasName("class_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasColumnName("class")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Day).HasColumnName("day");

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasColumnName("group")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SubjectEnd)
                    .HasColumnName("subject_end")
                    .HasColumnType("time");

                entity.Property(e => e.SubjectStart)
                    .HasColumnName("subject_start")
                    .HasColumnType("time");

                entity.Property(e => e.Teacher).HasColumnName("teacher");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Course).HasColumnName("course");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Group)
                    .HasColumnName("group")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("passwordhash")
                    .HasColumnType("blob");

                entity.Property(e => e.PasswordSalt)
                    .HasColumnName("passwordsalt")
                    .HasColumnType("blob");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}