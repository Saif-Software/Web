using SaifHassanW2.Models.Entitys;

namespace SaifHassanW2.Models.ViewModels
{
    public class TasksViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; } 
        public string status { get; set; }
        public string Proirty {  get; set; }
        public int projectID { get; set; }
        public int TeamMemberID { get; set; }
        public DateTime Deadline { get; set; }
        public List<Projects> projects { get; set; }
        public List<TeamMember> teamMembers { get; set; }   
    }
}
