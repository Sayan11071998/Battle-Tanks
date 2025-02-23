using UnityEngine;

public class TankModel
{
    private TankController tankController;

    private float movementSpeed;
    private float rotationSpeed;
    private TankType tanktype;
    private Material color;

    public TankModel(float _movement, float _rotation, TankType _tankType, Material _color)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        tanktype = _tankType;
        color = _color;
    }

    public void SetTankController(TankController _tankController) => tankController = _tankController;
    public float MovementSpeed => movementSpeed;
    public float RotationSpeed => rotationSpeed;
    public TankType TankType => tanktype;
    public Material Color => color;
}