using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace College.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string? address { get; set; }
        public string? firstname { get; set; }
        [Display(Name = "Last Name")]
        public string? lastname { get; set; }
        
        [Display(Name = "Email")]
        public string? mail { get; set; }
        public Cohort? Cohort { get; set; }

        public List<Grade>? Grades { get; set; }
    }
}
