namespace DDD.Demo.Samples.DddPlusEcs
{
    /// <summary>
    /// 龙免疫伤害策略
    /// </summary>
    public class DragonImmunityDamagePolicy : IDamagePolicy
    {
        public bool CanApply(Player player, Weapon weapon, Monster monster)
        {
            return (player.Type == PlayerType.Mage || 
                   weapon.DamageType == DamageType.Physical) && 
                   monster.Type == MonsterType.Dragon;
        }

        public int CalculateDamage(Player player, Weapon weapon, Monster monster)
        {
            // 龙对物理和魔法攻击免疫
            return 0;
        }
    }
}
