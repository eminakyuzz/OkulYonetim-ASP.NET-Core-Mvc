using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OkulYonetim.Models
{
    public class Student
    {
        [Key]
        public int StudentNo { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirtsName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        public int Age { get; set; }

    }
}
