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
    public interface IUserRepo
    {
        public Task AddUser(User u);
        public Task<User> GetUserByUsernameAndPassword(string username, string password);   
    }

    public class UserRepo : IUserRepo
    {

        private readonly CSUserSLDbcontext _dbContext;


        public UserRepo(CSUserSLDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUser(User u)
        {
            _dbContext.Users.Add(u);
            await _dbContext.SaveChangesAsync();

        }


        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            var user=await _dbContext.Users.FirstOrDefaultAsync(u=>u.Username== username && u.Password == password);
            return user;
        }
    }
}
