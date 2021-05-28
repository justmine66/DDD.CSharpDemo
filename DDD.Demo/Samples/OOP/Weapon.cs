namespace DDD.Demo.Samples.OOP
{
    /// <summary>
    /// 武器
    /// </summary>
    public abstract class Weapon
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="damage">伤害值</param>
        /// <param name="damageType">伤害类型</param>
        protected Weapon(string name, int damage, DamageType damageType = DamageType.Physical)
        {
            Name = name;
            Damage = damage;
            DamageType = damageType;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 伤害值
        /// </summary>
        public int Damage { get; }

        /// <summary>
        /// 伤害类型
        /// </summary>
        public DamageType DamageType { get; }

        public override string ToString()
        {
            return $"[{nameof(Name)}: {Name}, {nameof(Damage)}: {Damage}, {nameof(DamageType)}: {DamageType}]";
        }
    }

    /// <summary>
    /// 剑
    /// </summary>
    public class Sword : Weapon
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="damage">伤害值</param>
        /// <param name="damageType">伤害类型</param>
        public Sword(string name, int damage, DamageType damageType = DamageType.Physical)
            : base(name, damage, damageType)
        {
        }
    }

    /// <summary>
    /// 法杖
    /// </summary>
    public class Staff : Weapon
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="damage">伤害值</param>
        /// <param name="damageType">伤害类型</param>
        public Staff(string name, int damage, DamageType damageType = DamageType.Physical)
            : base(name, damage, damageType)
        {
        }
    }

    /// <summary>
    /// 匕首
    /// </summary>
    public class Dagger : Weapon
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="damage">伤害值</param>
        /// <param name="damageType">伤害类型</param>
        public Dagger(string name, int damage, DamageType damageType = DamageType.Physical)
            : base(name, damage, damageType)
        {
        }
    }

    /// <summary>
    /// 狙击枪
    /// </summary>
    public class SniperRifle : Weapon
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="damage">伤害值</param>
        /// <param name="damageType">伤害类型</param>
        public SniperRifle(string name, int damage, DamageType damageType = DamageType.Physical)
            : base(name, damage, damageType)
        {
        }
    }
}
