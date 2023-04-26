using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StajerBlognet6.Core.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajerBlognet6.Core.Data
{
    public class BlogDB : DbContext
    {
        public BlogDB() { }
        IConfiguration configuration = new ConfigurationBuilder()
                           .AddJsonFile("appsettings.json")
                           .Build();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            var cnstr = configuration["ConnectionStrings:blogDB"];
            optionsBuilder.UseSqlServer(cnstr);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<BlogUser> BlogUsers { get; set; }
    }

    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
