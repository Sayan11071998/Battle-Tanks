using System;
using UnityEngine;
using Cinemachine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;

    private Rigidbody rb;
    private CameraController virtualCam;

    public TankController(TankModel _tankModel, TankView _tankView, CameraController cam)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);

        rb = tankView.GetRigidbody();
        virtualCam = cam;

        tankModel.SetTankController(this);
        tankView.SetTankController(this);

        tankView.ChangeColor(tankModel.Color);
        virtualCam.SetPlayer(tankView.transform);
    }

    public void Move(float movement) => rb.velocity = tankView.transform.forward * movement * tankModel.MovementSpeed;

    public void Rotate(float rotate)
    {
        Vector3 vector = new Vector3(0f, rotate * tankModel.RotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public TankModel GetTankModel() => tankModel;
}