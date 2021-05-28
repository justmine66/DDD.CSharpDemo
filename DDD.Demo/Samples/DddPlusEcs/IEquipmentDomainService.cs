using System;

namespace DDD.Demo.Samples.DddPlusEcs
{
    /// <summary>
    /// 装备领域服务
    /// </summary>
    public interface IEquipmentDomainService
    {
        /// <summary>
        /// 是否能装备
        /// </summary>
        /// <param name="player">玩家</param>
        /// <param name="weapon">武器</param>
        /// <returns>True 表示能装备，否则反之。</returns>
        void Equip(Player player, Weapon weapon);
    }

    public class EquipmentDomainServiceImpl : IEquipmentDomainService
    {
        private readonly IEquipmentManager _equipmentManager;

        public EquipmentDomainServiceImpl(IEquipmentManager equipmentManager)
        {
            _equipmentManager = equipmentManager;
        }

        public virtual void Equip(Player player, Weapon weapon)
        {
            if (_equipmentManager.CanEquip(player, weapon))
            {
                player.Equip(weapon.Id);

                Console.WriteLine($"玩家: {this} 已装备武器: {weapon}");
            }
            else
            {
                throw new InvalidOperationException($"玩家: {player} 无法装备武器: {weapon}");
            }
        }
    }
}