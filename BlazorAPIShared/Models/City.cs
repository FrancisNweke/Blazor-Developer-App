using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorAPIShared.Models
{
    public class City
    {
        [Key]
        [StringLength(5)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        [ForeignKey(nameof(Country))]
        [Column(nameof(Country))]
        public string CountryCode { get; set; }
        public virtual Country Country { get; set; }
    }
}
