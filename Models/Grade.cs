using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Grade
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Qsans { get; set; }
        public int Qskey { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Examname { get; set; }
        public int Stdforeinkey { get; set; }

        [ForeignKey("Stdforeinkey")]
        public virtual Students Students { get; set; }
    }
}
