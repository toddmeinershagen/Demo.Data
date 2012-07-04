using System;

namespace Demo.Data.Oakley
{
    public class OakleyClient
    {
        public void Execute()
        {
            Console.WriteLine("OakleyClient");
            Console.WriteLine("");

            var studentsRepo = new Students();
            dynamic students = studentsRepo.All();

            foreach (var student in students)
            {
                Console.WriteLine("{0} - {1} {2}", student.Id, student.FirstName, student.LastName);

                foreach (var course in student.Courses())
                {
                    Console.WriteLine("   " + course.Name);
                }
            }

            Console.WriteLine();

            var coursesRepo = new Courses();
            var courses = coursesRepo.All();

            foreach (var course in courses)
            {
                Console.WriteLine("{0} - {1}", course.Id, course.Name);

                foreach (var student in course.Students())
                {
                    Console.WriteLine("   " + student.FirstName + " " + student.LastName);
                }
            }

            dynamic newStudents = studentsRepo.All();
            var coursesForStudent = newStudents.Courses();

            foreach (var course in coursesForStudent)
            {
                Console.WriteLine(string.Format("{0}, {1} - {2}", course.Student.FirstName, course.Student.LastName, course.Name));
            }

            Console.ReadLine();
        }

    }
}
