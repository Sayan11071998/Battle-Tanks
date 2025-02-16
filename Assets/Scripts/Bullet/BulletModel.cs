using UnityEngine;

public class BulletModel
{
    private BulletController bulletController;

    public float speed;
    public Material color;

    public BulletModel(float _speed, Material _color)
    {
        speed = _speed;
        color = _color;
    }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
}