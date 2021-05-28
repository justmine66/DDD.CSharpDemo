using System;

namespace DDD.Demo.Samples.DddPlusEcs
{
    /// <summary>
    /// 武器标识
    /// </summary>
    public class WeaponId : IEquatable<WeaponId>
    {
        public WeaponId(long id)
        {
            Id = id;
        }

        public long Id { get; }

        public static implicit operator WeaponId(long id)
        {
            return new WeaponId(id);
        }

        public static implicit operator long(WeaponId id)
        {
            return id.Id;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public bool Equals(WeaponId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WeaponId)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    /// <summary>
    /// 武器类型
    /// </summary>
    [Flags]
    public enum WeaponType
    {
        /// <summary>
        /// 剑
        /// </summary>
        Sword,

        /// <summary>
        /// 法杖
        /// </summary>
        Staff,

        /// <summary>
        /// 匕首
        /// </summary>
        Dagger,

        /// <summary>
        /// 狙击枪
        /// </summary>
        SniperRifle
    }

    /// <summary>
    /// 武器
    /// </summary>
    public class Weapon
    {
        /// <summary>
        /// 初始化一把武器
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="name">名称</param>
        /// <param name="type">类型</param>
        /// <param name="damage">伤害值</param>
        /// <param name="damageType">伤害类型</param>
        public Weapon(
            WeaponId id,
            string name,
            WeaponType type,
            int damage,
            DamageType damageType = DamageType.Physical)
        {
            Id = id;
            Name = name;
            Damage = damage;
            Type = type;
            DamageType = damageType;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public WeaponId Id { get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 类型
        /// </summary>
        public WeaponType Type { get; }

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
            return $"[{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Type)}: {Type}, {nameof(Damage)}: {Damage}, {nameof(DamageType)}: {DamageType}]";
        }
    }
}
