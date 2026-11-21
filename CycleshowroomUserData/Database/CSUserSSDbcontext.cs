using CycleshowroomUserData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleshowroomUserData.Database
{
    public class CSUserSSDbcontext : DbContext
    {
        public CSUserSSDbcontext(DbContextOptions<CSUserSSDbcontext> options) : base(options)
        {
        }

        protected CSUserSSDbcontext()
        {
        }

        public DbSet<Cycle> cycles { get; set; }

        public DbSet<ShowroomCycle> showroomCycles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:labs-ac-db-server.database.windows.net,1433;Initial Catalog=Cycleshowroom;Persist Security Info=False;User ID=labsdbserver;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasNoKey();

            modelBuilder.Entity<ShowroomCycle>().ToTable("showroomCycles", t => t.ExcludeFromMigrations());

            modelBuilder.Entity<Cycle>().ToTable("cycles", t => t.ExcludeFromMigrations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
