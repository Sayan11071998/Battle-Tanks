using UnityEngine;

public class EnemyTankModel : TankModel
{
    public TankType tankType;

    public enum TankType
    {
        HeavyAssault,
        Scout,
        Artillery
    }
}