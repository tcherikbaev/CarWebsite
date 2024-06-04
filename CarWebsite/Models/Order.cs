using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebsite.Models
{
    public class Order
    {
        [BindNever]
        public int id {get;set;}
        [Display(Name="Input Name")]
        [StringLength(20)]
        [Required(ErrorMessage ="Maximum symbols 20 ")]
        public string name { get; set; }
        [Display(Name = "Input Surname")]
        [StringLength(20)]
        [Required(ErrorMessage = "Maximum symbols 20 ")]
        public string surname { get; set; }
        [Display(Name = "Input Address")]
        [StringLength(20)]
        [Required(ErrorMessage = "Maximum symbols 20 ")]
        public string adddress { get; set; }
        [Display(Name = "Input Phone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Maximum symbols 20 ")]
        public string phone { get; set; }
        [Display(Name = "Input Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        [Required(ErrorMessage = "Maximum symbols 20 ")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime{ get; set; }
        public List<orderDetails> orderDetails { get; set; }








    }
}
