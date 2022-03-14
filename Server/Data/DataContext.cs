using CapOverFlow.Shared.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapOverFlow.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryDto>().HasData(
                new CategoryDto { CtgId = 1, CtgName = "Dev", CtgColor = "#3A7CA5", CtgTextColor = "#FFFFFF" },
                new CategoryDto { CtgId = 2, CtgName = "Data", CtgColor = "#D9DCD6", CtgTextColor = "#000000" },
                new CategoryDto { CtgId = 3, CtgName = "Cyber Securite", CtgColor = "#81C3D7", CtgTextColor = "#000000" },
                new CategoryDto { CtgId = 4, CtgName = "IOT", CtgColor = "#16425B", CtgTextColor = "#FFFFFF" }
            );

            modelBuilder.Entity<TagDto>().HasData(
                new TagDto { TagId = 1, TagName = "C#", CtgId = 1 },
                new TagDto { TagId = 2, TagName = "SQL", CtgId = 2 },
                new TagDto { TagId = 3, TagName = "Virus", CtgId = 3 },
                new TagDto { TagId = 4, TagName = "Arduino", CtgId = 4}
            );

            modelBuilder.Entity<UserDto>().HasData(
                new UserDto { UsrId = 1, UsrLastname = "Duquenne", UsrFirstname = "Oceane", UsrMail = "ocefrfane.dqn@gmfrfail.com", UsrExperience = 0 }
            );

            modelBuilder.Entity<TypeDto>().HasData(
                new TypeDto { TypId = 1, TypName = "question" },
                new TypeDto { TypId = 2, TypName = "reponse" },
                new TypeDto { TypId = 3, TypName = "biblio" }
            );

            modelBuilder.Entity<PublicationDto>().HasData(
                new PublicationDto { PbcId = 1, PbcDate = DateTime.Now, PbcResolved = false, TagId = 1, TypId = 1, UsrId = 1, PbcTitle = "Lorem Ipsum", PbcDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                new PublicationDto { PbcId = 2, PbcDate = DateTime.Now, PbcResolved = false, TagId = 2, TypId = 1, UsrId = 1, PbcTitle = "Lorem Ipsum", PbcDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                new PublicationDto { PbcId = 3, PbcDate = DateTime.Now, PbcResolved = true, TagId = 3, TypId = 1, UsrId = 1, PbcTitle = "Lorem Ipsum", PbcDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                new PublicationDto { PbcId = 4, PbcDate = DateTime.Now, PbcResolved = false, TagId = 4, TypId = 1, UsrId = 1, PbcTitle = "Lorem Ipsum", PbcDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                new PublicationDto { PbcId = 5, PbcDate = DateTime.Now, PbcResolved = false, TagId = 1, TypId = 3, UsrId = 1, PbcTitle = "Lorem Ipsum", PbcDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                new PublicationDto { PbcId = 6, PbcDate = DateTime.Now, PbcResolved = false, TagId = 2, TypId = 3, UsrId = 1, PbcTitle = "Lorem Ipsum", PbcDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                new PublicationDto { PbcId = 7, PbcDate = DateTime.Now, PbcResolved = false, TagId = 3, TypId = 3, UsrId = 1, PbcTitle = "Lorem Ipsum", PbcDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                new PublicationDto { PbcId = 8, PbcDate = DateTime.Now, PbcResolved = false, TagId = 4, TypId = 3, UsrId = 1, PbcTitle = "Lorem Ipsum", PbcDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." }
            );

            
        }

        public DbSet<CategoryDto> DbCategory { get; set; }
        public DbSet<TagDto> DbTag { get; set; }
        public DbSet<TypeDto> DbType { get; set; }
        public DbSet<UserDto> DbUser { get; set; }
        public DbSet<PublicationDto> DbPublication { get; set; }
        public DbSet<AttachementDto> DbAttachement { get; set; }
        public DbSet<CommentDto> DbComment { get; set; }
    }
}
