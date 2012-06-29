using Demo.Data.Entity;
using Demo.Data.Oakley;

namespace Demo.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            var client1 = new EntityClient();
            client1.Execute();

            var client2 = new OakleyClient();
            client2.Execute();
        }
    }
}
