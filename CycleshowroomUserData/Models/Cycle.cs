using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleshowroomUserData.Models
{
    public enum CType
    {
        MOTOR,
        GEAR,
        PADAIL
    }
    public class Cycle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CId { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9.-]*")]
        [MinLength(1)]
        public string CName { get; set; }
        [NotMapped]
        public string? CDescription { get; set; }
        [Required]
        public CType CType { get; set; }
        [Required]
        public int CPrice { get; set; }
        public int CCount { get; set; }
        [Required]
        public string CBrand { get; set; }

        public string? CFileImage { get; set; }
    }
}
