using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Data;
using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LMS.Pages.Studen
{
    public class GradeModel : PageModel
    {
        public readonly ApplicationDbContext db;
        public GradeModel(ApplicationDbContext _db)
        {
            db = _db;

        }
        public List<Stdgrades> Stdgrades { get; set; }

        public int Id { get; set; }
        public async Task OnGetAsync(int Id)
        {
            this.Id =Id;
            Stdgrades = await db.Stdgrades.Where(m => m.Stdnum == Id).ToListAsync();


        }
    }
}