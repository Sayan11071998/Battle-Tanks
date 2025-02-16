using UnityEngine;

public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletView;

    public BulletController(BulletModel _bulletModel, BulletView _bulletView)
    {
        bulletModel = _bulletModel;
        bulletView = GameObject.Instantiate<BulletView>(_bulletView);

        bulletModel.SetBulletController(this);
        bulletView.SetBulletController(this);

        bulletView.ChangeColor(bulletModel.color);
    }

    public void Move(Vector3 position, Vector3 direction)
    {
        bulletView.transform.position = position;
        bulletView.rb.velocity = direction * bulletModel.speed;
    }

    public void OnCollision(Collision collision)
    {
        GameObject.Destroy(bulletView.gameObject);
    }
}