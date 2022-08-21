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
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext db;
        public IndexModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public string Message { get; set; }
        public Studentloggin Studentloggin { get; set; }
        public void OnGet()
        {

        }
        
        public async Task<IActionResult> OnPost(Studentloggin Studentloggin) {
            if (Studentloggin.Numone == Studentloggin.Numtwo)
            {
                List<int> Students = await db.Students.Where(m => m.Studentnum == Studentloggin.Numone).Select(m=>m.Id).ToListAsync();
                if (Students.Count() > 0) {

                    return RedirectToPage("Examlist",new { Id= Studentloggin.Numone });


                }
                Message = "امتحانی یافت نشد ";
                return Page();

            }
            else {
            Message = "گذروازه و رمز با هم یکسان نیستند ";
            return Page();

            }
        }

    }
}