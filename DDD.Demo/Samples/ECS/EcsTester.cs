using System;
using System.Collections.Generic;

namespace DDD.Demo.Samples.ECS
{
    public static class EcsTester
    {
        public static void Run()
        {
            MovementSystem system = new MovementSystem
            {
                List = new List<Vector>()
                {
                    new Vector(0, 0)
                }
            };

            Entity entity = new Entity(system.List[0]);

            system.Update(1);

            Console.WriteLine(entity.Position.X);
        }
    }
}
