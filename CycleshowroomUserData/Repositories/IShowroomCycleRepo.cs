using CycleshowroomUserData.Database;
using CycleshowroomUserData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleshowroomUserData.Repositories
{
    public interface IShowroomCycleRepo
    {
        public Task AddToShowroom(List<Cycle> cycles);
        public Task<List<ShowroomCycle>> ShowShowroom();


        public Task<ShowroomCycle> GetShowroomCycle(int sid);
        public Task RemoveFromShowroom(ShowroomCycle cycle);
        public Task MoveOutFromShowrrom(ShowroomCycle cycle);

    }

    public class ShowroomCycleRepo : IShowroomCycleRepo
    {
        private readonly CSUserSLDbcontext context;
        private readonly ICycleRepo cycleRepo;

        public ShowroomCycleRepo(CSUserSLDbcontext context, ICycleRepo cycleRepo)
        {
            this.context = context;
            this.cycleRepo = cycleRepo;
        }

        public async Task AddToShowroom(List<Cycle> cycles)
        {

            var scycles = cycles.Select(x => new ShowroomCycle()
            {

                CId = x.CId,
                CName = x.CName,
                CType = x.CType,
                CPrice = x.CPrice,
                CBrand = x.CBrand,
                CFileImage = x.CFileImage,
                CCount = x.CCount
            }).ToList();

            context.showroomCycles.AddRange(scycles);
            //await context.SaveChangesAsync();

            var dblist = await cycleRepo.GetAllCycles();
            var list = dblist.Join(cycles, x => x.CId, y => y.CId, (x_db, y_in) => x_db).ToList();

            foreach (var item in list)
            {
                item.CCount = item.CCount - cycles.Where(x => x.CId == item.CId).FirstOrDefault().CCount;
            }

            context.cycles.UpdateRange(list);
            await context.SaveChangesAsync();
        }

        public async Task RemoveFromShowroom(ShowroomCycle cycle)
        {
            context.showroomCycles.Remove(cycle);
            await context.SaveChangesAsync();
        }

        public async Task MoveOutFromShowrrom(ShowroomCycle cycle)
        {
            context.showroomCycles.Remove(cycle);
            if (await cycleRepo.ExistCycle(cycle.CName))
            {
                var c = await cycleRepo.GetCycle(cycle.CId);
                c.CCount = c.CCount + cycle.CCount;
                await cycleRepo.UpdateCycle(c);
            }
            else
            {
                await cycleRepo.AddCycle(new Cycle()
                {
                    CName = cycle.CName,
                    CType = cycle.CType,
                    CPrice = cycle.CPrice,
                    CBrand = cycle.CBrand,
                    CFileImage = cycle.CFileImage,
                    CCount = cycle.CCount
                });

                await context.SaveChangesAsync();
            }




        }

        public async Task<List<ShowroomCycle>> ShowShowroom()
        {
            List<ShowroomCycle> cycles = await context.showroomCycles.ToListAsync();
            return cycles;
        }

        public async Task<ShowroomCycle> GetShowroomCycle(int sid)
        {
            return await context.showroomCycles.Where(x => x.CId == sid).FirstOrDefaultAsync();
        }
    }
}
