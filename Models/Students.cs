using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Students
    {




        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Studentnum { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Lastname { get; set; }
        [Required]
        public int Examlistid { get; set; }
        [ForeignKey("Examlistid")]
        public virtual Examlist Examlist { get; set; }
    }
}
