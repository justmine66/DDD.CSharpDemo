using System;

namespace DDD.Demo.Samples.OOP
{
    /// <summary>
    /// 玩家
    /// </summary>
    public abstract class Player
    {
        protected Player(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 武器
        /// </summary>
        public Weapon Weapon { get; private set; }

        /// <summary>
        /// 装备
        /// </summary>
        /// <param name="weapon">武器</param>
        public virtual void Equip(Weapon weapon)
        {
            Console.WriteLine($"玩家: {Name} 开始装备武器: {weapon}.");

            Weapon = weapon;

            Console.WriteLine($"玩家: {Name} 结束装备武器: {weapon}.");
        }

        /// <summary>
        /// 攻击
        /// </summary>
        /// <param name="monster">怪兽</param>
        public void Attack(Monster monster)
        {
            Console.WriteLine($"玩家: {Name} 开始攻击怪兽: {monster}.");

            monster.ReceiveDamageBy(Weapon, this);

            Console.WriteLine($"玩家: {Name} 结束攻击怪兽: {monster}.");
        }
    }

    /// <summary>
    /// 战士
    /// </summary>
    public class Fighter : Player
    {
        public Fighter(string name) : base(name)
        {
        }

        public override void Equip(Weapon weapon)
        {
            if (weapon.GetType() != typeof(Sword))
            {
                return;
            }

            base.Equip(weapon);
        }
    }

    /// <summary>
    /// 法师
    /// </summary>
    public class Mage : Player
    {
        public Mage(string name) : base(name)
        {
        }

        public override void Equip(Weapon weapon)
        {
            if (weapon.GetType() != typeof(Staff))
            {
                throw new InvalidOperationException("法师只能装备法杖");
            }

            base.Equip(weapon);
        }
    }

    /// <summary>
    /// 龙骑
    /// </summary>
    public class Dragoon : Player
    {
        public Dragoon(string name) : base(name)
        {
        }

        public override void Equip(Weapon weapon)
        {
            if (weapon.GetType() == typeof(Dagger))
            {
                throw new InvalidOperationException("龙骑不能装备匕首");
            }

            base.Equip(weapon);
        }
    }
}
