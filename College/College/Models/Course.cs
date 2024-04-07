using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? title { get; set; }

        [Range(0,31)]
        public int? credits { get; set; }
        public List<Cohort>? Cohorts { get; set; } 
        public List<Faculty>? Faculties { get; set; }
    }
}
