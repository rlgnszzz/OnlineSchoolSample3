using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSchoolSample3.Models
{
    public enum Score
    {
        A,B,C,D,F
    }

    public class Enrollment
    {
        
        public int EnrollmentID { get; set; }

        
        public Score? Score { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}