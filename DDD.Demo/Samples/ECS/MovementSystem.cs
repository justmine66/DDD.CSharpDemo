using System.Collections.Generic;

namespace DDD.Demo.Samples.ECS
{
    public class MovementSystem
    {
        public List<Vector> List { get; set; }

        // System的行为
        public void Update(long delta)
        {
            foreach (var pos in List)
            {
                // 这个loop直接走了CPU缓存，性能很高，同时可以用SIMD优化
                pos.X = pos.X + delta;
                pos.Y = pos.Y + delta;
            }
        }
    }
}
