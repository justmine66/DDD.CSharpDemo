namespace DDD.Demo.Samples.DddPlusEcs
{
    /// <summary>
    /// 可移动
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// 位置
        /// </summary>
        Transform Position { get; }

        /// <summary>
        /// 速度
        /// </summary>
        Vector Velocity { get; }

        /// <summary>
        /// 移动到
        /// </summary>
        /// <param name="x">横向坐标</param>
        /// <param name="y">纵向坐标</param>
        void MoveTo(long x, long y);

        /// <summary>
        /// 开始移动
        /// </summary>
        /// <param name="x">横向坐标</param>
        /// <param name="y">纵向坐标</param>
        void StartMove(long x, long y);

        /// <summary>
        /// 停止移动
        /// </summary>
        void StopMove();

        /// <summary>
        /// 是否正在移动
        /// </summary>
        bool IsMoving { get; }
    }
}
