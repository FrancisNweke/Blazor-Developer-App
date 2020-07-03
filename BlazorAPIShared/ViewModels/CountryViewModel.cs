using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAPIShared.ViewModels
{
    public class CountryViewModel
    {
        [Required]
        [StringLength(5)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
