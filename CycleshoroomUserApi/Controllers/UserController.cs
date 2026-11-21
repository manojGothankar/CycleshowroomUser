using CycleshoroomUserApi.Services;
using CycleshowroomUserData.Models;
using CycleshowroomUserData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CycleshoroomUserApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly JwtService jwtService;
        readonly IUserRepo userRepo;

        public UserController(JwtService jwtService, IUserRepo userRepo)
        {
            this.jwtService = jwtService;
            this.userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok("Welcome");
        }


        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            user.Role = "User";

            if (!ModelState.IsValid)
            {
                return NotFound("Invalid User");
            }

            await userRepo.AddUser(user);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> Login(string username,string password)
        {
            var user=await userRepo.GetUserByUsernameAndPassword(username,password);
            if (user ==null)
            {
                return NotFound("Invalid User");
            }
            var token= jwtService.GenerateToken(user);


            return Ok(new {user=user,token=token});
        }
    }
}
