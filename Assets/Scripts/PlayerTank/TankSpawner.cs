using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TankSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Tank
    {
        public float movementSpeed;
        public float rotationSpeed;
        public TankType tankType;
        public Material color;
    }

    public CameraController cam;
    public List<Tank> tankList;
    public TankView tankView;

    // void Start()
    // {
    //     CreateTank();
    // }

    private void CreateTank(TankType tankType)
    {
        int index = (int)tankType;
        TankModel tankModel = new TankModel
        (
            tankList[index].movementSpeed,
            tankList[index].rotationSpeed,
            tankList[index].tankType,
            tankList[index].color
        );

        TankController tankController = new TankController(tankModel, tankView, cam);
    }
}