using System;

namespace DDD.Demo.Samples.OOP
{
    public static class OopTester
    {
        public static void Run()
        {
            TestDragonImmunity();
            TestDragoonSpecial();
            TestFighterOrc();
            TestMageOrc();
            TestEquip();
        }

        public static void TestEquip()
        {
            // 战士只能装备剑
            var fighter = new Fighter("战士");

            var sword = new Sword("剑", 10);
            fighter.Equip(sword);

            var staff = new Staff("法杖", 10);
            fighter.Equip(staff);

            if (fighter.Weapon.GetType() != sword.GetType())
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine();
        }

        // Dragon is immune to attacks
        public static void TestDragonImmunity()
        {
            // 龙对物理和魔法攻击免疫
            var fighter = new Fighter("战士");
            var sword = new Sword("亚瑟王的神剑", 10);
            var dragon = new Dragon("龙", 100L);

            fighter.Equip(sword);
            fighter.Attack(dragon);

            if (dragon.Health != 100)
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine();
        }

        // Dragoon attack dragon doubles damage
        public static void TestDragoonSpecial()
        {
            // 龙骑对龙伤害加倍
            var dragoon = new Dragoon("龙骑");
            var sword = new Sword("亚瑟王的神剑", 10);
            var dragon = new Dragon("龙", 100L);

            dragoon.Equip(sword);
            dragoon.Attack(dragon);

            if (dragon.Health != 80)
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine();
        }

        // Orc should receive half damage from physical weapons
        public static void TestFighterOrc()
        {
            // 兽人对物理攻击伤害减半。
            var fighter = new Fighter("战士");
            var sword = new Sword("亚瑟王的神剑", 10);
            var orc = new Orc("兽人", 100L);

            fighter.Equip(sword);
            fighter.Attack(orc);

            if (orc.Health != 95)
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine();
        }

        // Orc receive full damage from magic attacks
        public static void TestMageOrc()
        {
            Console.WriteLine();

            // 兽人应该遭受完整的魔法攻击
            var mage = new Mage("法师");
            var staff = new Staff("火焰法杖", 10);
            var orc = new Orc("兽人", 100L);

            mage.Equip(staff);
            mage.Attack(orc);

            if (orc.Health != 90)
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine();
        }
    }
}
