namespace DDD.Demo.Samples.DddPlusEcs
{
    /// <summary>
    /// 龙骑装配策略
    /// </summary>
    public class DragoonEquipmentPolicy : IEquipmentPolicy
    {
        public virtual bool CanApply(Player player, Weapon weapon)
        {
            return player.Type == PlayerType.Dragoon;
        }

        public virtual bool CanEquip(Player player, Weapon weapon)
        {
            // 龙骑可以装备任何武器
            return true;
        }
    }
}