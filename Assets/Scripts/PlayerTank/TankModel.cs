using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;
    public TankType tanktype;
    public Material color;

    public TankModel(float _movement, float _rotation, TankType _tankType, Material _color)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        tanktype = _tankType;
        color = _color;
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}