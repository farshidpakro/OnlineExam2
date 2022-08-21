using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Examlist
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Name { get; set; }
        [Required]
        public int Time { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
    }
}
