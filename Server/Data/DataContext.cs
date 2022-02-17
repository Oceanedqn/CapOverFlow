using System;
using Microsoft.EntityFrameworkCore;
using CapOverFlow.Shared.Models;

#nullable disable

namespace CapOverFlow.Server.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttachementDto> Attachement { get; set; }
        public virtual DbSet<CategoryDto> Category { get; set; }
        public virtual DbSet<IncludeDto> Include { get; set; }
        public virtual DbSet<LogDto> Log { get; set; }
        public virtual DbSet<PublicationDto> Publication { get; set; }
        public virtual DbSet<TagDto> Tag { get; set; }
        public virtual DbSet<TypeDto> Type { get; set; }
        public virtual DbSet<UserDto> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CapOverFlow;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=CapOverFlow;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AttachementDto>(entity =>
            {
                entity.HasKey(e => e.ATC_id)
                    .HasName("T_Attachement_ATC_PK");

                entity.ToTable("T_Attachement_ATC");

                entity.Property(e => e.ATC_id).HasColumnName("ATC_id");

                entity.Property(e => e.ATC_content)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ATC_content");

                entity.Property(e => e.ATC_date)
                    .HasColumnType("datetime")
                    .HasColumnName("ATC_date");

                entity.Property(e => e.ATC_name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ATC_name");

                entity.Property(e => e.PBC_id).HasColumnName("PBC_id");

                entity.HasOne(d => d.Publication)
                    .WithMany(p => p.Attachements)
                    .HasForeignKey(d => d.PBC_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("T_Attachement_ATC_T_Publication_PBC_FK");
            });

            modelBuilder.Entity<CategoryDto>(entity =>
            {
                entity.HasKey(e => e.CTG_id)
                    .HasName("T_CATEGORIES_CTG_PK");

                entity.ToTable("T_Categories_CTG");

                entity.Property(e => e.CTG_id).HasColumnName("CTG_id");

                entity.Property(e => e.CTG_color)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CTG_color");

                entity.Property(e => e.CTG_name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CTG_name");
            });

            modelBuilder.Entity<IncludeDto>(entity =>
            {
                entity.HasKey(e => new { e.TAG_id, e.PBC_id })
                    .HasName("INCLUDE_PK");

                entity.ToTable("T_Include_ICD");

                entity.Property(e => e.TAG_id).HasColumnName("TAG_id");

                entity.Property(e => e.PBC_id).HasColumnName("PBC_id");

                entity.HasOne(d => d.Publication)
                    .WithMany(p => p.Includes)
                    .HasForeignKey(d => d.PBC_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("T_Include_ICD_T_Publication_PBC0_FK");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Includes)
                    .HasForeignKey(d => d.TAG_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("T_Include_ICD_T_Tags_TAG_FK");
            });

            modelBuilder.Entity<LogDto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_Logs_LOG");

                entity.Property(e => e.LogDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOG_description");

                entity.Property(e => e.LogId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOG_id");

                entity.Property(e => e.LogTitle)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("LOG_title");
            });

            modelBuilder.Entity<PublicationDto>(entity =>
            {
                entity.HasKey(e => e.PBC_id)
                    .HasName("T_Publication_PBC_PK");

                entity.ToTable("T_Publication_PBC");

                entity.Property(e => e.PBC_id).HasColumnName("PBC_id");

                entity.Property(e => e.PBC_description)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PBC_description");

                entity.Property(e => e.PBC_resolved).HasColumnName("PBC_resolved");

                entity.Property(e => e.PBC_title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PBC_title");

                entity.Property(e => e.QST_date)
                    .HasColumnType("datetime")
                    .HasColumnName("QST_date");

                entity.Property(e => e.TYP_id).HasColumnName("TYP_id");

                entity.Property(e => e.USR_id).HasColumnName("USR_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.TYP_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("T_Publication_PBC_T_Type_TYP_FK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.USR_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("T_Publication_PBC_T_User_USR_FK");

                entity.HasMany(i => i.Includes)
                    .WithOne();
            });

            modelBuilder.Entity<TagDto>(entity =>
            {
                entity.HasKey(e => e.TAG_id)
                    .HasName("T_Tags_TAG_PK");

                entity.ToTable("T_Tags_TAG");

                entity.Property(e => e.TAG_id).HasColumnName("TAG_id");

                entity.Property(e => e.CTG_id).HasColumnName("CTG_id");

                entity.Property(e => e.TAG_name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TAG_name");

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.CTG_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("T_Tags_TAG_T_CATEGORIES_CTG_FK");
            });

            modelBuilder.Entity<TypeDto>(entity =>
            {
                entity.HasKey(e => e.TYP_id)
                    .HasName("T_Type_TYP_PK");

                entity.ToTable("T_Type_TYP");

                entity.Property(e => e.TYP_id).HasColumnName("TYP_id");

                entity.Property(e => e.TYP_name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TYP_name");
            });

            modelBuilder.Entity<UserDto>(entity =>
            {
                entity.HasKey(e => e.USR_id)
                    .HasName("T_User_USR_PK");

                entity.ToTable("T_User_USR");

                entity.Property(e => e.USR_id).HasColumnName("USR_id");

                entity.Property(e => e.USR_experience).HasColumnName("USR_experience");

                entity.Property(e => e.USR_firstname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_firstname");

                entity.Property(e => e.USR_lastname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_lastname");

                entity.Property(e => e.USR_mail)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("USR_mail");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
