using Microsoft.EntityFrameworkCore;
using CapOverFlow.Shared;
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
            modelBuilder.Entity<IncludeDto>().HasNoKey();      
        }
        public DbSet<TagsDto> Tags { get; set; }

        public DbSet<UserDto> Users { get; set; }

        public DbSet<TypeDto> Types { get; set; }

        public DbSet<PublicationDto> Publications { get; set; }

        public DbSet<IncludeDto> Includes { get; set; }

        public DbSet<AttachementDto> Attachements { get; set; }


    }
}
