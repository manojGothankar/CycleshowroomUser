using CycleshowroomUserData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleshowroomUserData.Database
{
    public class CSUserSLDbcontext : DbContext
    {

        public CSUserSLDbcontext(DbContextOptions<CSUserSLDbcontext> options) : base(options)
        {
        }

        protected CSUserSLDbcontext()
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Cycle> cycles { get; set; }

        public DbSet<ShowroomCycle> showroomCycles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cycle>()
                .HasOne<ShowroomCycle>()
                .WithOne()
                .HasForeignKey<ShowroomCycle>("CId");

            

            base.OnModelCreating(modelBuilder);

        }
    }
}
