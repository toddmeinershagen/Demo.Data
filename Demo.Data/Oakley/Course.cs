using System.Collections.Generic;
using Oak;

namespace Demo.Data.Oakley
{
    public class Course : DynamicModel
    {
        Students _studentsRepository = new Students();
        StudentsCourses _studentsCoursesRepository = new StudentsCourses();

        public Course(object dto)
            : base(dto)
        {

        }

        IEnumerable<dynamic> Associates()
        {
            yield return new HasManyThrough(repository: _studentsRepository, through: _studentsCoursesRepository);
        }
    }
}
