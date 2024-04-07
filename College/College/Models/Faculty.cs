using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        [Display(Name = "Last Name")]
        public string? name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime hireDate { get; set; }
        [Display(Name = "Email")]
        public string? mail { get; set; }
        public  List<Cohort>? Cohorts { get; set; }
    }
}
