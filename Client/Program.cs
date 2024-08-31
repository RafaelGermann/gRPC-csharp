using Dummy;
using Grpc.Core;

namespace grpc_csharp.client;
public class Program
{
    const string target = "127.0.0.1:50051";
    private static void Main(string[] args)
    {
        var channel = new Channel(target, ChannelCredentials.Insecure);

        channel.ConnectAsync().ContinueWith((task) =>
        {
            if (task.Status == TaskStatus.RanToCompletion)
                Console.WriteLine("Conectado com sucesso!");
        });
        var client = new DummyService.DummyServiceClient(channel);
        channel.ShutdownAsync().Wait();
        Console.ReadKey();
    }
}