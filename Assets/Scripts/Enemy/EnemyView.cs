using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;
    public Rigidbody rb;
    public MeshRenderer[] childs;
    public Transform bulletSpawnPoint;
    public BulletView bulletPrefab;

    public void ChangeColor(Material color)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = color;
        }
    }

    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
        ChangeColor(enemyController.GetEnemyModel().color);
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public Transform GetBulletSpawnPoint()
    {
        return bulletSpawnPoint;
    }

    public BulletView GetBulletPrefab()
    {
        return bulletPrefab;
    }
}
