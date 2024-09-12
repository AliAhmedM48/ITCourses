using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day4_MVC_lab7___sol___Ali_Ahmed.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "User Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Your Name.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Your Name Should be min 3 and max 20 length")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Your Phone Number.")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, ErrorMessage = "you must Enter 11 numbers", MinimumLength = 11)]
        public string Phone { get; set; }
        [Display(Name = "E-mail")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Your E-mail !")]
        [DataType(DataType.EmailAddress)]
        [StringLength(60)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'+/=?^_`{|}~-]+)@(?:[a-z0-9](?:[a-z0-9-][a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Please enter correct email address")]
        //[RegularExpression("^...$", ErrorMessage = "Please enter a valid email address")]
        //[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [Remote("IsUserExists", "ITI", ErrorMessage = "Email already in use")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        //[DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string Password { get; set; }
        public string Gender { get; set; }

        public string University { get; set; }

        public int GraduationYear { get; set; }

       

        public string Role { get; set; }

public string ProfilePhoto { get; set; }


        #region Navigational properties

        public List<Course> Courses { get; set; }



        #endregion



    }
}