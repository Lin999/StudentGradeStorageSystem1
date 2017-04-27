namespace GradeSystem.Data.Migrations
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GradeSystem.Data.SystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GradeSystem.Data.SystemContext";
        }

        protected override void Seed(SystemContext context)
        {

            var students = new List<Student>
            {
                new Student { ID = 1, LastName = "Andy", FirstMidName = "Lin", EnrollmentDate = DateTime.Parse("2017-04-27") },
                new Student { ID = 2, LastName = "Tom", FirstMidName = "Lin", EnrollmentDate = DateTime.Parse("2017-04-27") },
                new Student { ID = 3, LastName = "Allen", FirstMidName = "Lin", EnrollmentDate = DateTime.Parse("2017-04-27") },
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course {CourseID = 101, Title = "Math", Credits = 4, },
                new Course {CourseID = 202, Title = "Phys", Credits = 4, },
                new Course {CourseID = 303, Title = "Eng", Credits = 4, },
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
                new Teacher { ID = 1, LastName = "Andy", HireDate = DateTime.Parse("2017-04-27"), },
                new Teacher { ID = 2, LastName = "Tom", HireDate = DateTime.Parse("2017-04-27"), },
                new Teacher { ID = 3, LastName = "Allen", HireDate = DateTime.Parse("2017-04-27"), },
            };
            teachers.ForEach(s => context.Teachers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment {StudentID = students.Single(s => s.LastName == "Andy").ID,
                CourseID = courses.Single(c=> c.Title=="Math").CourseID,
                Grade = Grade.A
                },
                new Enrollment {StudentID = students.Single(s => s.LastName == "Tom").ID,
                CourseID = courses.Single(c=> c.Title=="Math").CourseID,
                Grade = Grade.B
                },
                new Enrollment {StudentID = students.Single(s => s.LastName == "Allen").ID,
                CourseID = courses.Single(c=> c.Title=="Math").CourseID,
                Grade = Grade.C
                },

                new Enrollment {StudentID = students.Single(s => s.LastName == "Andy").ID,
                CourseID = courses.Single(c=> c.Title=="Phys").CourseID,
                Grade = Grade.A
                },
                new Enrollment {StudentID = students.Single(s => s.LastName == "Tom").ID,
                CourseID = courses.Single(c=> c.Title=="Phys").CourseID,
                Grade = Grade.B
                },
                new Enrollment {StudentID = students.Single(s => s.LastName == "Allen").ID,
                CourseID = courses.Single(c=> c.Title=="Phys").CourseID,
                Grade = Grade.C
                },

                new Enrollment {StudentID = students.Single(s => s.LastName == "Andy").ID,
                CourseID = courses.Single(c=> c.Title=="Eng").CourseID,
                Grade = Grade.A
                },
                new Enrollment {StudentID = students.Single(s => s.LastName == "Tom").ID,
                CourseID = courses.Single(c=> c.Title=="Eng").CourseID,
                Grade = Grade.B
                },
                new Enrollment {StudentID = students.Single(s => s.LastName == "Allen").ID,
                CourseID = courses.Single(c=> c.Title=="Eng").CourseID,
                Grade = Grade.C
                },
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                s =>
                s.Student.ID == e.StudentID &&
                s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }

        }
    }
}
