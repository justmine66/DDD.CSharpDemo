namespace DDD.Demo.Samples.DddPlusEcs
{
    /// <summary>
    /// 战士装备策略
    /// </summary>
    public class FighterEquipmentPolicy : IEquipmentPolicy
    {
        public virtual bool CanApply(Player player, Weapon weapon)
        {
            return player.Type == PlayerType.Fighter;
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

            // Fighter 能装备 Sword 和 Dagger
            return weaponType == WeaponType.Sword || weaponType == WeaponType.Dagger;
        }
    }
}