using System;

namespace DDD.Demo.Samples.DddPlusEcs
{
    public class PlayerId : IEquatable<PlayerId>
    {
        public PlayerId(long id)
        {
            Id = id;
        }

        public long Id { get; }

        public static implicit operator PlayerId(long id)
        {
            return new PlayerId(id);
        }

        public static implicit operator long(PlayerId id)
        {
            return id.Id;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public bool Equals(PlayerId other)
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
            return Equals((PlayerId) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    /// <summary>
    /// 玩家类型
    /// </summary>
    [Flags]
    public enum PlayerType
    {
        /// <summary>
        /// 战士
        /// </summary>
        Fighter, 

        /// <summary>
        /// 法师
        /// </summary>
        Mage, 

        /// <summary>
        /// 龙骑
        /// </summary>
        Dragoon
    }

    /// <summary>
    /// 玩家
    /// </summary>
    public class Player : IMovable
    {
        /// <summary>
        /// 初始化一位玩家
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="name">名称</param>
        /// <param name="type">类型</param>
        public Player(PlayerId id, string name, PlayerType type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public PlayerId Id { get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 类型
        /// </summary>
        public PlayerType Type { get; }

        /// <summary>
        /// 武器标识
        /// </summary>
        public WeaponId WeaponId { get; private set; }

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
        /// 装备
        /// </summary>
        /// <param name="weaponId">武器标识</param>
        public void Equip(WeaponId weaponId)
        {
            WeaponId = weaponId;
        }

        public override string ToString()
        {
            return $"[{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Type)}: {Type}, {nameof(WeaponId)}: {WeaponId}]";
        }
    }
}
