using CycleshowroomUserData.Models;
using CycleshowroomUserData.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CycleshoroomUserApi.Services
{
    public class JwtService
    {
        readonly IUserRepo userRepo;
        readonly IConfiguration configuration;
        public JwtService(IUserRepo userRepo,IConfiguration configuration) {
        
            this.userRepo = userRepo;
            this.configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt")["Key"]));
            var algo = SecurityAlgorithms.HmacSha256;
            var signingCreds = new SigningCredentials(key, algo);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Jwt:DurationInMinutes"])),
                signingCredentials: signingCreds);

            string tokenstring=new JwtSecurityTokenHandler().WriteToken(token); 

            return tokenstring;
        }
    }
}
