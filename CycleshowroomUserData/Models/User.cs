using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleshowroomUserData.Models
{
  
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9._-]*")]
        public string Username { get; set; }
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@#$%&*_.-])[a-zA-Z0-9@#$%&*_.-]{5,}$")]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } = "User";
    }
}
