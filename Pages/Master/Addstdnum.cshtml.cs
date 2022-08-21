using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Data;
using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMS.Pages.Master
{
    public class AddstdnumModel : PageModel
    {
        public readonly ApplicationDbContext db;
        public AddstdnumModel(ApplicationDbContext _db)
        {
            db = _db;

        }
        
        public Students Students;
        public int Id { get; set; }
        public async Task OnGetAsync(int? Id)
        {
            if (Id.HasValue) {
            this.Id = (int)Id;

            }
        }
        public async Task<IActionResult> OnPost(Students Students)
        {

            if (ModelState.IsValid) {
                await db.Students.AddAsync(Students);
                await db.SaveChangesAsync();
                this.Id = Students.Examlistid;
                return RedirectToPage("Addstdnum", new { Id = Students.Examlistid });

            }
            return RedirectToPage("Addstdnum", new { Id = Students.Examlistid });




        }
    }
}