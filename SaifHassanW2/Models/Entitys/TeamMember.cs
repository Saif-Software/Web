using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SaifHassanW2.Models.Entitys
{
    public class TeamMember
    {
        [Key]
        public int TeamID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Role { get; set; }
        public List<Tasks> Tasks { get; set; }
    }
}
