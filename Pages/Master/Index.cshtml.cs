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
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext db;
        public IndexModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IEnumerable<Examlist> Examlists { get; set; }
        public async Task OnGet()
        {
            Examlists = await db.Examlist.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int? Id) {

            var Deleteobj = await db.Examlist.FindAsync(Id);
             db.Examlist.Remove(Deleteobj);
            List<Questions> Delobj =await db.Questions.Where(m => m.Examlistid == Id).ToListAsync();
            List<Students> Delobjtwo = await db.Students.Where(m => m.Examlistid == Id).ToListAsync();

            foreach (var i in Delobj) {
                db.Questions.Remove(i);
            }
            foreach (var i in Delobjtwo)
            {
                db.Students.Remove(i);
            }

            await db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
        public IActionResult OnPostDetail(int Id) {

            return RedirectToPage("Detail", new { Id=Id});
        }
    }
}