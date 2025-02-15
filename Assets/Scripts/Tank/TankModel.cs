using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;
    public TankTypes tankType;
    public Material color;

    public TankModel(float _movement, float _rotation, TankTypes _tank, Material _color)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        tankType = _tank;
        color = _color;
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}