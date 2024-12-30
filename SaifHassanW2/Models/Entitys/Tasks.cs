using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaifHassanW2.Models.Entitys
{
    public class Tasks
    {
        [Key]
        public int TaskID { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; } 
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }
        public int projectID { get; set; }
        [ForeignKey("projectID")]
        public Projects Project { get; set; }
        public int TeamMemberID { get; set; }
        [ForeignKey("TeamMemberID")]
        public TeamMember TeamMember { get; set; }

    }
}
