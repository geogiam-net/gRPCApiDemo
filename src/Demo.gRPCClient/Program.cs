using Grpc.Net.Client;
using Demo.gRPCClient;

Console.WriteLine("Press any key to start");
Console.ReadKey();

const string serverUrl = "http://localhost:5003";

using var channel = GrpcChannel.ForAddress(serverUrl);

var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync( new HelloRequest { Name = "GreeterClient" });

Console.WriteLine("");
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("");

Console.WriteLine("Press any key to exit");

Console.ReadKey();