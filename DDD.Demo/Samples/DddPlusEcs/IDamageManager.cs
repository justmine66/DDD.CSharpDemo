using System.Collections.Generic;

namespace DDD.Demo.Samples.DddPlusEcs
{
    public interface IDamageManager
    {
        int CalculateDamage(Player player, Weapon weapon, Monster monster);
    }

    public class DamageManagerImpl : IDamageManager
    {
        private readonly IEnumerable<IDamagePolicy> _policies;

        public DamageManagerImpl(IEnumerable<IDamagePolicy> policies)
        {
            _policies = policies;
        }

        public int CalculateDamage(Player player, Weapon weapon, Monster monster)
        {
            foreach (var policy in _policies)
            {
                if (!policy.CanApply(player, weapon, monster))
                {
                    continue;
                }

                return policy.CalculateDamage(player, weapon, monster);
            }
            return 0;
        }
    }
}
