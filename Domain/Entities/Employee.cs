using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        //

       
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } 

        [Required]
        [EmailAddress]
        public string Email { get; set; } 

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(20)]
        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; } 

        [StringLength(200)]
        public string AddressLine1 { get; set; }

        [StringLength(200)]
        public string AddressLine2 { get; set; }

        [StringLength(100)]
        public string City { get; set; } 

        [StringLength(100)]
        public string State { get; set; } 

        [StringLength(20)]
        public string ZipCode { get; set; } 

        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        public string Department { get; set; } 

        public string Position { get; set; } 

        public decimal Salary { get; set; } 

        public bool? IsFullTime { get; set; }

        public DateTime? JoiningDate { get; set; }

        public DateTime? LastPromotionDate { get; set; } 

        public int? NumberOfProjects { get; set; }

        [StringLength(15)]
        public string EmergencyContactNumber { get; set; } 

        public bool? IsDeleted { get; set; } 

    }
}
