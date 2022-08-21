using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Data;
using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.Pages.Master
{
    public class AddexamqsModel : PageModel
    {
        public readonly ApplicationDbContext db;
        public AddexamqsModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public Questions Questions { get; set; }
        public int Id { get; set; }
        public async Task OnGetAsync(int? Id)
        {
            if (Id.HasValue)
            {
                this.Id = (int)Id;
            }

        }
        public async Task<IActionResult> OnPost(Questions Questions)
        {

            if (ModelState.IsValid)
            {

                await db.Questions.AddAsync(Questions);
                await db.SaveChangesAsync();
                this.Id = Questions.Examlistid;
                return RedirectToPage("Addexamqs", new { Id = Questions.Examlistid });


            }
            return RedirectToPage("Addexamqs", new { Id = Questions.Examlistid });



        }
        public async Task<IActionResult> OnPostStd(Questions Questions)
        {
            if (ModelState.IsValid)
            {

                await db.Questions.AddAsync(Questions);
                await db.SaveChangesAsync();
                this.Id = Questions.Examlistid;
                return RedirectToPage("Addstdnum", new { Id = Questions.Examlistid });


            }
            return RedirectToPage("Addstdnum", new { Id = Questions.Examlistid });
            // return RedirectToPage("Addstdnum", new { Id = this.Id });

        }

    }
}