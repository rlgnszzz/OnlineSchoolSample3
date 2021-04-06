using OnlineSchoolSample3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineSchoolSample3.DAL
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student{Name="김아중",   EnrollmentDate=DateTime.Parse("2014-10-16")},
                new Student{Name="수지",     EnrollmentDate=DateTime.Parse("2016-02-19")},
                new Student{Name="산다라박", EnrollmentDate=DateTime.Parse("2019-11-02")},
                new Student{Name="신민아",   EnrollmentDate=DateTime.Parse("2015-01-22")},
                new Student{Name="유인나", EnrollmentDate=DateTime.Parse("2018-03-14")},
                new Student{Name="이다희", EnrollmentDate=DateTime.Parse("2020-12-24")},
                new Student{Name="정채연", EnrollmentDate=DateTime.Parse("2011-09-11")},
                new Student{Name="경리",   EnrollmentDate=DateTime.Parse("2013-10-17")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges(); // 문제가 발생했을 경우 정확하게 발생한 위치를 알기 쉽게 알려주기 위함이다.

            var courses = new List<Course>
            {
                new Course{CourseID=1000, Title="C언어"},
                new Course{CourseID=2000, Title="C#"},
                new Course{CourseID=3000, Title="C++"},
                new Course{CourseID=1010, Title="C언어 고급"},
                new Course{CourseID=1020, Title="ASP.NET MVC"},
                new Course{CourseID=2050, Title="jQuery"},
                new Course{CourseID=3010, Title="C++ STL"},
            };

            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{ StudentID=1, CourseID=1000, Score=Score.A},
                new Enrollment{ StudentID=1, CourseID=2000, Score=Score.A},
                new Enrollment{ StudentID=1, CourseID=1010, Score=Score.B},
                new Enrollment{ StudentID=2, CourseID=1020},
                new Enrollment{ StudentID=7, CourseID=2050, Score=Score.C},
                new Enrollment{ StudentID=5, CourseID=2000},
                new Enrollment{ StudentID=6, CourseID=2050, Score=Score.D},
                new Enrollment{ StudentID=1, CourseID=3000},
                new Enrollment{ StudentID=4, CourseID=3000, Score=Score.B},
                new Enrollment{ StudentID=8, CourseID=1010, Score=Score.C},
                new Enrollment{ StudentID=3, CourseID=2050, Score=Score.B},
                new Enrollment{ StudentID=7, CourseID=3010, Score=Score.A},
                new Enrollment{ StudentID=8, CourseID=3000, Score=Score.A},
                new Enrollment{ StudentID=4, CourseID=3010, Score=Score.B},
                new Enrollment{ StudentID=5, CourseID=2000, Score=Score.D},
                new Enrollment{ StudentID=6, CourseID=2000, Score=Score.A},
                new Enrollment{ StudentID=2, CourseID=3010},
                new Enrollment{ StudentID=3, CourseID=3000, Score=Score.C},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}