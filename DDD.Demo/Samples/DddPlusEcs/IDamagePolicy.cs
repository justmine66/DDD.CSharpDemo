namespace DDD.Demo.Samples.DddPlusEcs
{
    /// <summary>
    /// 伤害策略接口
    /// </summary>
    public interface IDamagePolicy
    {
        bool CanApply(Player player, Weapon weapon, Monster monster);

        int CalculateDamage(Player player, Weapon weapon, Monster monster);
    }
}
