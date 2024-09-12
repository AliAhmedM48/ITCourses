using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day4_MVC_lab7___sol___Ali_Ahmed.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }
        [Required,DataType(DataType.Text)]
        public string Name { get; set; }
        public string departDescription { get; set; }


        #region Navigational properties
        public List<Course> Courses { get; set; }

        #endregion
    }
}