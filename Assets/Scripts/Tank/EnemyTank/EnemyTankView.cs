using UnityEngine;
using UnityEngine.UI;

public class EnemyTankView : TankView
{
    [SerializeField] private Image healthBarFill;
    [SerializeField] private GameObject healthBarCanvas;
    [SerializeField] private Renderer tankRenderer;
    [SerializeField] private Color heavyTankColor = Color.red;
    [SerializeField] private Color scoutTankColor = Color.blue;
    [SerializeField] private Color artilleryTankColor = Color.green;

    private EnemyTankModel enemyModel;

    public override void Initialize(TankModel tankModel)
    {
        base.Initialize(tankModel);
        enemyModel = tankModel as EnemyTankModel;

        if (enemyModel != null)
        {
            SetTankColor();
        }
    }

    private void SetTankColor()
    {
        if (tankRenderer != null)
        {
            Material material = tankRenderer.material;
            switch (enemyModel.tankType)
            {
                case EnemyTankModel.TankType.HeavyAssault:
                    material.color = heavyTankColor;
                    break;
                case EnemyTankModel.TankType.Scout:
                    material.color = scoutTankColor;
                    break;
                case EnemyTankModel.TankType.Artillery:
                    material.color = artilleryTankColor;
                    break;
            }
        }
    }

    protected override void UpdateHealthVisuals(float current, float max)
    {
        base.UpdateHealthVisuals(current, max);

        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = current / max;
        }
    }
}