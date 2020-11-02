using Microsoft.EntityFrameworkCore;
using SummerveldHoundResortAPIServer.Models;
using SummerveldHoundResortAPIServer.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerveldHoundResortAPIServer.Data
{
    public class DoggoDataContext : DbContext
    {
        public DoggoDataContext(DbContextOptions<DoggoDataContext> options) : base(options)
        {
            
        }

        public DbSet<Doggo> doggo { get; set; }
        public DbSet<Intro> intro { get; set; }
        public DbSet<LifeEvent> lifeEvent { get; set; }
        public DbSet<Icon> icon { get; set; }
        public DbSet<VirtualAdoption> virtualAdoption { get; set; }
        public DbSet<Adopted> adopted { get; set; }
        public DbSet<DoggoAlbum> doggoAlbum { get; set; }
        public DbSet<DoggoContent> doggoContent { get; set; }
        public DbSet<DoggoPhoto> doggoPhoto { get; set; }
        public DbSet<DoggoVideo> doggoVideo { get; set; }
        public DbSet<DoggoType> doggoType { get; set; }
        public DbSet<DoggoFriend> doggoFriend { get; set; }
        public DbSet<LifeEventViewModel> lifeEventViewModel { get; set; }
    }
}
