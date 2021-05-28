namespace DDD.Demo.Samples.DddPlusEcs
{
    /// <summary>
    /// 法师装配策略
    /// </summary>
    public class MageEquipmentPolicy : IEquipmentPolicy
    {
        public virtual bool CanApply(Player player, Weapon weapon)
        {
            return player.Type == PlayerType.Mage;
        }

        /// <summary>
        /// 是否能装备
        /// </summary>
        /// <param name="player">玩家</param>
        /// <param name="weapon">武器</param>
        /// <returns>True：能装备，否则反之。</returns>
        public virtual bool CanEquip(Player player, Weapon weapon)
        {
            var weaponType = weapon.Type;

            // Fighter 能装备 Staff 和 Dagger
            return weaponType == WeaponType.Staff || weaponType == WeaponType.Dagger;
        }
    }
}