using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp10.DB
{
    public class MyContext : DbContext
    {
        private string cs = "server = 192.168.162.169; database =test25_10test; user id =sa; password =sa";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(cs);
        }
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Storage> storages { get; set; }

    }
}
