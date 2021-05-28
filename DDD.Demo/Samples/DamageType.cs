using System;

namespace DDD.Demo.Samples
{
    /// <summary>
    /// 伤害类型
    /// </summary>
    [Flags]
    public enum DamageType
    {
        /// <summary>
        /// 物理
        /// </summary>
        Physical,

        /// <summary>
        /// 火
        /// </summary>
        Fire,

        /// <summary>
        /// 冰
        /// </summary>
        Ice,
    }
}
