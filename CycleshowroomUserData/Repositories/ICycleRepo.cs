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
    public interface ICycleRepo
    {
        public Task<int> AddCycle(Cycle cycle);

        public Task<Cycle> GetCycle(int cid);

        public Task<List<Cycle>> GetAllCycles();

        public Task<bool> ExistCycle(string cname);
        public Task UpdateCycle(Cycle cycle);

        public Task RemoveCycle(Cycle cycle);


        public Task RemoveAllCycle();

    }


    public class CycleRepo : ICycleRepo
    {

        private readonly CSUserSLDbcontext _dbContext;


        public CycleRepo(CSUserSLDbcontext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> AddCycle(Cycle cycle)
        {
            if (await ExistCycle(cycle.CName))
            {
                return 0;
            }
            _dbContext.cycles.Add(cycle);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistCycle(string cname)
        {
            var res = await _dbContext.cycles.Where(c => c.CName.Trim().ToLower() == cname.Trim().ToLower()).FirstOrDefaultAsync();
            if (res == null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Cycle>> GetAllCycles()
        {
            List<Cycle> cycles = await _dbContext.cycles.ToListAsync();
            return cycles;
        }




        public async Task<Cycle> GetCycle(int cid)
        {
            return await _dbContext.cycles.FindAsync(cid);
        }

        public async Task RemoveAllCycle()
        {
            await _dbContext.cycles.ExecuteDeleteAsync();
        }

        public async Task RemoveCycle(Cycle cycle)
        {
            _dbContext.cycles.Remove(cycle);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCycle(Cycle cycle)
        {

            _dbContext.cycles.Update(cycle);

            //_dbContext.Entry(cycle).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}

