using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SaifHassanW2.Models;
using SaifHassanW2.Models.Entitys;

namespace SaifHassanW2.Controllers
{
    public class TeamMemberController : Controller
    {
        private readonly AppDBContext db;
        public TeamMemberController(AppDBContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> MemberView(int id)
        {
            var m = await db.TeamMembers.Include(x=>x.Tasks).FirstOrDefaultAsync(x=>x.TeamID == id);
            return View(m);
        }
        [HttpGet]
        public async Task<IActionResult> update(int id)
        {
            var s = await db.TeamMembers.FirstOrDefaultAsync(x=>x.TeamID==id);  
            return View(s);
        }
        [HttpPost]

        public async Task<IActionResult> update(TeamMember teamMember)
        {
            db.TeamMembers.Update(teamMember);
            await db.SaveChangesAsync();
            return RedirectToAction("GetAllProjects","Projects");
        }
        public async Task<IActionResult> Remove(int id)
        {
            var s = await db.tasks.FirstOrDefaultAsync(x=>x.TeamMemberID==id);
            db.tasks.Remove(s);
            await db.SaveChangesAsync();
            return RedirectToAction("GetAllProjects", "Projects");
        }
    }
}
