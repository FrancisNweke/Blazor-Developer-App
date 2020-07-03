using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAPIShared.ViewModels
{
    public class CityViewModel
    {
        [Required]
        [StringLength(5)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        [StringLength(5)]
        public string CountryCode { get; set; }
    }
}
