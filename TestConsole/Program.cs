using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services;
using AdditionMicroService.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Actors.Client;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            Task.Run(async () =>
            {
                var actorId = ActorId.CreateRandom();

                var simpleActor =
                ActorProxy.Create<IAdditionMicroService>(actorId, "fabric:/ServiceFabricExample");

                await simpleActor.SetInputAsync("1+1", new System.Threading.CancellationToken());
                result = await simpleActor.GetResultAsync(new System.Threading.CancellationToken());

                Console.WriteLine("Result: " + result);
                Console.ReadLine();
            }).GetAwaiter().GetResult();
        }
    }
}
