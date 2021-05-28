using System;
using System.Collections.Generic;

namespace DDD.Demo.Samples.DddPlusEcs
{
    public class MovementSystem
    {
        private static readonly long XFenceMin = -100;
        private static readonly long XFenceMax = 100;
        private static readonly long YFenceMin = -100;
        private static readonly long YFenceMax = 100;

        private static readonly List<IMovable> Entities = new List<IMovable>();

        public static void Register(IMovable movable)
        {
            Entities.Add(movable);
        }

        public static void Update()
        {
            foreach (var entity in Entities)
            {
                if (!entity.IsMoving)
                {
                    continue;
                }

                var position = entity.Position;
                var velocity = entity.Velocity;

                var newX = Math.Max(Math.Min(position.X + velocity.X, XFenceMax), XFenceMin);
                var newY = Math.Max(Math.Min(position.Y + velocity.Y, YFenceMax), YFenceMin);

                entity.MoveTo(newX, newY);
            }
        }
    }
}
