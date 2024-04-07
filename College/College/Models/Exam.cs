using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public Cohort Cohort { get; set; }

        public Course Course { get; set; }
    }
}
