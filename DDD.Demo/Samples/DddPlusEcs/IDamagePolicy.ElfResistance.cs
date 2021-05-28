namespace DDD.Demo.Samples.DddPlusEcs
{
    /// <summary>
    /// 精灵抵消伤害策略
    /// </summary>
    public class ElfResistanceDamagePolicy : IDamagePolicy
    {
        public bool CanApply(Player player, Weapon weapon, Monster monster)
        {
            return player.Type == PlayerType.Mage && 
                   monster.Type == MonsterType.Elf;
        }

        public int CalculateDamage(Player player, Weapon weapon, Monster monster)
        {
            // 精灵对魔法攻击伤害减半
            return weapon.Damage / 2;
        }
    }
}
