using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JobApplicationPortal.DAL.Model
{
    public class EducationalDetail
    {
        [Key]
        public int Id { get; set; }

        public int UserDetailId { get; set; }

        [Required]
        [MaxLength(5)]
        [Display(Name = "SSC passing Year")]
        public string SSCPassingYear { get; set; }

        [Required]
        [MaxLength(5)]
        [Display(Name = "HSC passing Year")]
        public string HSCPassingYear { get; set; }

        [Required]
        [MaxLength(5)]
        [Display(Name = "Graduation passing Year")]
        public string GraduationPassingYear { get; set; }

        [Required]
        [MaxLength(5)]
        [Display(Name ="PG passing Year")]
        public string PostGraduationPassingYear { get; set; }

        [Required]
        public bool IsYearGap { get; set; }

        [Required]
        public bool IsActiveBacklogs { get; set; }

        [MaxLength(30)]
        public string AcademicProjects { get; set; }

        [ForeignKey("UserDetailsId")]
        public virtual UserDetail UserDetails { get; set; }
    }
}
