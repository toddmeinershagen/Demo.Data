using System.Collections.Generic;
using Massive;
using Oak;

namespace Demo.Data.Oakley
{
    public class CoursesStudents : DynamicRepository
    {
        
    }


    public class Student : DynamicModel
    {
        private readonly CoursesStudents _coursesStudents = new CoursesStudents();
        readonly Courses _courses = new Courses();
        //readonly Students _students = new Students();

        public Student(object dto)
            : base(dto)
        {

        }

        IEnumerable<dynamic> Associates()
        {
            yield return new HasManyThrough(repository: _courses, through: _coursesStudents);
        }
    }
}