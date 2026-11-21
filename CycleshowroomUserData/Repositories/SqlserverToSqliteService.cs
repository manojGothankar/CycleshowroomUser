using CycleshowroomUserData.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleshowroomUserData.Repositories
{
    public class SqlserverToSqliteService
    {
        readonly CSUserSLDbcontext sldb;
        readonly CSUserSSDbcontext ssdb;

        public SqlserverToSqliteService(CSUserSLDbcontext sldb,CSUserSSDbcontext ssdb)
        {
        
            this.sldb = sldb;
            this.ssdb = ssdb;
        }

        public async Task seed()
        {

            if (sldb.cycles.Count() <= 0)
            {
                await FetchCycles();
               
            }

            if(sldb.showroomCycles.Count() <= 0)
            {
                await FetchShowroomCycles();
            }
        }

        private async Task FetchCycles()
        {
            var clist = await ssdb.cycles.AsNoTracking().ToListAsync();
            sldb.cycles.AddRange(clist);
            await sldb.SaveChangesAsync();

        }

        private async Task FetchShowroomCycles()
        {
            var clist = await ssdb.showroomCycles.AsNoTracking().ToListAsync();
            sldb.showroomCycles.AddRange(clist);
            await sldb.SaveChangesAsync();
        }

    }

}
