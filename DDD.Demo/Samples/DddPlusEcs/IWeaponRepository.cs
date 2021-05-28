using System.Collections.Generic;
using System.Linq;

namespace DDD.Demo.Samples.DddPlusEcs
{
    public interface IWeaponRepository
    {
        void Add(Weapon weapon);
        Weapon Get(WeaponId id);
    }

    public class WeaponRepositoryImpl : IWeaponRepository
    {
        private readonly List<Weapon> _weapons = new List<Weapon>();

        public void Add(Weapon weapon)
        {
            _weapons.Add(weapon);
        }

        public Weapon Get(WeaponId id)
        {
            return _weapons.Single(it => it.Id.Equals(id));
        }
    }
}
