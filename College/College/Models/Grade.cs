using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College.Models
{
    public enum Value
    {
        A, B, C, D, F
    }

    public class Grade
    {
        public int Id { get; set; }
        
        [Display(Name = "Grade")]
        public Value? grade { get; set; }

        public int? coefficient { get; set; }
        public Student? Student { get; set; }
        public Exam? Exam { get; set; }
    }
}
