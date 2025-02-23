using System;
using UnityEngine;

public class TankView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshRenderer[] childs;
    [SerializeField] private BulletSpawner bulletSpawner;

    private TankController tankController;
    private float movementInput;
    private float rotationInput;
    private float shootCooldown;

    private void Start()
    {
        shootCooldown = 0f;
    }

    private void Update()
    {
        GetInput();
        shootCooldown -= Time.deltaTime;

        if (movementInput != 0)
        {
            tankController.Move(movementInput);
        }

        if (rotationInput != 0)
        {
            tankController.Rotate(rotationInput);
        }

        if (Input.GetKeyDown(KeyCode.Space) && shootCooldown <= 0)
        {
            Shoot();
            shootCooldown = 1f;
        }
    }

    private void GetInput()
    {
        movementInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
    }

    private void Shoot()
    {
        TankModel tankModel = tankController.GetTankModel();
        switch (tankModel.TankType)
        {
            case TankType.GreenTank:
                bulletSpawner.SpawnBullet(BulletType.HighExplosive);
                break;
            case TankType.BlueTank:
                bulletSpawner.SpawnBullet(BulletType.GuidedMissile, FindNearestEnemy());
                break;
            case TankType.RedTank:
                bulletSpawner.SpawnBullet(BulletType.ArmorPiercing);
                break;
        }
    }

    private Transform FindNearestEnemy()
    {
        GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
        Transform nearest = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject tank in tanks)
        {
            if (tank != gameObject)
            {
                float dist = Vector3.Distance(tank.transform.position, currentPos);
                if (dist < minDist)
                {
                    minDist = dist;
                    nearest = tank.transform;
                }
            }
        }
        return nearest;
    }

    public void ChangeColor(Material color)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = color;
        }
    }

    public void SetTankController(TankController _tankController) => tankController = _tankController;
    public Rigidbody GetRigidbody() => rb;
}