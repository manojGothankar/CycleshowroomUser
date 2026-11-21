using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleshowroomUserData.Models
{
    public class ShowroomCycle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        //[ForeignKey("Cycle")]
        public int CId { get; set; }
        [Required]
        [RegularExpression(@"[-zA-Z0-9.-]*")]
        [MinLength(1)]
        public string CName { get; set; }
        [Required]
        public CType CType { get; set; }


        [NotMapped]
        public string? CDescription { get; set; }
        [Required]
        public int CPrice { get; set; }
        [Required]
        public int CCount { get; set; }
        [Required]
        public string CBrand { get; set; }
        [Required]
        public string CFileImage { get; set; }

    }
}
