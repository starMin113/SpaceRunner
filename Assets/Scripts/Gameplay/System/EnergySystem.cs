using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    // 当前燃料箱数量
    public int fuelBoxes = 3;
    // 当前电池包数量
    public int batteryPacks = 0;
    // 最大燃料箱容量
    public int maxFuelBoxes = 10;

    // 消耗燃料箱的方法
    public bool ConsumeFuelBox(int amount = 1)
    {
        if (fuelBoxes >= amount)
        {
            fuelBoxes -= amount;
            return true;
        }
        return false;
    }

    // 获取/增加燃料箱
    public void AddFuelBox(int amount = 1)
    {
        fuelBoxes = Mathf.Min(maxFuelBoxes, fuelBoxes + amount);
    }

    // 获取/增加电池包
    public void AddBatteryPack(int amount = 1)
    {
        batteryPacks += amount;
    }

    // 消耗电池包
    public bool ConsumeBatteryPack(int amount = 1)
    {
        if (batteryPacks >= amount)
        {
            batteryPacks -= amount;
            return true;
        }
        return false;
    }
}