using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleshowroomUserData.Database
{
    public class CSUserSLDBcontextFactory: IDesignTimeDbContextFactory<CSUserSLDbcontext>
    {
        public CSUserSLDbcontext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<CSUserSLDbcontext> optionsBuilder = new DbContextOptionsBuilder<CSUserSLDbcontext>();
            optionsBuilder.UseSqlite("Data Source=Database//csdb.db");
            return new CSUserSLDbcontext(optionsBuilder.Options);
        }

    }
}
