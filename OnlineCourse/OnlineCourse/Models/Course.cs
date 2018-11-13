using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCourse.Models
{
    public class Course
    {
        //public Course()
        //{
        //    this.Students = new HashSet<Student>();
        //}

       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }      
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EnrollmentLimit{ get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public ICollection<Student> Students { get; set; }
    
    }
}