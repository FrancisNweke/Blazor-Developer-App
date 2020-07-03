using BlazorAPIShared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAPIShared.ViewModels
{
    public class DeveloperViewModel
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

        public static implicit operator DeveloperViewModel(Developer developer)
        {
            return new DeveloperViewModel
            {
                DeveloperId = developer.DeveloperId,
                FirstName = developer.FirstName,
                LastName = developer.LastName,
                Description = developer.Description,
                EmailAddress = developer.EmailAddress,
                AnnualSalary = developer.AnnualSalary,
                Country = developer.Country,
                City = developer.City,
                ExperienceInYears = developer.ExperienceInYears,
                DoesOpenSource = developer.DoesOpenSource
            };
        }

        public static implicit operator Developer(DeveloperViewModel developerViewModel)
        {
            return new Developer
            {
                DeveloperId = developerViewModel.DeveloperId,
                FirstName = developerViewModel.FirstName,
                LastName = developerViewModel.LastName,
                Description = developerViewModel.Description,
                EmailAddress = developerViewModel.EmailAddress,
                AnnualSalary = developerViewModel.AnnualSalary,
                Country = developerViewModel.Country,
                City = developerViewModel.City,
                ExperienceInYears = developerViewModel.ExperienceInYears,
                DoesOpenSource = developerViewModel.DoesOpenSource
            };
        }
    }
}
