using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpUbiComp.Models;

namespace TpUbiComp.Data
{
    public class UserContext : DbContext
    {
        public DbSet<Application> Application { get; set; }
        public DbSet<ApplicationLocale> ApplicationLocale { get; set; }
        public DbSet<Locale> Locale { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=" + "Utilizar a senha do banco de dados" + ";Persist Security Info=True;User ID=" + "Utilizar o usuário do banco de dados" + ";Initial Catalog=UbicompApp;Data Source=localhost");
        }
    }
}
