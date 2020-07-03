using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAPIShared.Models
{
    public class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        [Key]
        [StringLength(5)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
