using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cafe.BL.Model;

namespace Cafe.BL.Controller
{
    class CafeContext : DbContext
    {
        public CafeContext() : base("DbConnection")
        {
        }
         public DbSet<User> Users { get; set; }
         public DbSet<Food> Foods { get; set; }
         public DbSet<Gender> Genders { get; set; }
         public DbSet<Order> Orders { get; set; }
         

    }
}
