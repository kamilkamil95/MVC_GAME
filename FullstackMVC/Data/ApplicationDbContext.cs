using FullstackMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<MonsterTypeModel> MonsterType { get; set; }
        public DbSet<MapModel> MapModel { get; set; }
        public DbSet<MonsterModel> MonsterModel { get; set; }
        public DbSet<CharacterModel> CharacterModel { get; set; }
        public DbSet<ItemModel> ItemModel { get; set; }
        public DbSet<ApplicationUserModel> ApplicationUserModel { get; set; }

    }
}
