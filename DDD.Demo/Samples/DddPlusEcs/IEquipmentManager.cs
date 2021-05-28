using System.Collections.Generic;

namespace DDD.Demo.Samples.DddPlusEcs
{
    public interface IEquipmentManager
    {
        bool CanEquip(Player player, Weapon weapon);
    }

    public class EquipmentManagerImpl : IEquipmentManager
    {
        private readonly IEnumerable<IEquipmentPolicy> _policies;

        public EquipmentManagerImpl(IEnumerable<IEquipmentPolicy> policies)
        {
            _policies = policies;
        }

        public bool CanEquip(Player player, Weapon weapon)
        {
            if (_policies != null)
            {
                foreach (var policy in _policies)
                {
                    if (!policy.CanApply(player, weapon))
                    {
                        continue;
                    }

                    return policy.CanEquip(player, weapon);
                }
            }

            return false;
        }
    }
}
