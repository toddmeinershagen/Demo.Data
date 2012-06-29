using System.Collections.Generic;
using Oak;

namespace Demo.Data.Oakley
{
    public class Student : DynamicModel
    {
        Courses _coursesRepository = new Courses();
        StudentsCourses _studentsCoursesRepository = new StudentsCourses();

        public Student(object dto)
            : base(dto)
        {

        }

        IEnumerable<dynamic> Associates()
        {
            yield return new HasManyThrough(repository: _coursesRepository, through: _studentsCoursesRepository);
        }
    }
}