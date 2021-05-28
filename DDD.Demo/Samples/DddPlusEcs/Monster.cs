using System;

namespace DDD.Demo.Samples.DddPlusEcs
{
    public class MonsterId : IEquatable<MonsterId>
    {
        public MonsterId(long id)
        {
            Id = id;
        }

        public long Id { get; }

        public static implicit operator MonsterId(long id)
        {
            return new MonsterId(id);
        }

        public static implicit operator long(MonsterId id)
        {
            return id.Id;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public bool Equals(MonsterId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((MonsterId)obj);
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
    public enum MonsterType
    {
        /// <summary>
        /// 兽人
        /// </summary>
        Orc,

        /// <summary>
        /// 精灵
        /// </summary>
        Elf,

        /// <summary>
        /// 龙
        /// </summary>
        Dragon
    }

    /// <summary>
    /// 怪兽
    /// </summary>
    public class Monster : IMovable
    {
        /// <summary>
        /// 初始化一只怪兽
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="name">名称</param>
        /// <param name="type">类型</param>
        /// <param name="initialHealth">初始生命值</param>
        public Monster(MonsterId id, string name, MonsterType type, long initialHealth = 100)
        {
            Id = id;
            Name = name;
            Type = type;
            Health = initialHealth;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public MonsterId Id { get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 类型
        /// </summary>
        public MonsterType Type { get; }

        /// <summary>
        /// 生命值
        /// </summary>
        public long Health { get; private set; }

        /// <summary>
        /// 位置
        /// </summary>
        public Transform Position { get; private set; } = Transform.Zero;

        /// <summary>
        /// 速度
        /// </summary>
        public Vector Velocity { get; private set; } = Vector.Zero;

        /// <summary>
        /// 移动到
        /// </summary>
        /// <param name="x">横向坐标</param>
        /// <param name="y">纵向坐标</param>
        public void MoveTo(long x, long y)
        {
            Position = new Transform(x, y);
        }

        /// <summary>
        /// 开始移动
        /// </summary>
        /// <param name="x">横向坐标</param>
        /// <param name="y">纵向坐标</param>
        public void StartMove(long x, long y)
        {
            Velocity = new Vector(x, y);
        }

        /// <summary>
        /// 停止移动
        /// </summary>
        public void StopMove()
        {
            Velocity = Vector.Zero;
        }

        /// <summary>
        /// 是否正在移动
        /// </summary>
        public virtual bool IsMoving => Velocity.X != 0 || Velocity.Y != 0;

        /// <summary>
        /// 接受伤害
        /// </summary>
        /// <param name="damage">伤害值</param>
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public override string ToString()
        {
            return $"[{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Type)}: {Type}, {nameof(Health)}: {Health}]";
        }
    }
}
