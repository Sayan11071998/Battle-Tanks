using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;
    public TankTypes tankType;
    public Material color;
    public float health;
    public float firePower;

    public TankModel(float _movement, float _rotation, TankTypes _tank, Material _color, float _health, float _firePower)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        tankType = _tank;
        color = _color;
        health = _health;
        firePower = _firePower;
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}