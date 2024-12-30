using Microsoft.EntityFrameworkCore;
using SaifHassanW2.Models.Entitys;

namespace SaifHassanW2.Models
{
    public class AppDBContext : DbContext
    {
       public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Tasks> tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>().HasOne(x => x.Project).
                 WithMany(x => x.Tasks).
                 HasForeignKey(x => x.projectID).OnDelete(DeleteBehavior.NoAction);

           modelBuilder.Entity<Tasks>().HasOne(x => x.TeamMember).
                WithMany(x => x.Tasks).
                HasForeignKey(x => x.TeamMemberID).OnDelete(DeleteBehavior.NoAction);
        }

    }
}
