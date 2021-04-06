using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSchoolSample3.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        public string Name { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}