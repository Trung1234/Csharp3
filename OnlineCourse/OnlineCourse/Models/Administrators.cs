using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCourse.Models
{
    public class Administrators
    {
  
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
        
     
      
        [DefaultValue(true)]
        public bool IsActive { get; set; }
      
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}