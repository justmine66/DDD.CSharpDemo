namespace DDD.Demo.Samples.OOP
{
    /// <summary>
    /// 怪兽
    /// </summary>
    public abstract class Monster
    {
        protected Monster(string name, long health)
        {
            Name = name;
            Health = health;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 生命值
        /// </summary>
        public long Health { get; protected set; }

        /// <summary>
        /// 受到伤害
        /// </summary>
        /// <param name="weapon">武器</param>
        /// <param name="player">玩家</param>
        public virtual void ReceiveDamageBy(Weapon weapon, Player player)
        {
            if (weapon is SniperRifle)
            {
                Health = 0;
            }
            else
            {
                // 默认伤害规则
                Health -= weapon.Damage;
            }
        }

        public override string ToString()
        {
            return $"[{nameof(Name)}: {Name}, {nameof(Health)}: {Health}]";
        }
    }

    /// <summary>
    /// 兽人
    /// </summary>
    public class Orc : Monster
    {
        public override void ReceiveDamageBy(Weapon weapon, Player player)
        {
            if (weapon is SniperRifle)
            {
                base.ReceiveDamageBy(weapon, player);
                return;
            }

            if (player.GetType() != typeof(Mage) &&
            weapon.DamageType == DamageType.Physical)
            {
                // 兽人对物理攻击伤害减半
                Health = (Health - weapon.Damage / 2);
            }
            else
            {
                base.ReceiveDamageBy(weapon, player);
            }
        }

        public Orc(string name, long health) : base(name, health)
        {
        }
    }

    /// <summary>
    /// 精灵
    /// </summary>
    public class Elf : Monster
    {
        public Elf(string name, long health) : base(name, health)
        {
        }

        public override void ReceiveDamageBy(Weapon weapon, Player player)
        {
            if (weapon is SniperRifle)
            {
                base.ReceiveDamageBy(weapon, player);
                return;
            }

            if (player is Mage)
            {
                // 精灵对魔法攻击伤害减半
                Health = (Health - weapon.Damage / 2);
            }
            else
            {
                base.ReceiveDamageBy(weapon, player);
            }
        }
    }

    /// <summary>
    /// 龙
    /// </summary>
    public class Dragon : Monster
    {
        public override void ReceiveDamageBy(Weapon weapon, Player player)
        {
            if (weapon is SniperRifle)
            {
                base.ReceiveDamageBy(weapon, player);
                return;
            }

            if (player is Dragoon)
            {
                // 龙骑对龙伤害加倍
                Health = Health - weapon.Damage * 2;
            }
        }

        public Dragon(string name, long health) : base(name, health)
        {
        }
    }
}
