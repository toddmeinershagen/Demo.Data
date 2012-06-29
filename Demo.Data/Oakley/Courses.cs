using Massive;

namespace Demo.Data.Oakley
{
    public class Courses : DynamicRepository
    {
        public Courses()
        {
            Projection = (d) => new Course(d);
        }
    }
}