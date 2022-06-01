using System;
using System.Threading.Tasks;
using GrpcDotNetNamedPipes;
using namedpipegrpc.defs;

namespace namedpipegrpc.client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = new NamedPipeChannel(".", "pipe_for_maths");
            var client = new Maths.MathsClient(channel);

            while (true)
            {
                var n = int.Parse(Console.ReadLine());
                var m = int.Parse(Console.ReadLine());

                var response = await client.AddAsync(new AddRequest { N = n, M = m });

                Console.WriteLine($"{n} plus {m} is {response.N}");
            }
        }
    }
}
