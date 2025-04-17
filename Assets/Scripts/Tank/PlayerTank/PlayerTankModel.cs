using UnityEngine;

public class PlayerTankModel : TankModel
{
    public float maxFuel;
    public float currentFuel;
    public float fuelConsumptionRate;

    public override void Initialize()
    {
        base.Initialize();
        currentFuel = maxFuel;
    }

    public void ConsumeFuel(float amount)
    {
        currentFuel = Mathf.Max(0, currentFuel - amount);
    }

    public void RefillFuel(float amount)
    {
        currentFuel = Mathf.Min(maxFuel, currentFuel + amount);
    }
}