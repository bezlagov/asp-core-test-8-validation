using System;
using System.ComponentModel.DataAnnotations;

namespace Task8.Models
{
    public class Consultation
    {
        [Required(ErrorMessage ="You need to enter name")]
        [Display(Name ="Name")]
        public string ClientName { get; set; }
       
        [Required(ErrorMessage ="You need to enter surname")]
        [Display(Name ="Surname")]
        public string ClientSurname { get; set; }
        
        [EmailAddress]
        [Required(ErrorMessage ="You need to enter e-mail")]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
       
        [Required(ErrorMessage ="You need to enter date")]
        [Display(Name ="Consultation date")]
        public DateTime Date { get; set; }

        public string ConsultType { get; set; }
    }
}
