using CycleshoroomUserApi.Services;
using CycleshowroomUserData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CycleshoroomUserApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ShowroomController : ControllerBase
    {
        readonly ICycleRepo cycleRepo;
        readonly IShowroomCycleRepo showroomCycleRepo;
       readonly SqlserverToSqliteService sqlserverToSqliteService;

        public ShowroomController(ICycleRepo cycleRepo, IShowroomCycleRepo showroomCycleRepo,SqlserverToSqliteService sqlserverToSqliteService)
        {
            this.cycleRepo = cycleRepo;
            this.showroomCycleRepo = showroomCycleRepo;
            this.sqlserverToSqliteService = sqlserverToSqliteService;
            
            
        }

        [HttpGet]
        public async Task<IActionResult> Indexcycles()
        {
            await sqlserverToSqliteService.seed();
            var res = await cycleRepo.GetAllCycles();

            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> Indexshowrromcycles()
        {
            var res = await showroomCycleRepo.ShowShowroom();

            return Ok(res);
        }
    }
}
