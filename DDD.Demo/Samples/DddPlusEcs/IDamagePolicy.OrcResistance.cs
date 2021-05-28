namespace DDD.Demo.Samples.DddPlusEcs
{
    /// <summary>
    /// 兽人抵消伤害策略
    /// </summary>
    public class OrcResistanceDamagePolicy : IDamagePolicy
    {
        public bool CanApply(Player player, Weapon weapon, Monster monster)
        {
            return player.Type != PlayerType.Mage && 
                   monster.Type == MonsterType.Orc &&
                   weapon.DamageType == DamageType.Physical;
        }

        public int CalculateDamage(Player player, Weapon weapon, Monster monster)
        {
            // 兽人对物理攻击伤害减半
            return weapon.Damage / 2;
        }
    }
}
