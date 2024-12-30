using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using SaifHassanW2.Models;
using SaifHassanW2.Models.Entitys;
using SaifHassanW2.Models.ViewModels;

namespace SaifHassanW2.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDBContext db;
        public ProjectsController(AppDBContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> GetAllProjects()
        {
            var p = await db.Projects.ToListAsync();
            return View(p);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Projects projec)
        {
            await db.Projects.AddAsync(projec);
            await db.SaveChangesAsync();
            return RedirectToAction("GetAllProjects");
        }
        [HttpGet]
        public async Task<IActionResult> update(int id)
        {
            var p = await db.Projects.FirstOrDefaultAsync(x=>x.PID == id);
            return View(p);
        }
        [HttpPost]
        public async Task<IActionResult> update(Projects projec)
        {
            db.Projects.Update(projec);
            await db.SaveChangesAsync();
            return RedirectToAction("GetAllProjects");  
        }
        public async Task<IActionResult> Details(int id)
        {
            var s = await db.Projects.Include(x => x.Tasks).ThenInclude(x => x.TeamMember).FirstOrDefaultAsync(x => x.PID == id);
            return View(s);
        }
        public async Task<IActionResult> Remove(int id)
        {
            var s = await db.Projects.FirstOrDefaultAsync(x => x.PID == id);
            db.Projects.Remove(s);
            await db.SaveChangesAsync();
            return RedirectToAction("GetAllProjects");
        }


        

    }
}
