using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    public Rigidbody rb;
    public MeshRenderer renderer;

    private void Update() => bulletController.Move();
    private void OnTriggerEnter(Collider other) => bulletController.OnCollision(other);
    public void SetBulletController(BulletController _bulletController) => bulletController = _bulletController;
    public Rigidbody GetRigidbody() => rb;
    public void ChangeAppearance(Material _material) => renderer.material = _material;
}