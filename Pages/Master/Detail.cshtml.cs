using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Data;
using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LMS.Pages.Master
{
    public class DetailModel : PageModel
    {
        public readonly ApplicationDbContext db;
        public DetailModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public int Id { get; set; }
        public List<Questions> Questions { set; get; }
        public List<Students> Students { set; get; }
        public async Task OnGetAsync(int Id)
        {
            this.Id = Id;
            Questions = await db.Questions.Where(m => m.Examlistid == Id).ToListAsync();
            Students = await db.Students.Where(m => m.Examlistid==Id).ToListAsync();
        }
    }
}