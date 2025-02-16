using UnityEngine;

public class BulletModel
{
    private BulletController bulletController;

    public float speed;
    public Material color;
    public float lifeTime;

    public BulletModel(float _speed, Material _color, float _lifeTime)
    {
        speed = _speed;
        color = _color;
        lifeTime = _lifeTime;
    }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
}