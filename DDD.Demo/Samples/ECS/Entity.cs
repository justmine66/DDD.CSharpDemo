namespace DDD.Demo.Samples.ECS
{
    public class Entity
    {
        public Entity(Vector position)
        {
            Position = position;
        }

        // 此处Vector是一个Component, 指向的是MovementSystem.list里的一个
        public Vector Position { get; }
    }
}
