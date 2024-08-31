using Grpc.Core;

namespace grpc_csharp.server;
internal class Program
{
    const int Port = 50051;

    private static void Main(string[] args)
    {
        Server server = null;
        try
        {
            server = new Server()
            {
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();
            Console.WriteLine("Servidor escutando na porta : " + Port);
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao iniciar o servidor : " + ex.Message);
            throw;
        }
        finally
        {
            if (server != null)
                server.ShutdownAsync().Wait();
        }
    }
}