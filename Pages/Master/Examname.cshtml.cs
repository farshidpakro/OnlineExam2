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
    public class ExamnameModel : PageModel
    {
        public readonly ApplicationDbContext db;
        public ExamnameModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public Examlist Examlist { get; set; }
        public async Task OnGet()
        {
           

        }
        public async Task<IActionResult> OnPost(Examlist examlist)
        {
            if (ModelState.IsValid)
            {
                await db.Examlist.AddAsync(examlist);
                await db.SaveChangesAsync();
                int Examid = await db.Examlist.Where(m => (m.Name == examlist.Name)&&(m.Description==examlist.Description)).Select(m => m.Id).FirstOrDefaultAsync();
                return RedirectToPage("Addexamqs",new  {Id=Examid });

            }
                
            return Page();


        }
    }
}