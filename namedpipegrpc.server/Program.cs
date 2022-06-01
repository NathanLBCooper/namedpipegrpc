using System.Threading.Tasks;
using Grpc.Core;
using GrpcDotNetNamedPipes;
using namedpipegrpc.defs;

namespace namedpipegrpc.server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new NamedPipeServer("pipe_for_maths");
            Maths.BindService(server.ServiceBinder, new MathsService());
            server.Start();
        }
    }

    class MathsService : Maths.MathsBase
    {
        public override async Task<AddReply> Add(AddRequest request, ServerCallContext context)
        {
            await Task.CompletedTask;
            return new AddReply
            {
                N = request.N + request.M
            };
        }
    }
}
