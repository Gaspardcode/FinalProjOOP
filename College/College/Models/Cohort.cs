using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace College.Models
{
    public class Cohort
    {
        public string? name { get; set; }
        public int Id { get; set; }

        public Course? Course { get; set; }

        public List<Student>? Students { get; set; } 

    }
}
