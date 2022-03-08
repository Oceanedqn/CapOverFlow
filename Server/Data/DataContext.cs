using System;
using Microsoft.EntityFrameworkCore;
using CapOverFlow.Shared.Dto;

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

        public virtual DbSet<AttachementDto> AttachementsDb { get; set; }
        public virtual DbSet<CategoryDto> CategoriesDb { get; set; }
        public virtual DbSet<LogsDto> LogsDb { get; set; }
        public virtual DbSet<PublicationDto> PublicationsDb { get; set; }
        public virtual DbSet<TagDto> TagsDb { get; set; }
        public virtual DbSet<TypeDto> TypesDb { get; set; }
        public virtual DbSet<UserDto> UsersDb { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { 
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CapOverFlow;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AttachementDto>(entity =>
            {
                entity.HasKey(e => e.AtcId)
                    .HasName("attachement_ATC_PK");

                entity.ToTable("attachement_ATC");

                entity.Property(e => e.AtcId).HasColumnName("ATC_id");

                entity.Property(e => e.AtcContent)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ATC_content");

                entity.Property(e => e.AtcDate).HasColumnName("ATC_date");

                entity.Property(e => e.AtcName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ATC_name");

                entity.Property(e => e.PbcId).HasColumnName("PBC_id");

                //entity.HasOne(d => d.Pbc)
                //    .WithMany(p => p.AttachementAtcs)
                //    .HasForeignKey(d => d.PbcId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("attachement_ATC_publication_PBC_FK");
            });

            modelBuilder.Entity<CategoryDto>(entity =>
            {
                entity.HasKey(e => e.CtgId)
                    .HasName("category_CTG_PK");

                entity.ToTable("category_CTG");

                entity.Property(e => e.CtgId).HasColumnName("CTG_id");

                entity.Property(e => e.CtgColor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CTG_color");

                entity.Property(e => e.CtgName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CTG_name");
            });

            modelBuilder.Entity<LogsDto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("logs_LOG");

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
                entity.HasKey(e => e.PbcId)
                    .HasName("publication_PBC_PK");

                entity.ToTable("publication_PBC");

                entity.Property(e => e.PbcId).HasColumnName("PBC_id");

                entity.Property(e => e.PbcDate)
                    .HasColumnType("datetime")
                    //.IsRequired()
                    //.HasMaxLength(40)
                    //.IsUnicode(false)
                    .HasColumnName("PBC_date");

                entity.Property(e => e.PbcDescription)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("PBC_description");

                entity.Property(e => e.PbcResolved).HasColumnName("PBC_resolved");

                entity.Property(e => e.PbcTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PBC_title");

                entity.Property(e => e.TagId).HasColumnName("TAG_id");

                entity.Property(e => e.TypId).HasColumnName("TYP_id");

                entity.Property(e => e.UsrId).HasColumnName("USR_id");

                //entity.HasOne(d => d.Tag)
                //    .WithMany(p => p.PublicationPbcs)
                //    .HasForeignKey(d => d.TagId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("publication_PBC_tag_TAG_FK");

                //entity.HasOne(d => d.Typ)
                //    .WithMany(p => p.PublicationPbcs)
                //    .HasForeignKey(d => d.TypId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("publication_PBC_type_TYP1_FK");

                //entity.HasOne(d => d.Usr)
                //    .WithMany(p => p.PublicationPbcs)
                //    .HasForeignKey(d => d.UsrId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("publication_PBC_user_USR0_FK");
            });

            modelBuilder.Entity<TagDto>(entity =>
            {
                entity.HasKey(e => e.TagId)
                    .HasName("tag_TAG_PK");

                entity.ToTable("tag_TAG");

                entity.Property(e => e.TagId).HasColumnName("TAG_id");

                entity.Property(e => e.CtgId).HasColumnName("CTG_id");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TAG_name");

                //entity.HasOne(d => d.Ctg)
                //    .WithMany(p => p.TagTags)
                //    .HasForeignKey(d => d.CtgId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("tag_TAG_category_CTG_FK");
            });

            modelBuilder.Entity<TypeDto>(entity =>
            {
                entity.HasKey(e => e.TypId)
                    .HasName("type_TYP_PK");

                entity.ToTable("type_TYP");

                entity.Property(e => e.TypId).HasColumnName("TYP_id");

                entity.Property(e => e.TypName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TYP_name");
            });

            modelBuilder.Entity<UserDto>(entity =>
            {
                entity.HasKey(e => e.UsrId)
                    .HasName("user_USR_PK");

                entity.ToTable("user_USR");

                entity.Property(e => e.UsrId).HasColumnName("USR_id");

                entity.Property(e => e.UsrExperience).HasColumnName("USR_experience");

                entity.Property(e => e.UsrFirstname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_firstname");

                entity.Property(e => e.UsrLastname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR_lastname");

                entity.Property(e => e.UsrMail)
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
