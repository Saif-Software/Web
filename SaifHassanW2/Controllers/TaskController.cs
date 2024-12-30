using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaifHassanW2.Models;
using SaifHassanW2.Models.ViewModels;

namespace SaifHassanW2.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDBContext db;
        public TaskController(AppDBContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<IActionResult> update(int id)
        {
            var s = await db.tasks.FirstOrDefaultAsync(x=>x.TaskID == id);
            var p = await db.Projects.ToListAsync();
            var t = await db.TeamMembers.ToListAsync();
            TasksViewModel vm = new TasksViewModel()
            {
                status = s.Status,
                Description = s.Description,
                Proirty = s.Priority,
                Title = s.Title,
                Deadline = s.Deadline,
                projects = p,
                teamMembers = t,
                TeamMemberID=s.TeamMemberID,
                projectID = s.projectID,
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> update(TasksViewModel v, int id)
        {
            var s = await db.tasks.FirstOrDefaultAsync(x => x.TaskID == id);
            int ayoaa = s.TaskID;
            s.Status = v.status;
            s.Description = v.Description;
            s.Priority = v.Proirty;
            s.Title = v.Title;
            s.Deadline = v.Deadline;
            s.projectID = v.projectID;
            s.TeamMemberID = v.TeamMemberID;

            await db.SaveChangesAsync();
            return RedirectToAction("GetAllProjects", "Projects");
        }
    }
}
