using System;

namespace DDD.Demo.Samples.DddPlusEcs
{
    /// <summary>
    /// 格斗领域服务
    /// </summary>
    public interface ICombatDomainService
    {
        void PerformAttack(Player player, Monster monster);
    }

    public class CombatDomainServiceImpl : ICombatDomainService
    {
        private readonly IWeaponRepository _repository;
        private readonly IDamageManager _manager;

        public CombatDomainServiceImpl(IWeaponRepository repository, IDamageManager manager)
        {
            _repository = repository;
            _manager = manager;
        }

        public void PerformAttack(Player player, Monster monster)
        {
            Console.WriteLine($"玩家: {player} 开始攻击怪兽: {monster}.");

            var weapon = _repository.Get(player.WeaponId);
            var damage = _manager.CalculateDamage(player, weapon, monster);
            if (damage > 0)
            {
                monster.TakeDamage(damage);  
            }

            Console.WriteLine($"玩家: {player} 结束攻击怪兽: {monster}.");
        }
    }
}
