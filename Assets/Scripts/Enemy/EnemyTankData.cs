using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankData", menuName = "Tank/EnemyTankData")]
public class EnemyTankData : ScriptableObject
{
    public string tankName;
    public Material color;
    public float health;
    public float firePower;
    public float speed;
    public float fireRate;
}