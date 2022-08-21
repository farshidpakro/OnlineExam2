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
    public class ExamModel : PageModel
    {
        public readonly ApplicationDbContext db;
        public ExamModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public Stdgrades Stdgrades = new Stdgrades();
        public List<Grade> Grades { get; set; }
        public List<Students> Students { get; set; }
        public List<Questions> Questions { get; set; }
        public List<Examlist> Examlists { get; set; }
        public List<int> Id { get; set; }
        public async Task OnGetAsync(List<int> Id)
        {
            Examlists = await db.Examlist.Where(m => m.Id == Id[0]).ToListAsync();
            Students= await  db.Students.Where(m => m.Studentnum == Id[1]).ToListAsync();
            Questions = await db.Questions.Where(m => m.Examlistid == Id[0]).ToListAsync();
            //ew can accept list of number 
        }
        public async Task<IActionResult> OnPost(List<Grade> Grades)
        {
            int Qscount = 0;
            int Truecount = 0;

            foreach (var item in Grades)
            {

                await db.Grade.AddAsync(item);
                if (item.Qsans == item.Qskey) {

                    Truecount++;

                }
                Qscount++;
            }
            Stdgrades.Stdgrade = Truecount;
            Stdgrades.Questioncount = Qscount;
            Stdgrades.Stdnum = await db.Students.Where(m => m.Id == Grades[0].Stdforeinkey).Select(m => m.Studentnum).FirstOrDefaultAsync();
            Stdgrades.Stdname= await db.Students.Where(m => m.Id == Grades[0].Stdforeinkey).Select(m => m.Name).FirstOrDefaultAsync();
            Stdgrades.Examname = Grades[0].Examname;
            await db.Stdgrades.AddAsync(Stdgrades);
            await db.SaveChangesAsync();
           // int Id = await db.Grade.Where(m=>m.Stdforeinkey==Grades.Last().Stdforeinkey).Select(m=>m.Stdforeinkey).FirstOrDefaultAsync();

            return RedirectToPage("Grade", new { Id = Stdgrades.Stdnum });
        } 
    }
}