using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; } 

        [Required]
        public DateTime DateOfBirth { get; set; } 

        [Required]
        [StringLength(10)]
        public string Gender { get; set; } 

        [StringLength(15)]
        public string PhoneNumber { get; set; } 

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } 

        [StringLength(200)]
        public string Address { get; set; } 

        [StringLength(100)]
        public string City { get; set; } 

        [StringLength(100)]
        public string State { get; set; } 

        [StringLength(20)]
        public string ZipCode { get; set; } 

        [StringLength(50)]
        public string Country { get; set; } 

        [DataType(DataType.Date)]
        public DateTime DateOfAdmission { get; set; } 

        [DataType(DataType.Date)]
        public DateTime? DateOfDischarge { get; set; } 

        [StringLength(500)]
        public string MedicalHistory { get; set; } 

        [StringLength(200)]
        public string BloodGroup { get; set; } 

        [StringLength(100)]
        public string EmergencyContactName { get; set; } 

        [StringLength(15)]
        public string EmergencyContactPhone { get; set; } 

        [StringLength(100)]
        public string EmergencyContactRelation { get; set; } 

        public bool IsInsured { get; set; } 

        [StringLength(100)]
        public string InsuranceProvider { get; set; } 

        public bool IsDeleted { get; set; }
    }
}
