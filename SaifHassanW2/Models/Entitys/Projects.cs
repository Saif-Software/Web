using System.ComponentModel.DataAnnotations;

namespace SaifHassanW2.Models.Entitys
{
    public class Projects
    {
        [Key]
        public int PID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime StartDate {  get; set; }    
        public DateTime EndDate { get; set; } 
        public List<Tasks> Tasks { get; set; }
    }
}
