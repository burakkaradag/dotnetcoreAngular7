using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonelProject.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.Data
{
    public class PersonelContext:DbContext
    {
        
        public PersonelContext(DbContextOptions<PersonelContext> option) : base(option)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //    optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //    optionsBuilder.UseLazyLoadingProxies();
        //}
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<Sehir> Sehir { get; set; }
        public virtual DbSet<PerGaleri> PerGaleri { get; set; }
        public virtual DbSet<SehGaleri> SehGaleri { get; set; }
    }
    
}
