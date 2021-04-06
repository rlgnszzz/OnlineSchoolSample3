using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSchoolSample3.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Display(Name ="이름")]
        public string Name { get; set; }


        [Display(Name ="수강 신청일")]
        public DateTime EnrollmentDate { get; set; }
        

        [Display(Name ="수강 상세")]
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}