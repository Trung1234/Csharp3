using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCourse.Models
{
    public class Student
    {
        //public Student()
        //{
        //    this.Courses = new HashSet<Course>();
        //}
       
        public int Id { get; set; }
    
        public string FirstName { get; set; }
  
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        [RegularExpression(@"^((?=.*\d)(?=.*[A-Z])(?=.*\W).{6,50}).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public byte[] ProfileImg { get; set; }
        [Range(1,28)]
        public int Age { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime GraduationDate { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public int CourseRefId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
       // public virtual ICollection<Course> Courses { get; set; }
        public  Course Course { get; set; }
        public int CurrentCourseId { get; internal set; }
    }
}