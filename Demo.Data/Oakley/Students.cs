using Massive;

namespace Demo.Data.Oakley
{
    public class Students : DynamicRepository
    {
        public Students()
        {
            Projection = (d) => new Student(d);
        }
    }
}