namespace DDD.Demo.Samples.DddPlusEcs
{
    /// <summary>
    /// 龙骑伤害策略
    /// </summary>
    public class DragoonDamagePolicy : IDamagePolicy
    {
        public bool CanApply(Player player, Weapon weapon, Monster monster)
        {
            return player.Type == PlayerType.Dragoon && 
                   monster.Type == MonsterType.Dragon;
        }

        public int CalculateDamage(Player player, Weapon weapon, Monster monster)
        {
            // 龙骑对龙伤害加倍
            return weapon.Damage * 2;
        }
    }
}
