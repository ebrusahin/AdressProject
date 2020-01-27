using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdressProject.Models
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name Max Length is 20, Min Length 2")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        [StringLength(20,MinimumLength =2, ErrorMessage = "Surname Max Length is 20, Min Length 2")]

        public string SurName { get; set; }
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be 11 digits")]

        public string PhoneNumber { get; set; }
        [StringLength(100, ErrorMessage = "Description Max Length is 100")]
        public string Adres { get; set; }

        public int AdressTypeId { get; set; }

        public virtual AdressType AdressType { get; set; }
    }
}
