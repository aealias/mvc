using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvcReg.Models
{
    public class Reg
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="First Name is Required")]
        [Display(Name = "First Name")]
        public string FirstName{ get; set; }
        [Required(ErrorMessage ="Last Name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Email is Required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; }
        

    }
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}