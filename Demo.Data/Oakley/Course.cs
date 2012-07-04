using System.Collections.Generic;
using Oak;

namespace Demo.Data.Oakley
{
    public class Course : DynamicModel
    {
        readonly Students _students = new Students();
        private readonly Courses _courses = new Courses();

        public Course(object dto)
            : base(dto)
        {

        }

        IEnumerable<dynamic> Associates()
        {
            yield return new HasManyAndBelongsTo(repository: _students, reference: _courses);
        }
    }
}
