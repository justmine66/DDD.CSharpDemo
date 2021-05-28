namespace DDD.Demo.Samples.DddPlusEcs
{
    public interface IEquipmentPolicy
    {
        bool CanApply(Player player, Weapon weapon);

        bool CanEquip(Player player, Weapon weapon);
    }
}