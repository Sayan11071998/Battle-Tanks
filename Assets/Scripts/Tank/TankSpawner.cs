using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Tank
    {
        public TankTypes tankType;
        public float movementSpeed;
        public float rotationSpeed;
        public Material color;
        public float health;
        public float firePower;
    }

    public List<Tank> tankList;
    public TankView tankView;
    public BulletSpawner bulletSpawner;

    public void CreateTank(TankTypes tankType)
    {
        if (tankType == TankTypes.GreenTank)
        {
            TankModel tankModel = new TankModel
            (
                tankList[0].movementSpeed,
                tankList[0].rotationSpeed,
                tankList[0].tankType,
                tankList[0].color,
                tankList[0].health,
                tankList[0].firePower
            );
            TankController tankController = new TankController(tankModel, tankView, bulletSpawner);
        }
        else if (tankType == TankTypes.BlueTank)
        {
            TankModel tankModel = new TankModel
            (
                tankList[1].movementSpeed,
                tankList[1].rotationSpeed,
                tankList[1].tankType,
                tankList[1].color,
                tankList[1].health,
                tankList[1].firePower
            );
            TankController tankController = new TankController(tankModel, tankView, bulletSpawner);
        }
        else if (tankType == TankTypes.RedTank)
        {
            TankModel tankModel = new TankModel
            (
                tankList[2].movementSpeed,
                tankList[2].rotationSpeed,
                tankList[2].tankType,
                tankList[2].color,
                tankList[2].health,
                tankList[2].firePower
            );
            TankController tankController = new TankController(tankModel, tankView, bulletSpawner);
        }
    }
}