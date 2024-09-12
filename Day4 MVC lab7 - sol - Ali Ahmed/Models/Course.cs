using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Day4_MVC_lab7___sol___Ali_Ahmed.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }

        #region Navigational properties

        [ForeignKey("Department")]
        public int Department_ID { get; set; }
        public Department Department { get; set; }


        public string PhotoCourse { get; set; }
        
        public List<Student> Students { get; set; }
        #endregion




        


    }
}