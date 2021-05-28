namespace DDD.Demo.Samples
{
    public class Transform
    {
        public static readonly Transform Zero = new Transform(0, 0);

        public Transform(long x, long y)
        {
            X = x;
            Y = y;
        }

        public long X { get; }

        public long Y { get; }
    }
}
