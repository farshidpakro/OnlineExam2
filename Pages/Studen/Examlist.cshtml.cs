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
    public class ExamlistModel : PageModel
    {
        public readonly ApplicationDbContext db;
        public ExamlistModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public List<Examlist> Examlist = new List<Examlist>();      
        public int Id { get; set; }


        public async Task OnGetAsync(int Id)
        { 
               this.Id = Id;
           List<int> stdlistid= await db.Students.Where(m => m.Studentnum == Id).Select(m=>m.Examlistid).ToListAsync();
            if (stdlistid.Count()>0){
               foreach(int i in stdlistid)
                { 
                    Examlist.AddRange ( await db.Examlist.Where(m => m.Id == i).ToListAsync());
                
                    
                }
            }
            

        }
        public async Task<IActionResult> OnPostRedirect(int Id, int Idtwo)
        {
            int one = this.Id;

            List<int> Intnum = new List<int>() { Id, Idtwo};
        
            return RedirectToPage("Exam", new { Id = Intnum });


        }

    }
}