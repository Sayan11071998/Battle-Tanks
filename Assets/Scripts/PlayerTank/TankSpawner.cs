using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TankSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Tank
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private TankType tankType;
        [SerializeField] private Material color;

        public float MovementSpeed => movementSpeed;
        public float RotationSpeed => rotationSpeed;
        public TankType TankType => tankType;
        public Material Color => color;
    }

    [SerializeField] private CameraController cam;
    [SerializeField] private List<Tank> tankList;
    [SerializeField] private TankView tankView;

    public void CreateTank(TankType tankType)
    {
        int index = (int)tankType;
        TankModel tankModel = new TankModel
        (
            tankList[index].MovementSpeed,
            tankList[index].RotationSpeed,
            tankList[index].TankType,
            tankList[index].Color
        );

        TankController tankController = new TankController(tankModel, tankView, cam);
    }
}