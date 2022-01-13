using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobApplicationPortal.DAL.Model
{
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("((\\+\\d{1,2}\\s?)?1?\\-?\\.?\\s?\\(?\\d{3}\\)?[\\s.-]?)?\\d{3}[\\s.-]?\\d{4}", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }
    }

    public enum Gender
    {
        male = 1,
        female = 2,
        other = 3,
    }

}
