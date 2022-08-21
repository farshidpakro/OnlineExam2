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
    public class StdgradesModel : PageModel
    {
        public readonly ApplicationDbContext db;
        public StdgradesModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public List<Stdgrades> Stdgrades { get; set; }
        public async Task OnGet()
        {
            Stdgrades = await db.Stdgrades.ToListAsync();

        }
    }
}