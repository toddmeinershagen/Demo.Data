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
            var students = studentsRepo.All();

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

            //Gemini.Initialized<DynamicModel>((d) => Console.WriteLine("Hello:  " + d.ToString()));

            //foreach (var student in students)
            //{
            //    Console.WriteLine(student.ToString());

            //    foreach (var courseName in student.Courses().Select("Name"))
            //    {
            //        Console.WriteLine(courseName);
            //    }

            //    foreach (var course in student.Courses())
            //    {
            //        Console.WriteLine(course.ToString());
            //    }
            //}

            Console.ReadLine();
        }

    }
}
