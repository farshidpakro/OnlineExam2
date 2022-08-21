using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Stdgrades
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Stdnum { get; set; }
        [Required]
        public int Stdgrade { get; set; }
        [Required]
        public int Questioncount { get; set; }
        [Column(TypeName ="nvarchar(MAX)")]
        public string Examname { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Stdname { get; set; }

    }
}
