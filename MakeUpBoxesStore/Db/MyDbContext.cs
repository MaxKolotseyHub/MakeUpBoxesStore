using MakeUpBoxesStore.Models.DbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Db
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(string connectionString = "Default"):base(connectionString)
        {

        }

        static MyDbContext()
        {
            Database.SetInitializer<MyDbContext>(new MyDbContextInitializer());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients{ get; set; }
        public DbSet<Box> Boxes{ get; set; }
    }
}