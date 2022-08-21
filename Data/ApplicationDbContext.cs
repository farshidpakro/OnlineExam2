using LMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMS.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Examlist> Examlist { get; set; }
    public DbSet<Questions> Questions { get; set; }
    public DbSet<Students> Students { get; set; }
    public DbSet<Grade> Grade { get; set; }
    public DbSet<Stdgrades> Stdgrades { get; set; }
}
