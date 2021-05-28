using Microsoft.Extensions.DependencyInjection;
using System;

namespace DDD.Demo.Samples.DddPlusEcs
{
    public static class DddPlusEcsTester
    {
        private static IServiceProvider _serviceProvider;

        public static void Run()
        {
            Init();
            TestDragoonSpecial();
            TestFighterOrc();
            TestDragonImmunity();
            TestMageOrc();
            TestElfOrc();
            TestMovement();
        }

        public static void Init()
        {
            _serviceProvider = new ServiceCollection()
                // 注册格斗功能服务，请注意业务规则优先级。
                .AddSingleton<ICombatDomainService, CombatDomainServiceImpl>()
                .AddSingleton<IDamageManager, DamageManagerImpl>()
                .AddSingleton<IDamagePolicy, DragoonDamagePolicy>()
                .AddSingleton<IDamagePolicy, DragonImmunityDamagePolicy>()
                .AddSingleton<IDamagePolicy, ElfResistanceDamagePolicy>()
                .AddSingleton<IDamagePolicy, OrcResistanceDamagePolicy>()
                .AddSingleton<IDamagePolicy, DefaultDamagePolicy>()
                // 注册装备功能服务
                .AddSingleton<IEquipmentDomainService, EquipmentDomainServiceImpl>()
                .AddSingleton<IEquipmentManager, EquipmentManagerImpl>()
                .AddSingleton<IEquipmentPolicy, DragoonEquipmentPolicy>()
                .AddSingleton<IEquipmentPolicy, FighterEquipmentPolicy>()
                .AddSingleton<IEquipmentPolicy, MageEquipmentPolicy>()
                .AddSingleton<IWeaponRepository, WeaponRepositoryImpl>()
                .BuildServiceProvider();

            var sword = new Weapon(1, "剑", WeaponType.Sword, 10);
            var staff = new Weapon(2, "法杖", WeaponType.Staff, 10);
            var gun = new Weapon(3, "狙击枪", WeaponType.SniperRifle, 100);
            var dagger = new Weapon(4, "匕首", WeaponType.Dagger, 10);
            var iceStaff = new Weapon(5, "冰杖", WeaponType.Dagger, 20, DamageType.Ice);
            var fireSword = new Weapon(6, "火剑", WeaponType.Dagger, 20, DamageType.Fire);

            var weaponRepository = _serviceProvider.GetService<IWeaponRepository>();

            weaponRepository.Add(sword);
            weaponRepository.Add(staff);
            weaponRepository.Add(gun);
            weaponRepository.Add(dagger);
            weaponRepository.Add(iceStaff);
            weaponRepository.Add(fireSword);
        }

        /// <summary>
        /// Dragoon attack dragon doubles damage
        /// 龙骑对龙伤害加倍
        /// </summary>
        public static void TestDragoonSpecial()
        {
            var equipmentDomainService = _serviceProvider.GetService<IEquipmentDomainService>();
            var combatDomainService = _serviceProvider.GetService<ICombatDomainService>();
            var weaponRepository = _serviceProvider.GetService<IWeaponRepository>();

            var player = new Player(1, "龙骑", PlayerType.Dragoon);
            var monster = new Monster(1, "龙", MonsterType.Dragon);
            var weapon = weaponRepository.Get(1);
            var preHealth = monster.Health;

            equipmentDomainService.Equip(player, weapon);
            combatDomainService.PerformAttack(player, monster);

            if (monster.Health != preHealth - weapon.Damage * 2)
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Orc should receive half damage from physical weapons
        /// 兽人对物理攻击伤害减半
        /// </summary>
        public static void TestFighterOrc()
        {
            var equipmentDomainService = _serviceProvider.GetService<IEquipmentDomainService>();
            var combatDomainService = _serviceProvider.GetService<ICombatDomainService>();
            var weaponRepository = _serviceProvider.GetService<IWeaponRepository>();

            var player = new Player(2, "战士", PlayerType.Fighter);
            var monster = new Monster(2, "兽人", MonsterType.Orc);
            var weapon = weaponRepository.Get(1);
            var preHealth = monster.Health;

            equipmentDomainService.Equip(player, weapon);
            combatDomainService.PerformAttack(player, monster);

            if (monster.Health != preHealth - weapon.Damage / 2)
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Dragon is immune to attacks
        /// 龙对物理和魔法攻击免疫
        /// </summary>
        public static void TestDragonImmunity()
        {
            // 1、玩家使用物理类型的武器攻击，应用免疫。
            var equipmentDomainService = _serviceProvider.GetService<IEquipmentDomainService>();
            var combatDomainService = _serviceProvider.GetService<ICombatDomainService>();
            var weaponRepository = _serviceProvider.GetService<IWeaponRepository>();

            var fighter = new Player(3, "战士", PlayerType.Fighter);
            var mage = new Player(3, "法师", PlayerType.Mage);
            var dragon = new Monster(3, "龙", MonsterType.Dragon);
            var sword = weaponRepository.Get(1);
            var staff = weaponRepository.Get(2);
            var preHealth = dragon.Health;

            equipmentDomainService.Equip(fighter, sword);
            equipmentDomainService.Equip(mage, staff);

            combatDomainService.PerformAttack(fighter, dragon);
            combatDomainService.PerformAttack(mage, dragon);

            if (dragon.Health != preHealth)
            {
                throw new InvalidOperationException();
            }

            // 玩家使用火剑(非物理类型)攻击，应该受到正常伤害。
            Console.WriteLine();
            var fireSword = weaponRepository.Get(6);

            preHealth = dragon.Health;

            equipmentDomainService.Equip(fighter, fireSword);
            combatDomainService.PerformAttack(fighter, dragon);

            if (dragon.Health != preHealth - fireSword.Damage)
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine();
            var iceStaff = weaponRepository.Get(5);

            preHealth = dragon.Health;

            // 法师使用冰杖(非物理类型)攻击，应该免疫。
            equipmentDomainService.Equip(mage, iceStaff);
            combatDomainService.PerformAttack(mage, dragon);

            if (dragon.Health != preHealth)
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Orc receive full damage from magic attacks
        /// 兽人应该遭受完整的魔法伤害
        /// </summary>
        public static void TestMageOrc()
        {
            var equipmentDomainService = _serviceProvider.GetService<IEquipmentDomainService>();
            var combatDomainService = _serviceProvider.GetService<ICombatDomainService>();
            var weaponRepository = _serviceProvider.GetService<IWeaponRepository>();

            var player = new Player(7, "法师", PlayerType.Mage);
            var monster = new Monster(7, "兽人", MonsterType.Orc);
            var weapon = weaponRepository.Get(2);
            var preHealth = monster.Health;

            equipmentDomainService.Equip(player, weapon);
            combatDomainService.PerformAttack(player, monster);

            if (monster.Health != preHealth - weapon.Damage)
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Elf receive full damage from magic attacks
        /// 精灵应该遭受完整的非魔法伤害
        /// </summary>
        public static void TestElfOrc()
        {
            var equipmentDomainService = _serviceProvider.GetService<IEquipmentDomainService>();
            var combatDomainService = _serviceProvider.GetService<ICombatDomainService>();
            var weaponRepository = _serviceProvider.GetService<IWeaponRepository>();

            var player = new Player(8, "龙骑", PlayerType.Dragoon);
            var monster = new Monster(8, "精灵", MonsterType.Elf);
            var weapon = weaponRepository.Get(6);
            var preHealth = monster.Health;

            equipmentDomainService.Equip(player, weapon);
            combatDomainService.PerformAttack(player, monster);

            if (monster.Health != preHealth - weapon.Damage)
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Moving player and monster at the same time
        /// </summary>
        public static void TestMovement()
        {
            var fighter = new Player(9, "战士", PlayerType.Fighter);
            fighter.MoveTo(2, 5);
            fighter.StartMove(1, 0);

            var dragon = new Monster(3, "龙", MonsterType.Dragon);
            dragon.MoveTo(10, 5);
            dragon.StartMove(-1, 0);

            MovementSystem.Register(fighter);
            MovementSystem.Register(dragon);

            MovementSystem.Update();

            if (fighter.Position.X != 2 + 1)
            {
                throw new InvalidOperationException();
            }

            if (dragon.Position.X != 10 - 1)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
