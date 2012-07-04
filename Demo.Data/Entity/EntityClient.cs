using System;
using System.Configuration;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using Oak;

namespace Demo.Data.Entity
{
    public class EntityClient
    {
        public void Execute()
        {
            Console.WriteLine("EntityClient");
            Console.WriteLine("");

            var context = new EntityContext(ConfigurationManager.ConnectionStrings[1].ConnectionString);

            foreach (var student in context.Students.Include(x => x.Courses))
            {
                Console.WriteLine("{0} - {1} {2}", student.Id, student.FirstName, student.LastName);

                foreach (var course in student.Courses)
                {
                    Console.WriteLine("   " + course.Name);
                }
            }

            Console.WriteLine();

            foreach (var course in context.Courses.Include(x => x.Students))
            {
                Console.WriteLine("{0} - {1}", course.Id, course.Name);

                foreach (var student in course.Students)
                {
                    Console.WriteLine("   " + student.FirstName + " " + student.LastName);
                }
            }

            var studentCourses = from student in context.Students
                                 from course in student.Courses
                                 select
                                     new
                                         {
                                             FullStudentName = student.LastName + ", " + student.FirstName,
                                             CourseName = course.Name
                                         };

            var castStudentCourses = studentCourses.Select(x => new Gemini(x) as dynamic);
            
            Console.WriteLine();

            foreach (var studentCourse in studentCourses)
            {
                Console.WriteLine(studentCourse.FullStudentName + " - " + studentCourse.CourseName);
            }

            Console.ReadLine();
        }
    }
}
