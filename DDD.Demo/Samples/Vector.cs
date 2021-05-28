namespace DDD.Demo.Samples
{
    public class Vector
    {
        public static readonly Vector Zero = new Vector(0, 0);

        public Vector(long x, long y)
        {
            X = x;
            Y = y;
        }

        public long X { get; set; }

        public long Y { get; set; }
    }
}
