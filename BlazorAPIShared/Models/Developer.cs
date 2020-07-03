using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAPIShared.Models
{
    public class Developer
    {
        [Required]
        public string DeveloperId { get; set; }
        [StringLength(50, ErrorMessage = "first name can not be less than 3 and greater than 50 characters.", MinimumLength = 3)]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "last name can not be less than 3 and greater than 50 characters.", MinimumLength = 3)]
        public string LastName { get; set; }
        [StringLength(80, ErrorMessage = "description can not be less than 5 and greater than 80 characters.", MinimumLength = 5)]
        public string Description { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "invalid email address")]
        public string EmailAddress { get; set; }
        [Range(1, 999999, ErrorMessage = "0 is invalid")]
        public decimal AnnualSalary { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        public double ExperienceInYears { get; set; }
        public bool DoesOpenSource { get; set; }
    }
}
