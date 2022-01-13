using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JobApplicationPortal.DAL.Model
{
    public class AddressDetail
    {
        [Key]
        public int Id { get; set; }

        public int UserDetailId { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string AddressLine1 { get; set; }

        [Required]
        [MaxLength(50)]
        public string AddressLine2 { get; set; }

        [ForeignKey("UserDetailsId")]
        public virtual UserDetail UserDetails { get; set; }
    }
}
