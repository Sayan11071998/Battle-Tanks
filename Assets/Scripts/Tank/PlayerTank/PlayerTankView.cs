using UnityEngine;
using UnityEngine.UI;

public class PlayerTankView : TankView
{
    [SerializeField] private Image healthBarFill;
    [SerializeField] private Image fuelBarFill;

    private PlayerTankModel playerModel;

    public override void Initialize(TankModel tankModel)
    {
        base.Initialize(tankModel);
        playerModel = tankModel as PlayerTankModel;
    }

    protected override void UpdateHealthVisuals(float current, float max)
    {
        base.UpdateHealthVisuals(current, max);

        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = current / max;
        }
    }

    public void UpdateFuelVisuals(float current, float max)
    {
        if (fuelBarFill != null)
        {
            fuelBarFill.fillAmount = current / max;
        }
    }
}