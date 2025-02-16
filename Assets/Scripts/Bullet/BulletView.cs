using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    public Rigidbody rb;
    public MeshRenderer meshRenderer;

    private void OnCollisionEnter(Collision collision)
    {
        bulletController.OnCollision(collision);
    }

    public void ChangeColor(Material color)
    {
        meshRenderer.material = color;
    }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
}