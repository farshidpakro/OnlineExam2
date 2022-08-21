using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Questions
    {


        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Qs { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Anone { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Antwo { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Anthree { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Anfour { get; set; }
        [Required]
        public int Qskey { get; set; }
        [Required]
        public int Examlistid { get; set; }
        [ForeignKey("Examlistid")]
        public virtual Examlist Examlist { get; set; }
    }
}
