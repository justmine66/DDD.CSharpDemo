namespace DDD.Demo.Samples.DddPlusEcs
{
    public class DefaultDamagePolicy : IDamagePolicy
    {
        public bool CanApply(Player player, Weapon weapon, Monster monster)
        {
            return true;
        }

        public int CalculateDamage(Player player, Weapon weapon, Monster monster)
        {
            return weapon.Damage;
        }
    }
}
