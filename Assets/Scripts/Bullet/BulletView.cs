using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshRenderer renderer;

    private BulletController bulletController;
    private float elapsedTime;

    private void Update()
    {
        bulletController.Move();
        CheckLifetime();
    }

    private void CheckLifetime()
    {
        BulletModel model = bulletController.GetBulletModel();
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= model.Lifetime)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
        elapsedTime = 0f;
    }

    private void OnTriggerEnter(Collider other) => bulletController.OnCollision(other);
    public Rigidbody GetRigidbody() => rb;
    public void ChangeAppearance(Material _material) => renderer.material = _material;
}